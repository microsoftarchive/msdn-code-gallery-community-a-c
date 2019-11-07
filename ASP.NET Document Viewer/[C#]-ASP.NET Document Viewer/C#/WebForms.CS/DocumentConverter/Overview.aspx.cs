using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using GleamTech.AspNet;
using GleamTech.DocumentUltimate;
using GleamTech.Examples;
using GleamTech.IO;
using GleamTech.Util;

namespace GleamTech.DocumentUltimateExamples.WebForms.CS.DocumentConverter
{
    public partial class OverviewPage : Page
    {
        protected string InputFormat;
        protected string ConvertHandlerUrl;

        protected void Page_Load(object sender, EventArgs e)
        {
            var inputDocument = exampleFileSelector.SelectedFile;
            var fileInfo = new FileInfo(inputDocument);

            var inputFormat = DocumentFormatInfo.Get(inputDocument);
            InputFormat = inputFormat != null ? inputFormat.Description : "(not supported)";

            PopulatePossibleOutputFormats(inputDocument);

            ConvertHandlerUrl = ExamplesConfiguration.GetDynamicDownloadUrl(
                ConvertHandlerName,
                new NameValueCollection
                {
                    {"inputDocument", ExamplesConfiguration.ProtectString(inputDocument)},
                    {"version", fileInfo.LastWriteTimeUtc.Ticks + "-" +  fileInfo.Length}
                });
        }

        private void PopulatePossibleOutputFormats(string inputDocument)
        {
            var outputFormats = new Dictionary<string, List<ListItem>>();

            foreach (var format in DocumentUltimate.DocumentConverter.EnumeratePossibleOutputFormats(inputDocument))
            {
                var formatInfo = DocumentFormatInfo.Get(format);

                List<ListItem> groupData;
                if (!outputFormats.TryGetValue(formatInfo.Group.Description, out groupData))
                {
                    groupData = new List<ListItem>();
                    outputFormats.Add(formatInfo.Group.Description, groupData);
                }
                groupData.Add(new ListItem(formatInfo.Description, formatInfo.Value.ToString()));
            }

            if (outputFormats.Count == 0)
                outputFormats.Add("(not supported)", new List<ListItem>());

            OutputFormats.DataSource = outputFormats;
            OutputFormats.DataBind();
        }

        public static void ConvertHandler(IHttpContext context)
        {
            DocumentConverterResult result;

            try
            {
                var inputDocument = new BackSlashPath(ExamplesConfiguration.UnprotectString(context.Request["inputDocument"]));
                var outputFormat = (DocumentFormat) Enum.Parse(typeof(DocumentFormat), context.Request["outputFormat"]);
                var fileName = inputDocument.FileNameWithoutExtension + "." + DocumentFormatInfo.Get(outputFormat).DefaultExtension;
                var outputPath = ConvertedPath.Append(context.Session.Id).Append(fileName);
                var outputDocument = outputPath.Append(fileName);

                if (Directory.Exists(outputPath))
                    Directory.Delete(outputPath, true);
                Directory.CreateDirectory(outputPath);
                result = DocumentUltimate.DocumentConverter.Convert(inputDocument, outputDocument, outputFormat);
            }
            catch (Exception exception)
            {
                context.Response.Output.Write("<span style=\"color: red; font-weight: bold\">Conversion failed</span><br/>");
                context.Response.Output.Write(exception.Message);
                return;
            }

            context.Response.Output.Write("<span style=\"color: green; font-weight: bold\">Conversion successful</span>");
            context.Response.Output.Write("<br/>Conversion time: " + result.ElapsedTime);
            context.Response.Output.Write("<br/>Output files:");

            if (result.OutputFiles.Length > 1)
                context.Response.Output.Write(" - " + GetZipDownloadLink(new FileInfo(result.OutputFiles[0]).Directory));

            context.Response.Output.Write("<br/><ol>");
            foreach (var outputFile in result.OutputFiles)
            {
                if (outputFile.EndsWith("\\"))
                {
                    var directoryInfo = new DirectoryInfo(outputFile);
                    context.Response.Output.Write(string.Format(
                        "<br/><li><b>{0}\\</b> - {1}</li>",
                        directoryInfo.Name,
                        GetZipDownloadLink(directoryInfo))
                    );
                }
                else
                {
                    var fileInfo = new FileInfo(outputFile);
                    context.Response.Output.Write(string.Format(
                        "<br/><li><b>{0}</b> ({1} bytes) - {2}</li>",
                        fileInfo.Name,
                        fileInfo.Length,
                        GetDownloadLink(fileInfo))
                    );
                }
            }
            context.Response.Output.Write("<br/></ol>");
        }

        private static string GetDownloadLink(FileInfo fileInfo)
        {
            return string.Format(
                "<a href=\"{0}\">Download</a>",
                ExamplesConfiguration.GetDownloadUrl(fileInfo.FullName, fileInfo.LastWriteTimeUtc.Ticks.ToString()));
        }

        private static string GetZipDownloadLink(DirectoryInfo directoryInfo)
        {
            return string.Format(
                "<a href=\"{0}\">Download as Zip</a>",
                ExamplesConfiguration.GetDynamicDownloadUrl(
                    ZipDownloadHandlerName,
                    new NameValueCollection
                    {
                        {"path", ExamplesConfiguration.ProtectString(directoryInfo.FullName)},
                        {"version", directoryInfo.LastWriteTimeUtc.Ticks.ToString()},
                    }));
        }

        public static void ZipDownloadHandler(IHttpContext context)
        {
            var path = new BackSlashPath(ExamplesConfiguration.UnprotectString(context.Request["path"])).RemoveTrailingSlash();

            var fileResponse = new FileResponse(context, 0);
            fileResponse.Transmit((targetStream, copyFileCallback) =>
            {
                QuickZip.Zip(targetStream, Directory.EnumerateFileSystemEntries(path));
            }, path.FileName + ".zip", 0);

        }

        private static string ConvertHandlerName
        {
            get
            {
                if (convertHandlerName == null)
                {
                    convertHandlerName = "ConvertHandler";
                    ExamplesConfiguration.RegisterDynamicDownloadHandler(convertHandlerName, ConvertHandler);
                }

                return convertHandlerName;
            }
        }
        private static string convertHandlerName;

        private static string ZipDownloadHandlerName
        {
            get
            {
                if (zipDownloadHandlerName == null)
                {
                    zipDownloadHandlerName = "ZipDownloadHandler";
                    ExamplesConfiguration.RegisterDynamicDownloadHandler(zipDownloadHandlerName, ZipDownloadHandler);
                }

                return zipDownloadHandlerName;
            }
        }
        private static string zipDownloadHandlerName;

        private static readonly BackSlashPath ConvertedPath = Hosting.ResolvePhysicalPath("~/App_Data/ConvertedDocuments");
    }
}