using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EvalMaterial.ViewModels
{
    public class EvaluationDateGroup
    {
        public int MaterialID { get; set; }
        public string MaterialName { get; set; }
        public int EvaluationCount { get; set; }
    }
}