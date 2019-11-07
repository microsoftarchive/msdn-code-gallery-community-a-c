// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeWithUpperAndLower.cs" company="">
//   
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CmdLine.Tests
{
    /// <summary>
    /// The type with upper and lower.
    /// </summary>
    public class TypeWithUpperAndLower
    {
        #region Public Properties

        /// <summary>
        ///   Gets or sets Lower.
        /// </summary>
        [CommandLineParameter("t")]
        public string Lower { get; set; }

        /// <summary>
        ///   Gets or sets Upper.
        /// </summary>
        [CommandLineParameter("T")]
        public string Upper { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether YLower.
        /// </summary>
        [CommandLineParameter("y")]
        public bool YLower { get; set; }

        /// <summary>
        ///   Gets or sets a value indicating whether YUpper.
        /// </summary>
        [CommandLineParameter("Y")]
        public bool YUpper { get; set; }

        #endregion
    }
}