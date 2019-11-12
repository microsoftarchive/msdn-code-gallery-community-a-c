namespace CmdLine
{
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    ///   Represents a command line argument
    /// </summary>
    public class CommandArgument
    {
        private const int TokenGroup = 0;

        private int parameterNumber = -1;

        private string value;

        /// <summary>
        ///   Initializes a CommandArgument from a Regex match
        /// </summary>
        /// <param name = "match"></param>
        public CommandArgument(Match match)
        {
            this.Token = GetGroupValue(match, TokenGroup);
            this.SwitchSeparator = GetGroupValue(match, CommandLine.SwitchSeparatorGroup);
            this.Command = GetGroupValue(match, CommandLine.SwitchNameGroup);
            this.SwitchOption = GetGroupValue(match, CommandLine.SwitchOptionGroup);
            this.Value = GetGroupValue(match, CommandLine.ValueGroup);
        }

        public CommandArgument(string token, int parameterIndex)
        {
            this.Token = token;
            this.ParameterNumber = parameterIndex;
        }

        public string SwitchOption { get; set; }

        public string Token { get; set; }

        public string SwitchSeparator { get; set; }

        public string Command { get; set; }

        public string Value
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.value) && this.ParameterNumber != -1
                           ? this.Token
                           : this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public int ParameterNumber
        {
            get
            {
                return this.parameterNumber;
            }
            set
            {
                this.parameterNumber = value;
            }
        }

        /// <summary>
        ///   Returns the value used by the property cache for the key
        /// </summary>
        /// <remarks>
        ///   If the Command property has a value use that, otherwise use the formatted position value
        /// </remarks>
        internal string Key
        {
            get
            {
                return this.IsParameter()
                           ? CommandLineParameterAttribute.GetParameterKey(this.ParameterNumber)
                           : CommandLine.CaseSensitive ? this.Command : this.Command.ToLowerInvariant();
            }
        }

        public bool IsCommand()
        {
            return !string.IsNullOrWhiteSpace(this.Command);
        }

        public bool IsParameter()
        {
            return !this.IsCommand();
        }

        private static string GetGroupValue(Match match, string group)
        {
            return match.Groups[group].Success
                       ? match.Groups[group].Value.Trim()
                       : null;
        }

        private static string GetGroupValue(Match match, int group)
        {
            return match.Groups[group].Success
                       ? match.Groups[group].Value.Trim()
                       : null;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder("CommandArgument");

            this.AppendProperty(stringBuilder, "Token");
            this.AppendProperty(stringBuilder, "Command");
            this.AppendProperty(stringBuilder, "SwitchSeparator");
            this.AppendProperty(stringBuilder, "SwitchOption");
            this.AppendProperty(stringBuilder, "Value");
            this.AppendProperty(stringBuilder, "ParameterNumber");

            return stringBuilder.ToString();
        }

        private void AppendProperty(StringBuilder stringBuilder, string propertyName)
        {
            var property = this.GetType().GetProperty(propertyName);
            var propValue = property.GetValue(this, null);

            stringBuilder.AppendFormat(" {0}: \"{1}\"", propertyName, propValue);
        }
    }
}