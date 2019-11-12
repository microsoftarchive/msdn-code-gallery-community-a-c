using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.WebControls;
using GleamTech.AspNet;
using GleamTech.DocumentUltimate;
using GleamTech.Examples;

namespace GleamTech.DocumentUltimateExamples.WebForms.CS.DocumentConverter
{
    public partial class PossiblePage : Page
    {
        protected int InputFormatCount;
        protected int OutputFormatCount;
        protected string ResultHandlerUrl;

        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateInputFormats();
            PopulateOutputFormats();

            ResultHandlerUrl = ExamplesConfiguration.GetDynamicDownloadUrl(
                ResultHandlerName,
                new NameValueCollection
                {
                    {"version", DateTime.UtcNow.Ticks.ToString()}
                });
        }

        private void PopulateInputFormats()
        {
            var inputFormats = new Dictionary<string, List<ListItem>>();

            foreach (var formatInfo in DocumentFormatInfo.Enumerate(DocumentFormatSupport.Load))
            {
                List<ListItem> groupData;
                if (!inputFormats.TryGetValue(formatInfo.Group.Description, out groupData))
                {
                    groupData = new List<ListItem>();
                    inputFormats.Add(formatInfo.Group.Description, groupData);
                }
                groupData.Add(new ListItem(formatInfo.Description, formatInfo.Value.ToString()));
                InputFormatCount++;
            }

            InputFormats.DataSource = inputFormats;
            InputFormats.DataBind();
        }

        private void PopulateOutputFormats()
        {
            var outputFormats = new Dictionary<string, List<ListItem>>();

            foreach (var formatInfo in DocumentFormatInfo.Enumerate(DocumentFormatSupport.Save))
            {
                List<ListItem> groupData;
                if (!outputFormats.TryGetValue(formatInfo.Group.Description, out groupData))
                {
                    groupData = new List<ListItem>();
                    outputFormats.Add(formatInfo.Group.Description, groupData);
                }
                groupData.Add(new ListItem(formatInfo.Description, formatInfo.Value.ToString()));
                OutputFormatCount++;
            }

            OutputFormats.DataSource = outputFormats;
            OutputFormats.DataBind();
        }

        public static void ResultHandler(IHttpContext context)
        {
            var inputFormat = (DocumentFormat)Enum.Parse(typeof(DocumentFormat), context.Request["inputFormat"]);
            var outputFormat = (DocumentFormat)Enum.Parse(typeof(DocumentFormat), context.Request["outputFormat"]);

            context.Response.Output.Write("<center>");

            if (DocumentUltimate.DocumentConverter.CanConvert(inputFormat, outputFormat))
            {
                context.Response.Output.Write(string.Format(
                    "<span style=\"color: green; font-weight: bold\">Direct conversion from {0} to {1} is possible</span>",
                    inputFormat, outputFormat)
                );

                foreach (var engine in Enum<DocumentEngine>.GetValues())
                {
                   
                    if (DocumentUltimate.DocumentConverter.CanConvert(inputFormat, outputFormat, engine))
                        context.Response.Output.Write(string.Format(
                            "<br/><span style=\"color: green; font-weight: bold\">Via {0} Engine &#x2713;</span>",
                            engine));
                    else
                        context.Response.Output.Write(string.Format(
                            "<br/><span style=\"color: red; font-weight: bold\">Via {0} Engine &#x2717;</span>",
                            engine));
                }
            }
            else
                context.Response.Output.Write(string.Format(
                    "<span style=\"color: red; font-weight: bold\">Direct conversion from {0} to {1} is not possible</span>",
                    inputFormat, outputFormat)
                    );

            context.Response.Output.Write("</center>");
        }

        private static string ResultHandlerName
        {
            get
            {
                if (resultHandlerName == null)
                {
                    resultHandlerName = "ResultHandler";
                    ExamplesConfiguration.RegisterDynamicDownloadHandler(resultHandlerName, ResultHandler);
                }

                return resultHandlerName;
            }
        }
        private static string resultHandlerName;
    }
}