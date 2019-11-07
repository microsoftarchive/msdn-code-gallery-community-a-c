using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Crm.Sdk.Samples;
using Microsoft.Xrm.Sdk.Query;
using System.Reflection;
using System.CodeDom.Compiler;
using System.IO;
using Microsoft.CSharp;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml;
using Microsoft.Crm.Sdk.Messages;

namespace ConvertLinqToFetchXml
{
    /// <summary>
    /// Shows how to convert a Linq Query into QueryExpression and then to FetchXml
    /// For more information, see www.develop1.net
    /// </summary>
	class Program
	{
		private static OrganizationServiceProxy _serviceProxy;
		static void Main(string[] args)
		{

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Linq -> QueryExpression -> FetchXml Converter");
            Console.WriteLine("See www.develop1.net for more information");
            Console.ForegroundColor = ConsoleColor.Gray;
			ServerConnection serverConnect = new ServerConnection();
			ServerConnection.Configuration config = serverConnect.GetServerConfiguration();

			using (_serviceProxy = new OrganizationServiceProxy(config.OrganizationUri,
																config.HomeRealmUri,
																config.Credentials,
																config.DeviceCredentials))
			{

				_serviceProxy.EnableProxyTypes();

                using (OrganizationServiceContext ctx = new OrganizationServiceContext(_serviceProxy))
				{
					bool exit = false;
					do
					{
						Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine("Enter you linq Query:");
						Console.ForegroundColor = ConsoleColor.Gray;
						Console.WriteLine("E.g:\r\nfrom c in ctx.CreateQuery<Contact>()\r\n where c.LastName == \"Smith\" select c\r\n");
                        Console.WriteLine("<Enter> with blank line to compile query.");

                        // Get the query
                        string queryText = GetQueryFromConsole();

						try
						{
                            string filePath = AppDomain.CurrentDomain.BaseDirectory + @"QueryOutput.txt";

                            // Compile linq query
						    var linq = Compile(ctx, queryText.ToString());

                            QueryExpression query = GetQueryExpression(linq);
                            File.AppendAllText(filePath, "\r\n----------------------------------------\r\nLINQ QUERY\r\n----------------------------------------\r\n" + queryText);
                           
							// Show Query Expression
                            string queryExpression = OutputQueryExpressionToConsole(query);
                            File.AppendAllText(filePath, "\r\n----------------------------------------\r\nQUERY EXPRESSION\r\n----------------------------------------\r\n" + queryExpression);
                           
							// Convert to FetchXml
                            string fetchXml= GetFetchXml(query);
                            Console.WriteLine(fetchXml);
                            File.AppendAllText(filePath, "\r\n----------------------------------------\r\nFETCHXML\r\n----------------------------------------\r\n" + fetchXml);

                            Console.WriteLine("Output to file " + filePath);
						}
						catch (Exception ex)
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine(ex.Message);
						}

					} while (!exit);

					Console.ReadKey();

				}
			}
		}

        /// <summary>
        /// Convert a QueryExpression to FetchXml using QueryExpressionToFetchXmlRequest
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        private static string GetFetchXml(QueryExpression query)
        {
            var xmlWriterSettings = new XmlWriterSettings { Indent = true };
            QueryExpressionToFetchXmlRequest request = new QueryExpressionToFetchXmlRequest();
            request.Query = query;

            QueryExpressionToFetchXmlResponse response = (QueryExpressionToFetchXmlResponse)_serviceProxy.Execute(request);
            Console.ForegroundColor = ConsoleColor.Blue;

            // Format fetchxml
            XmlDocument fetchDoc = new XmlDocument();
            fetchDoc.LoadXml(response.FetchXml);

            StringWriter fetchXmlOutBuffer = new StringWriter();
            using (var writer = XmlTextWriter.Create(fetchXmlOutBuffer, xmlWriterSettings))
            {
                fetchDoc.WriteTo(writer);
            }
            return fetchXmlOutBuffer.ToString();
        }
        /// <summary>
        /// Write the query expression to the console by serializing it to Xml
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        private static string OutputQueryExpressionToConsole(QueryExpression query)
        {
            DataContractSerializer ser = new DataContractSerializer(typeof(QueryExpression));
            var xmlWriterSettings = new XmlWriterSettings { Indent = true };

            StringWriter serBuffer = new StringWriter();
            using (var writer = XmlTextWriter.Create(serBuffer, xmlWriterSettings))
            {
                ser.WriteObject(writer, query);
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(serBuffer.ToString());
            return serBuffer.ToString();
        }
        /// <summary>
        /// Gets a QueryExpression from the linq provider
        /// </summary>
        /// <param name="linq"></param>
        /// <returns></returns>
        private static QueryExpression GetQueryExpression(IQueryable linq)
        {
            object projection = null;
            object source = null;
            object linkLookups = null;
            bool flag = false;
            bool flag2 = false;

            object[] arguments = new object[6];
            arguments[0] = (object)linq.Expression;
            arguments[1] = (object)flag;
            arguments[2] = (object)flag2;
            arguments[3] = (object)projection;
            arguments[4] = (object)source;
            arguments[5] = (object)linkLookups;

            QueryExpression query = (QueryExpression)linq.Provider.GetType().InvokeMember("GetQueryExpression", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null, linq.Provider, arguments);
            return query;
        }

        private static string GetQueryFromConsole()
        {
            bool finshed = false;
            StringBuilder queryText = new StringBuilder();
            do
            {
                Console.Write(">");
                string queryLine = Console.ReadLine();

                finshed = (queryLine.Length == 0);
                if (!finshed)
                {
                    queryText.AppendLine(queryLine);
                }
            } while (!finshed);
            return queryText.ToString();
        }

		public static IQueryable Compile(OrganizationServiceContext ctx, string queryText)
		{

			IDictionary<string, string> options = new Dictionary<string, string>();
			options.Add("CompilerVersion", "v4.0");

			CodeDomProvider compiler = new CSharpCodeProvider(options);
			CompilerParameters parameters = new CompilerParameters();
			parameters.WarningLevel = 4;
			parameters.GenerateExecutable = false;
			parameters.GenerateInMemory = true;

			// Add all the same assembly references as this project
			Assembly[] refAssemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly a in refAssemblies)
			{
				parameters.ReferencedAssemblies.Add(a.Location);
			}

			StringBuilder code = new StringBuilder();

			code.Append(@"using System;
							using System.Collections.Generic;
							using System.Linq;
							using System.Text;
							using Microsoft.Xrm.Sdk.Client;
							using Microsoft.Crm.Sdk.Samples;
							using Microsoft.Xrm.Sdk.Query;
			namespace LinqQuery
			{
				public class QueryClass{
					[STAThread]
					public static object Query(OrganizationServiceContext ctx)
					{
						var linq = ");
			code.Append(queryText);
			code.Append(@";
						return linq;
					}
				}
			}");

			CompilerResults results = compiler.CompileAssemblyFromSource(parameters, code.ToString());
			if (results.Errors.Count == 0)
			{
				Type newType = results.CompiledAssembly.GetType("LinqQuery.QueryClass");
				try
				{

					var result = newType.GetMethod("Query").Invoke(null, new object[] { ctx });
					return (IQueryable)result;
				}
				catch (TargetInvocationException ex)
				{
					throw new Exception("Could not compile query:" + ex.Message, ex);
				}
			}
			else
			{
				StringBuilder compileErrors = new StringBuilder();
				foreach (CompilerError s in results.Errors)
				{
					compileErrors.AppendLine(s.ErrorText);

				}
				throw new Exception("Could not compile query:\n" + compileErrors.ToString());
			}


		}
	}
}
