// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestArgsWithList.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CmdLine.Tests
{
    using System.Collections.Generic;

    /// <summary>
    /// The test args with list.
    /// </summary>
    public class TestArgsWithList
    {
        #region Public Properties

        /// <summary>
        ///   Gets or sets NList.
        /// </summary>
        [CommandLineParameter(Command = "N")]
        public List<string> NList { get; set; }

        #endregion
    }
}