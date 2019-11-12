using System;
using System.Diagnostics.Contracts;

namespace MsdrRu.CodeDiff
{
    public class Line
    {
        public Line(ulong? lineNumber = null)
        {
            Contract.Requires<ArgumentException>(lineNumber == null || lineNumber > 0);

            this.OriginalLineNumber = lineNumber;
            //this.OriginalLineNumber = originalLineNumber;
        }

        //public ulong LineNumber { get; }

        public ulong? OriginalLineNumber { get; }

        public string Content { get; set; }

        public LineStatus? Status { get; set; }

        public Line Next { get; set; }

        public Line Previous { get; set; }

        public Line Related { get; set; }
    }
}
