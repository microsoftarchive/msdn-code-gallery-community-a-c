using CustomAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace CustomAnnotationsWeb.Models
{
    public class RequiredIfModel
    {
        [Range(0, 120)]
        public int Age { get; set; }

        [RequiredIf("Age", 18, ValueComparison.IsLessThan, ErrorMessage = "If age is under 18, the name of the guardian must be set.")]
        public string GuardianName { get; set; }
    }
}