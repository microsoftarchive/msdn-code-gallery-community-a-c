using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace App.Common
{
    public class Error
    {

        public string AlertType { get; set; }
        public string ControlName { get; set; }
        public string Message { get; set; }


    }
   public static class GenerateErrorMessage
    {
       public static List<Error> Built(IList<ValidationFailure> failiureResult)
       {
           return failiureResult.Select(failiure => new Error()
           {
               AlertType = "",
               ControlName = failiure.PropertyName,
               Message = failiure.ErrorMessage
           }).ToList();
       }
    }
}
