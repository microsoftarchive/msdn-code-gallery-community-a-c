using CustomAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomAnnotationsWeb.Models
{
    public class DateTimeModel
    {
        [DateTimeCompare("EndDate", ValueComparison.IsLessThan, ErrorMessage = "Start date must be earlier than end date.")]
        public DateTime? StartDate { get; set; }

        [DateTimeCompare("StartDate", ValueComparison.IsGreaterThan, ErrorMessage = "End date must be later than start date.")]
        public DateTime? EndDate { get; set; }
    }
}