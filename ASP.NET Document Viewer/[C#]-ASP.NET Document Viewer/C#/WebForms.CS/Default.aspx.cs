using System;
using System.Web.UI;
using GleamTech.DocumentUltimate;
using GleamTech.Examples;

namespace GleamTech.DocumentUltimateExamples.WebForms.CS
{
    public partial class DefaultPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            exampleExplorer.VersionTitle = "v" + DocumentUltimateConfiguration.AssemblyInfo.FileVersion;

            exampleExplorer.Examples = new ExampleBase[]
            {
                new ExampleFolder
                {
                    Title = "Document Viewer",
                    Children = new ExampleBase[]
                    {
                        new Example
                        {
                            Title = "Overview",
                            Url = "DocumentViewer/Overview.aspx",
                            SourceFiles = new[] {"DocumentViewer/Overview.aspx", "DocumentViewer/Overview.aspx.cs"},
                            DescriptionFile = "Descriptions/DocumentViewer/Overview.html"
                        },
                        new Example
                        {
                            Title = "Copy protection (DRM)",
                            Url = "DocumentViewer/Protection.aspx",
                            SourceFiles = new[] {"DocumentViewer/Protection.aspx", "DocumentViewer/Protection.aspx.cs"},
                            DescriptionFile = "Descriptions/DocumentViewer/Protection.html"
                        },
                        new Example
                        {
                            Title = "Auto searching and highlighting keywords",
                            Url = "DocumentViewer/Highlight.aspx",
                            SourceFiles = new[] {"DocumentViewer/Highlight.aspx", "DocumentViewer/Highlight.aspx.cs"},
                            DescriptionFile = "Descriptions/DocumentViewer/Highlight.html"
                        },
                        new Example
                        {
                            Title = "Watermarking pages",
                            Url = "DocumentViewer/Watermark.aspx",
                            SourceFiles = new[] {"DocumentViewer/Watermark.aspx", "DocumentViewer/Watermark.aspx.cs"},
                            DescriptionFile = "Descriptions/DocumentViewer/Watermark.html"
                        },
                        new Example
                        {
                            Title = "Using with a stream",
                            Url = "DocumentViewer/Stream.aspx",
                            SourceFiles = new[] {"DocumentViewer/Stream.aspx", "DocumentViewer/Stream.aspx.cs"},
                            DescriptionFile = "Descriptions/DocumentViewer/Stream.html"
                        },
                        new Example
                        {
                            Title = "Client-side events",
                            Url = "DocumentViewer/ClientEvents.aspx",
                            SourceFiles = new[] { "DocumentViewer/ClientEvents.aspx", "DocumentViewer/ClientEvents.aspx.cs"},
                            DescriptionFile = "Descriptions/DocumentViewer/ClientEvents.html"
                        }
                    }
                },
                new ExampleFolder
                {
                    Title = "Document Converter",
                    Children = new ExampleBase[]
                    {
                        new Example
                        {
                            Title = "Overview",
                            Url = "DocumentConverter/Overview.aspx",
                            SourceFiles = new[] { "DocumentConverter/Overview.aspx", "DocumentConverter/Overview.aspx.cs"},
                            DescriptionFile = "Descriptions/DocumentConverter/Overview.html"
                        },
                        new Example
                        {
                            Title = "Possible conversions",
                            Url = "DocumentConverter/Possible.aspx",
                            SourceFiles = new[] { "DocumentConverter/Possible.aspx", "DocumentConverter/Possible.aspx.cs"},
                            DescriptionFile = "Descriptions/DocumentConverter/Possible.html"
                        }
                    }
                }
            };

            exampleExplorer.ExampleProjectName = "ASP.NET Web Forms (C#)";
            exampleExplorer.ExampleProjects = ExamplesConfiguration.LoadExampleProjects("~/App_Data/ExampleProjects.json");
        }
    }
}
