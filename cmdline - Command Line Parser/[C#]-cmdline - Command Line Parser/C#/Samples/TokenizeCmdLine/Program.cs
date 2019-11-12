namespace TokenizeCmdLine
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    using CmdLine;

    internal class Program
    {
        #region Constants and Fields

        private const string Title = "Command Line Tokenize Example";

        #endregion

        #region Methods

        /// <summary>
        ///   Helpful for creating command line arguments arrays for tests
        /// </summary>
        private static void CopyArgsToClipboard()
        {
            const string format = "var args = new string[] {{{0}}};";
            var sb = new StringBuilder();

            foreach (var arg in CommandLine.Args)
            {
                sb.AppendFormat("\"{0}\",", Regex.Replace(arg, "\\\\", "\\\\"));
            }

            Clipboard.SetText(string.Format(format, sb));
        }

        [STAThread]
        private static void Main()
        {
            Console.Title = Title;
            CommandLine.WriteLineColor(ConsoleColor.Yellow, Title);

            var index = 0;
            CommandLine.WriteLineColor(ConsoleColor.Green, "Environment.CommandLine Arguments");

            CommandLine.WriteLineColor(ConsoleColor.Yellow, "Command Line: {0}", Environment.CommandLine);
            CommandLine.WriteLineColor(ConsoleColor.Magenta, "Program {0}", CommandLine.Program);
            foreach (var token in CommandLine.Args)
            {
                Console.WriteLine("Argument [{0}]", index++);
                CommandLine.WriteLineColor(ConsoleColor.Green, token);
                Console.WriteLine();
            }

            var response = CommandLine.PromptKey("Do you want to copy the arguments to the clipboard?", 'y', 'n');
            if (response == 'y')
            {
                CopyArgsToClipboard();
            }

            CommandLine.Pause();
        }

        #endregion
    }
}