// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeWithDuplicateParamIndex.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CmdLine.Tests
{
    /// <summary>
    /// The type with duplicate param index.
    /// </summary>
    public class TypeWithDuplicateParamIndex
    {
        #region Public Properties

        /// <summary>
        ///   Gets or sets S1.
        /// </summary>
        [CommandLineParameter(ParameterIndex = 1)]
        public string S1 { get; set; }

        /// <summary>
        ///   Gets or sets S2.
        /// </summary>
        [CommandLineParameter(ParameterIndex = 1)]
        public string S2 { get; set; }

        #endregion
    }
}