// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandLine.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CmdLine
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class for parsing command line arguments
    /// </summary>
    public static class CommandLine
    {
        #region Constants and Fields

        /// <summary>
        /// The default switch separators.
        /// </summary>
        public static readonly string[] DefaultSwitchSeparators = new[] { "/", "-" };

        /// <summary>
        /// The default value separators.
        /// </summary>
        public static readonly string[] DefaultValueSeparators = new[] { ":", "=" };

        /// <summary>
        /// The positional value group.
        /// </summary>
        internal const string PositionalValueGroup = "PositionalValue";

        /// <summary>
        /// The switch name group.
        /// </summary>
        internal const string SwitchNameGroup = "SwitchName";

        /// <summary>
        /// The switch option group.
        /// </summary>
        internal const string SwitchOptionGroup = "SwitchOption";

        /// <summary>
        /// The switch separator group.
        /// </summary>
        internal const string SwitchSeparatorGroup = "SwitchSeparator";

        /// <summary>
        /// The value group.
        /// </summary>
        internal const string ValueGroup = "Value";

        /// <summary>
        /// The value separator group.
        /// </summary>
        internal const string ValueSeparatorGroup = "ValueSeparator";

        /// <summary>
        ///   Expression for a switch with a value i.e. /S:Value or /S:Some Value
        /// </summary>
        /// <remarks>
        ///   This expression divides the token into groups
        /// </remarks>
        private const string TokenizeExpressionFormat =
            @"(?{0}i) # Case Sensitive Option
# Capture the switch begin of string or preceeded by whitespace
(?<SwitchSeparator>\A[{1}])
# Capture the switch name
(?<SwitchName>[^{2}+-]+) 
# Capture switch option or end of string
(?<SwitchOption>[{2}+-]|\z) 
# Capture the switch value or end of string 
(?<Value>.*)\Z";

        /// <summary>
        /// The args.
        /// </summary>
        private static string[] args;

        /// <summary>
        /// The command environment.
        /// </summary>
        private static ICommandEnvironment commandEnvironment = new CommandEnvironment();

        /// <summary>
        /// The command separator list.
        /// </summary>
        private static List<string> commandSeparatorList = new List<string>(DefaultSwitchSeparators);

        /// <summary>
        /// The parameters.
        /// </summary>
        private static CommandLineParametersCollection parameters;

        /// <summary>
        /// The value separator list.
        /// </summary>
        private static List<string> valueSeparatorList = new List<string>(DefaultValueSeparators);

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets Args.
        /// </summary>
        public static string[] Args
        {
            get
            {
                // GetCommandLineArgs puts the program in element 0
                // The args passed to Main do not do this so remove it
                var commandLineArgs = CommandEnvironment.GetCommandLineArgs();
                args = new string[commandLineArgs.Length - 1];
                for (var i = 0; i < commandLineArgs.Length - 1; i++)
                {
                    args[i] = commandLineArgs[i + 1];
                }

                return args;
            }

            internal set
            {
                args = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether CaseSensitive.
        /// </summary>
        public static bool CaseSensitive { get; set; }

        /// <summary>
        /// Gets or sets CommandEnvironment.
        /// </summary>
        public static ICommandEnvironment CommandEnvironment
        {
            get
            {
                return commandEnvironment;
            }

            set
            {
                commandEnvironment = value;
            }
        }

        /// <summary>
        /// Gets or sets CommandSeparators.
        /// </summary>
        public static IEnumerable<string> CommandSeparators
        {
            get
            {
                return commandSeparatorList;
            }

            set
            {
                commandSeparatorList = new List<string>(value);
            }
        }

        /// <summary>
        /// Gets Program.
        /// </summary>
        public static string Program
        {
            get
            {
                return CommandEnvironment.GetCommandLineArgs()[0];
            }
        }

        /// <summary>
        /// Gets Text.
        /// </summary>
        public static string Text
        {
            get
            {
                return CommandEnvironment.CommandLine;
            }
        }

        /// <summary>
        /// Gets or sets UserTokenizePattern.
        /// </summary>
        public static string UserTokenizePattern { get; set; }

        /// <summary>
        /// Gets or sets ValueSeparators.
        /// </summary>
        public static IEnumerable<string> ValueSeparators
        {
            get
            {
                return valueSeparatorList;
            }

            set
            {
                valueSeparatorList = new List<string>(value);
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets RegexTokenize.
        /// </summary>
        private static Regex RegexTokenize
        {
            get
            {
                return new Regex(TokenizePattern, RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);
            }
        }

        /// <summary>
        /// Gets TokenizePattern.
        /// </summary>
        private static string TokenizePattern
        {
            get
            {
                return UserTokenizePattern
                       ??
                       string.Format(TokenizeExpressionFormat, GetCaseSensitiveOption(), string.Join(string.Empty, CommandSeparators), string.Join(string.Empty, ValueSeparators));
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The get parameters.
        /// </summary>
        /// <param name="tokens">
        /// The tokens.
        /// </param>
        /// <returns>
        /// A list of CommandArguments that are parameters
        /// </returns>
        public static List<CommandArgument> GetParameters(List<CommandArgument> tokens)
        {
            return tokens == null ? null : tokens.FindAll(arg => arg.IsParameter());
        }

        /// <summary>
        /// The get switches.
        /// </summary>
        /// <param name="tokens">
        /// The tokens.
        /// </param>
        /// <returns>
        /// A list of CommandArguments that are switches
        /// </returns>
        public static List<CommandArgument> GetSwitches(List<CommandArgument> tokens)
        {
            return tokens == null ? null : tokens.FindAll(arg => arg.IsCommand());
        }

        /// <summary>
        /// The parse.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the command argument class
        /// </typeparam>
        /// <returns>
        /// A class populated with arguments from the command line
        /// </returns>
        /// <exception cref="CommandLineHelpException">
        /// The command line could not be parsed
        /// </exception>
        public static T Parse<T>() where T : class, new()
        {
            Debug.WriteLine(string.Format("Parsing argument class [{0}] Command Line: [{1}]", typeof(T), Text));

            var argument = InitializeNewArgument<T>();

            var tokens = Tokenize();

            foreach (var commandArgument in tokens)
            {
                ApplyCommandArgument(commandArgument, argument);
            }

            // Some commands signify a request for command line help
            if (parameters.Values.Any(p => p.Attribute.IsHelp && p.ArgumentSupplied))
            {
                throw new CommandLineHelpException(new CommandArgumentHelp(typeof(T)));
            }

            parameters.VerifyRequiredArguments();

            return argument;
        }

        /// <summary>
        /// The pause.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="color">
        /// The color.
        /// </param>
        public static void Pause(string text = "Press any key to continue...", ConsoleColor color = ConsoleColor.Yellow)
        {
            WriteLineColor(color, text);
            Console.ReadKey(true);
        }

        /// <summary>
        /// The prompt key.
        /// </summary>
        /// <param name="prompt">
        /// The prompt.
        /// </param>
        /// <param name="allowedKeys">
        /// The allowed keys.
        /// </param>
        /// <returns>
        /// The key that was pressed.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// No list of allowed keys was provided
        /// </exception>
        public static char PromptKey(string prompt, params char[] allowedKeys)
        {
            if (allowedKeys == null)
            {
                throw new ArgumentNullException("allowedKeys");
            }

            char keyChar;
            bool validKey;
            var allowedString = ToDelimitedList(allowedKeys);
            do
            {
                Console.Write("{0} ({1}) ", prompt, allowedString);
                keyChar = ToLower(Console.ReadKey(false).KeyChar);
                validKey = allowedKeys.Contains(keyChar);
                if (!validKey)
                {
                    Console.WriteLine("\r\n\"{0}\" is not a valid choice, valid keys are \"{1}\"", keyChar, allowedString);
                }
                else
                {
                    Console.WriteLine();
                }
            }
            while (!validKey);

            return keyChar;
        }

        /// <summary>
        /// The tokenize.
        /// </summary>
        /// <returns>
        /// A list of CommandArguments
        /// </returns>
        public static List<CommandArgument> Tokenize()
        {
            var tokenList = new List<CommandArgument>();

            if (string.IsNullOrWhiteSpace(Text))
            {
                return tokenList;
            }

            var nextPosition = 1;

            DumpTokens();

            tokenList.AddRange(
                from arg in Args
                let matches = RegexTokenize.Matches(arg)
                select matches.Count == 1
                           ? new CommandArgument(matches[0]) // Command argument
                           : new CommandArgument(arg, nextPosition++));

            return tokenList;
        }

        /// <summary>
        /// Try to parse the command line.
        /// </summary>
        /// <param name="arguments">
        /// The arguments.
        /// </param>
        /// <param name="exception">
        /// The exception.
        /// </param>
        /// <typeparam name="T">
        /// The command argument type
        /// </typeparam>
        /// <returns>
        /// True if the command line could be parsed, false if not.
        /// </returns>
        public static bool TryParse<T>(out T arguments, out Exception exception) where T : class, new()
        {
            try
            {
                arguments = Parse<T>();
                exception = null;
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                arguments = null;
                return false;
            }
        }

        /// <summary>
        /// The write line color.
        /// </summary>
        /// <param name="color">
        /// The color.
        /// </param>
        /// <param name="format">
        /// The format.
        /// </param>
        /// <param name="formatArgs">
        /// The format args.
        /// </param>
        public static void WriteLineColor(ConsoleColor color, string format, params object[] formatArgs)
        {
            var saveColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(format, formatArgs);
            Console.ForegroundColor = saveColor;
        }

        #endregion

        #region Methods

        /// <summary>
        /// The apply command argument.
        /// </summary>
        /// <param name="cmd">
        /// The cmd.
        /// </param>
        /// <param name="argument">
        /// The argument.
        /// </param>
        /// <exception cref="CommandLineArgumentInvalidException">
        /// The argument is invalid
        /// </exception>
        private static void ApplyCommandArgument(CommandArgument cmd, object argument)
        {
            var parameter = parameters.Get(cmd);

            // No command parameter matching this command switch or position
            if (parameter == null)
            {
                throw new CommandLineArgumentInvalidException(argument.GetType(), cmd);
            }

            parameter.SetValue(argument, cmd);
        }

        /// <summary>
        /// The dump tokens.
        /// </summary>
        [Conditional("DEBUG")]
        private static void DumpTokens()
        {
            Debug.WriteLine(string.Format("\r\nRegex Pattern <{0}>", TokenizePattern));

            for (var index = 0; index < Args.Length; index++)
            {
                var arg = Args[index];
                Debug.WriteLine(string.Format("\r\nTokenizing Args[{0}] Value: \"{1}\"", index, Args[index]));

                var matches = RegexTokenize.Matches(arg);

                for (var i = 0; i < matches.Count; i++)
                {
                    for (var j = 0; j < matches[i].Groups.Count; j++)
                    {
                        Debug.WriteLine(string.Format("Token[{0}].Groups[{1}] =\"{2}\"", i, RegexTokenize.GroupNameFromNumber(j), matches[i].Groups[j]));
                    }
                }
            }
        }

        /// <summary>
        /// Returns a string with the case sensitive option
        /// </summary>
        /// <returns>
        /// null when case sensitive is on, "-" when it is off 
        /// </returns>
        private static string GetCaseSensitiveOption()
        {
            return CaseSensitive ? null : "-";
        }

        /// <summary>
        /// The infer command line parameter attribute.
        /// </summary>
        /// <param name="property">
        /// The property.
        /// </param>
        /// <returns>
        /// Returns an array of command line parameters
        /// </returns>
        private static IEnumerable<CommandLineParameterAttribute> InferCommandLineParameterAttribute(PropertyInfo property)
        {
            return new[] { new CommandLineParameterAttribute { Name = property.Name, Command = property.Name } };
        }

        /// <summary>
        /// Initializes a new argument class
        /// </summary>
        /// <typeparam name="T">
        /// The type of the argument class
        /// </typeparam>
        /// <returns>
        /// An initialized command line argument
        /// </returns>
        private static T InitializeNewArgument<T>() where T : new()
        {
            parameters = new CommandLineParametersCollection(typeof(T));

            var argument = new T();

            foreach (var parameter in parameters.Values)
            {
                parameter.SetDefaultValue(argument);
            }

            return argument;
        }

        /// <summary>
        /// Creates a comma delimited list of allowed keys
        /// </summary>
        /// <param name="allowedKeys">
        /// The allowed keys.
        /// </param>
        /// <returns>
        /// The comma delimited list.
        /// </returns>
        private static string ToDelimitedList(char[] allowedKeys)
        {
            var sb = new StringBuilder();
            for (var index = 0; index < allowedKeys.Length; index++)
            {
                var allowedKey = allowedKeys[index];
                sb.Append(allowedKey);
                if (index + 1 < allowedKeys.Length)
                {
                    sb.Append(',');
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Returns a lower case char.
        /// </summary>
        /// <param name="keyChar">
        /// The key char.
        /// </param>
        /// <returns>
        /// The to lower.
        /// </returns>
        private static char ToLower(char keyChar)
        {
            return keyChar.ToString(CultureInfo.InvariantCulture).ToLowerInvariant()[0];
        }

        #endregion

        /// <summary>
        /// The command line parameters collection.
        /// </summary>
        private class CommandLineParametersCollection
        {
            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="CommandLineParametersCollection"/> class.
            /// </summary>
            /// <param name="argumentType">
            /// The argument type.
            /// </param>
            internal CommandLineParametersCollection(Type argumentType)
            {
                this.Parameters = new Dictionary<string, CommandLineParameter>();
                this.ArgumentType = argumentType;
                this.Load();
            }

            #endregion

            #region Public Properties

            /// <summary>
            /// Gets Values.
            /// </summary>
            public IEnumerable<CommandLineParameter> Values
            {
                get
                {
                    return this.Parameters.Values;
                }
            }

            #endregion

            #region Properties

            /// <summary>
            /// Gets or sets ArgumentType.
            /// </summary>
            private Type ArgumentType { get; set; }

            /// <summary>
            /// Gets or sets Parameters.
            /// </summary>
            private Dictionary<string, CommandLineParameter> Parameters { get; set; }

            #endregion

            #region Public Methods

            /// <summary>
            /// The get.
            /// </summary>
            /// <param name="cmd">
            /// The cmd.
            /// </param>
            /// <returns>
            /// </returns>
            public CommandLineParameter Get(CommandArgument cmd)
            {
                CommandLineParameter parameter;

                this.Parameters.TryGetValue(cmd.Key, out parameter);

                return parameter;
            }

            /// <summary>
            /// The verify required arguments.
            /// </summary>
            /// <exception cref="CommandLineRequiredArgumentMissingException">
            /// </exception>
            public void VerifyRequiredArguments()
            {
                foreach (var parameter in this.Values.Where(parameter => !parameter.RequiredArgumentSupplied))
                {
                    throw new CommandLineRequiredArgumentMissingException(
                        this.ArgumentType, parameter.Attribute.NameOrCommand, parameter.Attribute.ParameterIndex);
                }
            }

            #endregion

            #region Methods

            /// <summary>
            /// The is parameter.
            /// </summary>
            /// <param name="parameter">
            /// The parameter.
            /// </param>
            /// <returns>
            /// The is parameter.
            /// </returns>
            private static bool IsParameter(CommandLineParameter parameter)
            {
                return parameter.IsParameter();
            }

            /// <summary>
            /// The parameter index.
            /// </summary>
            /// <param name="parameter">
            /// The parameter.
            /// </param>
            /// <returns>
            /// The parameter index.
            /// </returns>
            private static int ParameterIndex(CommandLineParameter parameter)
            {
                return parameter.Attribute.ParameterIndex;
            }

            /// <summary>
            /// The add.
            /// </summary>
            /// <param name="parameter">
            /// The parameter.
            /// </param>
            /// <exception cref="CommandLineException">
            /// </exception>
            private void Add(CommandLineParameter parameter)
            {
                // Each attribute is uniquely keyed
                try
                {
                    this.Parameters.Add(parameter.Key, parameter);
                }
                catch (ArgumentException exception)
                {
                    throw new CommandLineException(
                        new CommandArgumentHelp(
                            parameter.Property.DeclaringType, 
                            parameter.IsCommand()
                                ? string.Format("Duplicate Command \"{0}\"", parameter.Command)
                                : string.Format(
                                    "Duplicate Parameter Index [{0}] on Property \"{1}\"", parameter.Attribute.ParameterIndex, parameter.Property.Name)), 
                        exception);
                }
            }

            /// <summary>
            /// The load.
            /// </summary>
            private void Load()
            {
                // Select all the CommandLineParameterAttribute attributes from all the properties on the type and create a command line parameter for it
                CommandLineParameterAttribute.ForEach(this.ArgumentType, this.Add);

                this.VerifyPositionalArgumentsInSequence();

                // If there are no attributed properties
                if (this.Parameters.Count == 0)
                {
                    // infer them based on the property names
                    CommandLineParameterAttribute.ForEach(this.ArgumentType, InferCommandLineParameterAttribute, this.Add);
                }
            }

            /// <summary>
            /// The verify positional arguments in sequence.
            /// </summary>
            /// <exception cref="CommandLineException">
            /// </exception>
            private void VerifyPositionalArgumentsInSequence()
            {
                // Get the positional arguments ordered by position
                var parameters = this.Parameters.Values.Where(IsParameter).OrderBy(ParameterIndex);

                for (var i = 0; i < parameters.Count(); i++)
                {
                    var arg = parameters.ElementAt(i);

                    // Parameter Indexes are 1 based so add 1 to i
                    var expectedIndex = i + 1;
                    if (arg.Attribute.ParameterIndex != expectedIndex)
                    {
                        throw new CommandLineException(
                            new CommandArgumentHelp(
                                arg.Property.DeclaringType, 
                                string.Format(
                                    "Out of order parameter \"{0}\" should have be at parameter index {1} but was found at {2}", 
                                    arg.Attribute.Name, 
                                    expectedIndex, 
                                    arg.Attribute.ParameterIndex)));
                    }
                }
            }

            #endregion
        }
    }
}