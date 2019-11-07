using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocalizeDataAnnotations.Infrastructure
{
    public class CustomRequiredAttribute: RequiredAttribute
    {

        public override string FormatErrorMessage(string name)
        {
            string errorMessage = null;
            if (!string.IsNullOrEmpty(base.ErrorMessageResourceName))
                errorMessage = TextosBBDD.Recuperar(base.ErrorMessageResourceName);

            return errorMessage ?? base.FormatErrorMessage(name);
        }

    }
}