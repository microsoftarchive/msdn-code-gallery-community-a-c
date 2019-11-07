using System;
using System.ComponentModel.DataAnnotations;

namespace CustomAnnotations
{
    /// <summary>
    /// Validation attribute to compare values of objects that implement <see cref="IComparable"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class ValueComparisonAttribute : PropertyValidationAttribute
    {
        #region Fields

        private readonly ValueComparison comparison;
        private readonly ValidationResult failure;
        private readonly ValidationResult success;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes new instance of the <see cref="ValueComparisonAttribute"/> class.
        /// </summary>
        /// <param name="otherProperty">The name of the other property.</param>
        /// <param name="comparison">The <see cref="ValueComparison"/> to perform between values.</param>
        public ValueComparisonAttribute(string propertyName, ValueComparison comparison)
            : base(propertyName)
        {
            this.comparison = comparison;
            this.failure = new ValidationResult(String.Empty);
            this.success = ValidationResult.Success;
        }

        #endregion

        #region Methods

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                IComparable comparable = value as IComparable;

                if (comparable == null)
                    throw new InvalidOperationException("The comparison value must implement System.IComparable interface.");

                object otherValue = GetValue(validationContext);

                int result = comparable.CompareTo(otherValue);

                return Compare(result);
            }

            return success;
        }

        private ValidationResult Compare(int comparisonResult)
        {
            switch (comparison)
            {
                case ValueComparison.IsEqual:
                    if (comparisonResult == 0)
                    {
                        return success;
                    }
                    break;
                case ValueComparison.IsNotEqual:
                    if (comparisonResult != 0)
                    {
                        return success;
                    }
                    break;
                case ValueComparison.IsLessThan:
                    if (comparisonResult < 0)
                    {
                        return success;
                    }
                    break;
                case ValueComparison.IsGreaterThan:
                    if (comparisonResult > 0)
                    {
                        return success;
                    }
                    break;
                case ValueComparison.IsLessThanOrEqual:
                    if (comparisonResult < 0 || comparisonResult == 0)
                    {
                        return success;
                    }
                    break;
                case ValueComparison.IsGreaterThanOrEqual:
                    if (comparisonResult > 0 || comparisonResult == 0)
                    {
                        return success;
                    }
                    break;
            }

            return failure;
        }

        #endregion
    }
}
