using System;
using System.Diagnostics;

namespace ExcelOperations
{
    public class ExceptionInformation
    {
        /// <summary>
        /// Indicates if the sheet was in the workbook
        /// </summary>
        public bool SheetNotFound { get; set; }

        public bool CreatedSheet { get; set; }
        /// <summary>
        /// Indicates if the file was available
        /// </summary>
        public bool FileNotFound { get; set; }
        /// <summary>
        /// Indicates an exception may have been thrown outside assertion
        /// </summary>
        public bool UnKnownException { get; set; }
        /// <summary>
        /// Message to go along with an exception either by objects called
        /// or user defined e.g. cells array was null.
        /// </summary>
        public string Message { get; set; }
        [DebuggerStepThrough()]
        public override string ToString()
        {
            var msg = string.IsNullOrWhiteSpace(Message) ? "None" : Message;
            return $"File not exist: {FileNotFound}{Environment.NewLine}Sheet not exists: {SheetNotFound}{Environment.NewLine}Message: '{msg}'";
        }
    }
}
