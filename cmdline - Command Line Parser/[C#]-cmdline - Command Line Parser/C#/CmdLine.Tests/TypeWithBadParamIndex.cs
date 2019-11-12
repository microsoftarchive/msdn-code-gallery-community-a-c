// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeWithBadParamIndex.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CmdLine.Tests
{
    /// <summary>
    /// The type with bad param index.
    /// </summary>
    public class TypeWithBadParamIndex
    {
        #region Public Properties

        /// <summary>
        ///   Gets or sets S1.
        /// </summary>
        [CommandLineParameter(ParameterIndex = -1)]
        public string S1 { get; set; }

        #endregion
    }
}