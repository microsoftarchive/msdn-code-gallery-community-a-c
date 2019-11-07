namespace SimpleCopy
{
    using System;

    using CmdLine;

    internal class Program
    {
        private const string Title = "SimpleCopy Example";

        private static void Main()
        {
            Console.Title = Title;
            CommandLine.WriteLineColor(ConsoleColor.Yellow, Title);

            SimpleCopyArguments arguments = null;

            try
            {
                arguments = CommandLine.Parse<SimpleCopyArguments>();
            }
            catch (CommandLineHelpException helpException)
            {
                // User asked for help
                CommandLine.WriteLineColor(ConsoleColor.Magenta, helpException.ArgumentHelp.GetHelpText(Console.BufferWidth));
                Environment.Exit(1);
            }
            catch (CommandLineException exception)
            {
                // Some other kind of command line error
                CommandLine.WriteLineColor(ConsoleColor.Red, exception.ArgumentHelp.Message);
                CommandLine.WriteLineColor(ConsoleColor.Cyan, exception.ArgumentHelp.GetHelpText(Console.BufferWidth));

                CommandLine.Pause();
                Environment.Exit(1);
            }

            CommandLine.WriteLineColor(ConsoleColor.Green, "You Entered The following Command Options");

            foreach (var property in typeof(SimpleCopyArguments).GetProperties())
            {
                CommandLine.WriteLineColor(ConsoleColor.Yellow, "Property: {0}={1}", property.Name, property.GetValue(arguments, null));
            }

            CommandLine.Pause();
        }
    }
}