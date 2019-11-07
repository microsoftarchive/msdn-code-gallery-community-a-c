// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommandLineParameterAttribute.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CmdLine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// The command line parameter attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class CommandLineParameterAttribute : Attribute
    {
        #region Constants and Fields

        /// <summary>
        /// The parameter index.
        /// </summary>
        private int parameterIndex = -1;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLineParameterAttribute"/> class.
        /// </summary>
        public CommandLineParameterAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandLineParameterAttribute"/> class.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        public CommandLineParameterAttribute(string command)
        {
            this.Command = command;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets Command.
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// Gets or sets Default.
        /// </summary>
        public object Default { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///  Gets or sets The Resource ID of the description
        /// </summary>
        public string DescriptionId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsHelp.
        /// </summary>
        public bool IsHelp { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets NameOrCommand.
        /// </summary>
        public string NameOrCommand
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.Name) ? this.Command : this.Name;
            }
        }

        /// <summary>
        /// Gets or sets ParameterIndex.
        /// </summary>
        /// <exception cref="CommandLineException">
        /// Invalid parameter index
        /// </exception>
        public int ParameterIndex
        {
            get
            {
                return this.parameterIndex;
            }

            set
            {
                if (value < 1)
                {
                    throw new CommandLineException("Invalid ParameterNumber value ");
                }

                this.parameterIndex = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether Required.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// Gets or sets Value.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets ValueExample.
        /// </summary>
        public string ValueExample { get; set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="member">
        /// The member.
        /// </param>
        /// <returns>
        /// The command line parameter attribute
        /// </returns>
        public static CommandLineParameterAttribute Get(MemberInfo member)
        {
            return GetCustomAttributes(member, typeof(CommandLineParameterAttribute)).Cast<CommandLineParameterAttribute>().FirstOrDefault();
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <param name="member">
        /// The member.
        /// </param>
        /// <returns>
        /// The custom attributes
        /// </returns>
        public static IEnumerable<CommandLineParameterAttribute> GetAll(MemberInfo member)
        {
            return GetCustomAttributes(member, typeof(CommandLineParameterAttribute)).Cast<CommandLineParameterAttribute>();
        }

        /// <summary>
        /// The get all property parameters.
        /// </summary>
        /// <param name="argumentClassType">
        /// The argument class type.
        /// </param>
        /// <returns>
        /// All property parameters
        /// </returns>
        public static IEnumerable<CommandLineParameterAttribute> GetAllPropertyParameters(Type argumentClassType)
        {
            return
                argumentClassType.GetProperties().SelectMany(
                    property => property.GetCustomAttributes(typeof(CommandLineParameterAttribute), true).Cast<CommandLineParameterAttribute>());
        }

        /// <summary>
        /// The is command.
        /// </summary>
        /// <returns>
        /// True if a command
        /// </returns>
        public bool IsCommand()
        {
            return !string.IsNullOrWhiteSpace(this.Command);
        }

        /// <summary>
        /// The is parameter.
        /// </summary>
        /// <returns>
        /// True if a parameter
        /// </returns>
        public bool IsParameter()
        {
            return !this.IsCommand();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Searches a type for all properties with the CommandLineParameterAttribute and does action
        /// </summary>
        /// <param name="argumentType">
        /// The argument type 
        /// </param>
        /// <param name="action">
        /// The action to apply 
        /// </param>
        internal static void ForEach(Type argumentType, Action<CommandLineParameter> action)
        {
            ForEach(argumentType, GetAll, action);
        }

        /// <summary>
        /// Searches a type for all properties with the CommandLineParameterAttribute and does action
        /// </summary>
        /// <param name="argumentType">
        /// The argument type 
        /// </param>
        /// <param name="selector">
        /// </param>
        /// <param name="action">
        /// The action to apply 
        /// </param>
        internal static void ForEach(
            Type argumentType, Func<PropertyInfo, IEnumerable<CommandLineParameterAttribute>> selector, Action<CommandLineParameter> action)
        {
            foreach (
                var parameter in
                    argumentType.GetProperties().SelectMany(
                        property => selector(property).Select(cmdAttribute => new CommandLineParameter(property, cmdAttribute))))
            {
                action(parameter);
            }
        }

        /// <summary>
        /// The get parameter key.
        /// </summary>
        /// <param name="position">
        /// The position.
        /// </param>
        /// <returns>
        /// The get parameter key.
        /// </returns>
        internal static string GetParameterKey(int position)
        {
            return string.Format("Parameter[{0}]", position);
        }

        /// <summary>
        /// The validate.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <exception cref="CommandLineException">
        /// </exception>
        internal void Validate(CommandLineParameter parameter)
        {
            if (this.ParameterIndex < 1)
            {
                throw new CommandLineException(
                    new CommandArgumentHelp(parameter.Property, string.Format("Invalid ParameterNumber value on Property \"{0}\"", parameter.Property.Name)));
            }
        }

        #endregion
    }
}