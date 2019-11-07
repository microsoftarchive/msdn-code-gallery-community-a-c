using System;
using System.Collections.Generic;
using System.Collections;

namespace App.Common
{
    public class TransactionStatus
    {
        public bool Status { get; set; }
        public List<String> ReturnMessage { get; set; }
        public List<Error> Errors;
        public string ErrorType { get; set; }

        public TransactionStatus()
        {
            ReturnMessage = new List<String>();
            Status = true;
            Errors = new List<Error>();
        }
    }
}
