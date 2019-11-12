using System;
using System.IO;
using System.Collections;
using SautinSoft;

namespace Sample
{
	class Test
	{
		
		static void Main(string[] args)
		{

			//Convert DOC file to HTML file	
			
            SautinSoft.UseOffice u = new SautinSoft.UseOffice();

			//Path to any local file
			string inputFilePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(),@"d:\Tempos\sample.doc"));
			//Path to output resulted file
			string outputFilePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(),@"d:\Tempos\sample.html"));

			//Prepare UseOffice .Net, loads MS Word in memory
			int ret = u.InitWord();			

			//Return values:
			//0 - Loading successfully
			//1 - Can't load MS Word® library in memory 

			if (ret==1)			
				return;
			
			//Converting
			ret = u.ConvertFile(inputFilePath, outputFilePath, SautinSoft.UseOffice.eDirection.DOC_to_HTML);

			//Release MS Word from memory
			u.CloseWord();

			//0 - Converting successfully
			//1 - Can't open input file. Check that you are using full local path to input file, URL and relative path are not supported
			//2 - Can't create output file. Please check that you have permissions to write by this path or probably this path already used by another application
			//3 - Converting failed, please contact with our Support Team
			//4 - MS Office isn't installed. The component requires that any of these versions of MS Office should be installed: 2000, XP, 2003, 2007 or 2010
			if(ret==0 )
			{
				//Show produced file
				System.Diagnostics.Process.Start(outputFilePath);
			}		
		}
	}
}
