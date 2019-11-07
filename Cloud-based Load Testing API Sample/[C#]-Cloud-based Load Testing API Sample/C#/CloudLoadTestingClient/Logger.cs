using System;
using System.Diagnostics;
using System.Globalization;

namespace CloudLoadTestingClient
{
    class Logger
    {
        public static void LogMessage(string message)
        {
            Trace.WriteLine(message);
            Console.WriteLine(message);
        }

        public static void LogMessage(string message, params object[] args)
        {
            var msg = string.Format(CultureInfo.CurrentCulture, message, args);
            LogMessage(msg);
        }
    }
}
