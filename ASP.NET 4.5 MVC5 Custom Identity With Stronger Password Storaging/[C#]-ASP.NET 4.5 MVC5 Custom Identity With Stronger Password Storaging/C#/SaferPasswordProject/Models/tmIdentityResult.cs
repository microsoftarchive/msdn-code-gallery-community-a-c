using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace Models
{
    public class tmIdentityResult
    {
        public tmIdentityResult(IEnumerable<string> errors)
        {
            if (errors != null && errors.Count() > 0)
            {
                Errors = errors;
                Succeeded = false;
            }
            else
            {
                Errors = new List<string> { };
                Succeeded = true;
            }
        }
        //
        // Summary:
        //     Failure constructor that takes error messages
        public tmIdentityResult(params string[] errors) : this(errors.ToList()) { }

        // Summary:
        //     List of errors
        public IEnumerable<string> Errors { get; private set; }
        public bool Succeeded { get; private set; }
    }
}