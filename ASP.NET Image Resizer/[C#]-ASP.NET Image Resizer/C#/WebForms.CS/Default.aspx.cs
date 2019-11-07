using System;
using System.Web.UI;
using GleamTech.Examples;
using GleamTech.ImageUltimate;

namespace GleamTech.ImageUltimateExamples.WebForms.CS
{
    public partial class DefaultPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            exampleExplorer.VersionTitle = "v" + ImageUltimateConfiguration.AssemblyInfo.FileVersion;

            exampleExplorer.Examples = new ExampleBase[]
            {
                new Example
                {
                    Title = "Overview",
                    Url = "Overview.aspx",
                    SourceFiles = new[] { "Overview.aspx", "Overview.aspx.cs"},
                    DescriptionFile = "Descriptions/Overview.html"
                },
                new Example
                {
                    Title = "Image Processing",
                    Url = "Processing.aspx",
                    SourceFiles = new[] { "Processing.aspx", "Processing.aspx.cs"},
                    DescriptionFile = "Descriptions/Processing.html"
                }
            };

            exampleExplorer.ExampleProjectName = "ASP.NET Web Forms (C#)";
            exampleExplorer.ExampleProjects = ExamplesConfiguration.LoadExampleProjects(Server.MapPath("~/App_Data/ExampleProjects.json"));
        }
    }
}
