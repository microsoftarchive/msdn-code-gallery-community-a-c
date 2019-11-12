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

			SautinSoft.UseOffice u = new SautinSoft.UseOffice();
            string inFile = @"c:\Odissey.docx";
			string outFile = Path.ChangeExtension(inFile,".pdf");

			//Prepare UseOffice .Net, loads MS Word in memory
            if (u.InitWord() == 0)
            {
                u.ConvertFile(inFile, outFile, SautinSoft.UseOffice.eDirection.DOCX_to_PDF);
                //Release MS Word from memory
                u.CloseWord();
            }
		}
	}
}
