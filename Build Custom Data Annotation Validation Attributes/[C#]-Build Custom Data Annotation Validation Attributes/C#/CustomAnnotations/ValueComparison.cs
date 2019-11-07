using System;

namespace CustomAnnotations
{
    /// <summary>
    /// Defines supported comparisons between values.
    /// </summary>
    public enum ValueComparison : int
    {
        /// <summary>
        /// Values are compared to be equal.
        /// </summary>
        IsEqual = 0,

        /// <summary>
        /// Values are compared to be inequal.
        /// </summary>
        IsNotEqual = 1,

        /// <summary>
        /// Value is compared to be greater than other value.
        /// </summary>
        IsGreaterThan = 2,

        /// <summary>
        /// Value is compared to be greater than or equal to other value.
        /// </summary>
        IsGreaterThanOrEqual = 3,

        /// <summary>
        /// Value is compared to be less than other value.
        /// </summary>
        IsLessThan = 4,

        /// <summary>
        /// Value is compared to be less than or equal to other value.
        /// </summary>
        IsLessThanOrEqual = 5
    }
}
