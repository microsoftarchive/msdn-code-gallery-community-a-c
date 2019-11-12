using System;
using System.IO;
using System.Text;
using SautinSoft;

namespace SampleConvert
{
	class sample
	{
		static void Main(string[] args)
		{
			SautinSoft.RtfToHtml r = new SautinSoft.RtfToHtml();
			string AppPath=System.Environment.CurrentDirectory;

			//specify some options
			r.OutputFormat = SautinSoft.RtfToHtml.eOutputFormat.HTML_5;
			r.Encoding = SautinSoft.RtfToHtml.eEncoding.UTF_8;

           	string rtfFile = Path.GetFullPath(@"D:\test.rtf");
			string htmlFile = Path.Combine(AppPath,"test.html"); //the result will be located in the same folder as binary

			int i = r.ConvertFile(rtfFile,htmlFile);
            if (i == 0)
            {
                System.Console.WriteLine("Converted successfully!");
                System.Diagnostics.Process.Start(htmlFile);
            }
            else
            {
                System.Console.WriteLine("Conversion failed!");
                Console.ReadLine();
            }
		}
	}
}
