using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Exchange.WebServices.Data;
using System.Diagnostics;

namespace AppHelpers
{

    public class InMemoryListener : ITraceListener
    {
        public string LogText = string.Empty;

        public void Trace(string traceType, string traceMessage)
        {

            StringBuilder oSB = new StringBuilder();
            oSB.Append(LogText);
            oSB.Append("[");
            oSB.Append(traceType);
            oSB.Append("]-----------");
            oSB.Append(DateTime.Now.ToString());
            oSB.Append("------------------\r\n\r\n");

            oSB.Append(traceMessage);
            oSB.Append("\r\n------------------------------------------------------------------------------\r\n\r\n");
            LogText = oSB.ToString();
            oSB = null;

        }

        public void Write(string traceMessage)
        {
            StringBuilder oSB = new StringBuilder();
            oSB.Append(LogText);
            oSB.Append(traceMessage);
            //Debug.Write(traceMessage);
            LogText = oSB.ToString();
            oSB = null;
        }

        public void WriteLine(string traceMessage)
        {
            StringBuilder oSB = new StringBuilder();
            oSB.Append(LogText);
            oSB.Append(traceMessage);
            oSB.Append("\r\n");
            //Debug.WriteLine(message);
            LogText = oSB.ToString();
            oSB = null;
        }

        public void WriteLine(string name, object value)
        {
            StringBuilder oSB = new StringBuilder();
            oSB.Append(LogText);

            oSB.Append(name);
            oSB.Append("\r\n");
            //Debug.WriteLine(message);
            oSB = null;
            oSB.Append(name);
            oSB.Append(" = ");            
            if (value != null)
            {
                oSB.Append(value.ToString());
                oSB.Append("\r\n");
                //System.Console.WriteLine(name + "=" + value.ToString());
            }

            oSB.Append("\r\n");
            LogText = oSB.ToString();
            oSB = null;
        }

    }


}
