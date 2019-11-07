using CodeGen.Web.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGen.Web.Utility
{
    public class APIGenerator
    {
        public static dynamic GenerateAPIGet(List<vmColumn> tblColumns, string contentRootPath)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            StringBuilder builderPrm = new StringBuilder();
            StringBuilder builderSub = new StringBuilder();
            builderPrm.Clear(); builderSub.Clear();
            string fileContent = string.Empty; string queryPrm = string.Empty; string submitPrm = string.Empty;

            string tableName = tblColumns[0].Tablename; string tableSchema = tblColumns[0].TableSchema;
            string path = @"" + contentRootPath + "\\template\\WebAPI\\APIController.txt";

            //Api Controller
            string routePrefix = "api/" + textInfo.ToTitleCase(Conversion.RemoveSpecialCharacters(tableName.ToString()));
            string apiController = textInfo.ToTitleCase(Conversion.RemoveSpecialCharacters(tableName.ToString())) + "Controller";
            string collectionName = "List<" + tableName.ToString() + ">";
            string listObj = tableName.ToString() + "s";
            string getDbMethod = "_ctx." + tableName.ToString() + ".ToListAsync()";
            string entity = tableName.ToString();
            string urlApiGet = "api/" + textInfo.ToTitleCase(Conversion.RemoveSpecialCharacters(tableName.ToString())) + "/GetAll";
            string urlApiGetByID = "api/" + textInfo.ToTitleCase(Conversion.RemoveSpecialCharacters(tableName.ToString())) + "/GetByID/5";
            string urlApiPost = "api/" + textInfo.ToTitleCase(Conversion.RemoveSpecialCharacters(tableName.ToString())) + "/Save";
            string urlApiPut = "api/" + textInfo.ToTitleCase(Conversion.RemoveSpecialCharacters(tableName.ToString())) + "/UpdateByID/5";
            string urlApiDeleteByID = "api/" + textInfo.ToTitleCase(Conversion.RemoveSpecialCharacters(tableName.ToString())) + "/DeleteByID/5";

            //Enity Fields
            foreach (var item in tblColumns)
            {
                //parameter
                builderPrm.AppendLine();
                builderPrm.Append("                        entityUpdate." + item.ColumnName + " = model." + item.ColumnName + ";");
            }
            submitPrm = builderPrm.AppendLine().ToString();

            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                fileContent = sr.ReadToEnd()
                    .Replace("#RoutePrefix", routePrefix.ToString())
                    .Replace("#APiController", apiController.ToString())
                    .Replace("#Collection", collectionName.ToString())
                    .Replace("#ListObj", listObj.ToString())
                    .Replace("#DbMethod", getDbMethod.ToString())
                    .Replace("#Entity", entity.ToString())
                    .Replace("#UrlApiGet", urlApiGet.ToString())
                    .Replace("#UrlGetByID", urlApiGetByID.ToString())
                    .Replace("#UrlPostByID", urlApiPost.ToString())
                    .Replace("#UrlApiPut", urlApiPut.ToString())
                    .Replace("#ColUpdate", submitPrm.ToString())
                    .Replace("#UrlDeleteByID", urlApiDeleteByID.ToString());
            }

            return fileContent.ToString();
        }
    }
}
