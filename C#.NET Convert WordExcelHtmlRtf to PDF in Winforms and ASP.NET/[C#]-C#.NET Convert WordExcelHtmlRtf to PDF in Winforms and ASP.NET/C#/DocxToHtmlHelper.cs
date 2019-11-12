using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iDiTect.Converter.Demo
{
    public static class DocxToHtmlHelper
    {
        public static void Convert()
        {
            DocxToHtmlConverter converter = new DocxToHtmlConverter();

            //Load Word document from stream
            using (Stream stream = File.OpenRead("sample.docx"))
            {
                converter.Load(stream);
            }

            //Images are embedded in the main html file as Base64-encoded strings.
            converter.HtmlImageMode = HtmlImageMode.Embedded;
            //Styles are embedded in 'style' element in the 'head' section.
            converter.HtmlStyleMode = HtmlStyleMode.Embedded;
                        
            //Convert Word to html, and save it to file stream
            using (var stream = File.OpenWrite("convert.html"))
            {
                converter.Save(stream);
            }
        }

        public static void Convert2()
        {
            DocxToHtmlConverter converter = new DocxToHtmlConverter();

            //Load Word document from byte array
            converter.Load(File.ReadAllBytes("sample.docx"));

            //Images are exported in separate files
            converter.HtmlImageMode = HtmlImageMode.External;
            //The folder that will contain the external image files
            converter.ImagesFolder = "./images/";
            //The base folder that will be set as value to the 'src' attribute of the 'img' elements
            converter.ImagesSourceBaseFolder = "./images/";

            //Styles are exported to external CSS file
            converter.HtmlStyleMode = HtmlStyleMode.External;
            //The file that will contain the external styles
            converter.StyleFile = "./styles/test.css";
            //The file that will be set as 'href' attribute of the 'link' element pointing to the external styles
            converter.StyleSourceFile = "./styles/test.css";

            //Convert Word to html, and save it to hard disk
            File.WriteAllText("convert.html", converter.SaveAsString());
        }
    }
}
