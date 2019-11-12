using System;

namespace ExcelOperations
{
    public class ExaminerEventArgs : EventArgs
    {
        public ExaminerEventArgs(string message)
        {
            StatusMessage = message;
        }

        public string StatusMessage { get; set; }
    }
}
