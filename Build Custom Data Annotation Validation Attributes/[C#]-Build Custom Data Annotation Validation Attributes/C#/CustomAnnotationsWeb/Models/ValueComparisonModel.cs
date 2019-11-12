using CustomAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomAnnotationsWeb.Models
{
    public class ValueComparisonModel
    {
        [ValueComparisonAttribute("Max", ValueComparison.IsLessThan, ErrorMessage = "Min must be less than Max.")]
        public int Min { get; set; }

        [ValueComparison("Min", ValueComparison.IsGreaterThan, ErrorMessage = "Max must be greater than Min.")]
        public int Max { get; set; }

        [ValueComparison("Max", ValueComparison.IsNotEqual, ErrorMessage = "Default can not be Max.")]
        public int Default { get; set; }
    }
}