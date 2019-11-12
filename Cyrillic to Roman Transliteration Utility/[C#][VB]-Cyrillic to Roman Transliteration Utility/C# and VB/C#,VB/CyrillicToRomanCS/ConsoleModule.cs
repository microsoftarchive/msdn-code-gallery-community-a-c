using System;
using System.IO;
using System.Text;

class ConsoleModule
{
   static void Main()
   {
      string[] args = Environment.GetCommandLineArgs();
      string source = null;
      string destination = null;
      StreamReader sr = null;
      StreamWriter sw = null;

      // Get command line arguments.
      if (args.Length != 3) {
         Console.WriteLine("There must be a source and a destination file."); 
         ShowSyntax();
         return;
      }
      else {
         source = args[1];
         destination = args[2];
      }

      if (String.IsNullOrWhiteSpace(source) | String.IsNullOrWhiteSpace(destination)) {
         Console.WriteLine("There must be a source and a destination file.");
         ShowSyntax();
         return;
      }

      if (! File.Exists(source)) {
         Console.WriteLine("The source file {1}   '{0}'{1}cannot be found.", source, Environment.NewLine);
         ShowSyntax();
         return;
      }
      else {
         try {
            sr = new StreamReader(source);
         }
         catch (DirectoryNotFoundException) {
            Console.WriteLine("The directory is invalid.");
            return;
         }
         catch (IOException) {
            Console.WriteLine("An I/O exception occurred in opening the source file.");
            return;
         }
      }

      // Check whether destination file exists and exit if it should not be overwritten.
      if (File.Exists(destination)) {
         Console.Write("The destination file {1}   '{0}'{1}exists. Overwrite it? (Y/N) ", 
                       source, Environment.NewLine);
         ConsoleKeyInfo keyPressed = Console.ReadKey(true);
         if (Char.ToUpper(keyPressed.KeyChar) == 'Y' | Char.ToUpper(keyPressed.KeyChar) == 'N') {
            Console.WriteLine(keyPressed.KeyChar);
            if (Char.ToUpper(keyPressed.KeyChar) == 'N')
               return;
         }
      }

      try {
         sw = new StreamWriter(destination, false, System.Text.Encoding.UTF8);
      }
      catch (DirectoryNotFoundException) {
         Console.WriteLine("The directory is invalid.");
         return;
      }
      catch (IOException) {
         Console.WriteLine("An I/O exception occurred in opening the destination file.");
         return;
      }

      // Instantiate the encoder
      Encoding encoding = Encoding.GetEncoding(1252, new CyrillicToRomanFallback(), new DecoderExceptionFallback());
      // This is an encoding operation, so we only need to get the encoder.
      Encoder encoder = encoding.GetEncoder();
      Decoder decoder = encoding.GetDecoder();

      // Define buffer to read characters
      char[] buffer = new char[100];
      int charsRead; 

      do {
         // Read next 100 characters from input stream.
         charsRead = sr.ReadBlock(buffer, 0, buffer.Length);

         // Encode characters.
         int byteCount = encoder.GetByteCount(buffer, 0, charsRead, false);
         byte[] bytes = new byte[byteCount];
         int bytesWritten = encoder.GetBytes(buffer, 0, charsRead, bytes, 0, false);

         // Decode characters back to Unicode and write to a UTF-8-encoded file.
         char[] charsToWrite = new char[decoder.GetCharCount(bytes, 0, byteCount)];
         decoder.GetChars(bytes, 0, bytesWritten, charsToWrite, 0);
         sw.Write(charsToWrite);
      } while (charsRead == buffer.Length);
      sr.Close();
      sw.Close();
   }

   private static void ShowSyntax()
   {
      Console.WriteLine("\nSyntax: CyrillicToRoman <source> <destination>");
      Console.WriteLine("   where <source>      = source filename");
      Console.WriteLine("         <destination> = destination filename\n");
   }
}




