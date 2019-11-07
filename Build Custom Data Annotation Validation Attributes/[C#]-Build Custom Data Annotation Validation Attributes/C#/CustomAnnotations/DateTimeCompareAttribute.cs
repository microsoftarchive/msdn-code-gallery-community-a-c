using System;
using System.ComponentModel.DataAnnotations;

namespace CustomAnnotations
{
    /// <summary>
    /// Validation attribute to validate two <see cref="DateTime"/> values.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class DateTimeCompareAttribute : PropertyValidationAttribute
    {
        #region Fields

        private readonly ValueComparison comparison;
        private readonly ValidationResult failure;
        private readonly ValidationResult success;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes new instance of the <see cref="DateTimeCompareAttribute"/> class.
        /// </summary>
        /// <param name="otherProperty">The name of the other property.</param>
        /// <param name="comparison">The <see cref="ValueComparison"/> to perform between values.</param>
        public DateTimeCompareAttribute(string otherProperty, ValueComparison comparison)
            : base(otherProperty)
        {
            if (!Enum.IsDefined(typeof(ValueComparison), comparison))
                throw new ArgumentException("Undefined value.", "comparison");

            this.comparison = comparison;
            this.success = ValidationResult.Success;
            this.failure = new ValidationResult(String.Empty);
        }

        #endregion

        #region Overrides

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime? date = GetDate(value);

                if (date.HasValue)
                {
                    return IsValid(date.Value, validationContext);
                }
            }

            return success;
        }

        #endregion

        #region Methods

        private DateTime? GetDate(object value)
        {
            DateTime? date = null;

            if (value is DateTime)
            {
                date = (DateTime)value;
            }
            else if (value is DateTime?)
            {
                date = (DateTime?)value;
            }

            return date;
        }

        private ValidationResult IsValid(DateTime value, ValidationContext validationContext)
        {
            object otherValue = GetValue(validationContext);

            if (otherValue != null)
            {
                DateTime? otherDate = GetDate(otherValue);

                if (otherDate.HasValue)
                {
                    return IsValid(value, otherDate.Value);
                }
            }

            return success;
        }

        private ValidationResult IsValid(DateTime value, DateTime otherValue)
        {
            switch (comparison)
            {
                case ValueComparison.IsEqual:
                    if (value != otherValue)
                    {
                        return failure;
                    }
                    break;
                case ValueComparison.IsNotEqual:
                    if (value == otherValue)
                    {
                        return failure;
                    }
                    break;
                case ValueComparison.IsGreaterThan:
                    if (value <= otherValue)
                    {
                        return failure;
                    }
                    break;
                case ValueComparison.IsGreaterThanOrEqual:
                    if (value < otherValue)
                    {
                        return failure;
                    }
                    break;
                case ValueComparison.IsLessThan:
                    if (value >= otherValue)
                    {
                        return failure;
                    }
                    break;
                case ValueComparison.IsLessThanOrEqual:
                    if (value > otherValue)
                    {
                        return failure;
                    }
                    break;
            }

            return success;
        }

        #endregion
    }
}
