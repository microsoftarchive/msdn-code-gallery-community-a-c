using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Diagnostics;
using zSiS.AlwaysOnService.Enums;

namespace zSiS.AlwaysOnService.Helpers
{
    /// <summary>
    /// Contains all logging methods
    /// </summary>
    public class LoggingHelper
    {
        /// <summary>
        /// Log an error
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="message"></param>
        public static void Error(string methodName, string message)
        {
            var oldc = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(methodName + " - " + message);
            Console.ForegroundColor = oldc;

            LogEntry logEntry =
                new LogEntry()
                {
                    Categories = new string[] { Enumerations.LoggingCategory.Error.ToString() },
                    Message = message,
                    Severity = TraceEventType.Error,
                    Title = methodName
                };

            Logger.Write(logEntry);
        }

        /// <summary>
        /// Logs an exception
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="exception"></param>
        public static void Exception(string methodName, Exception exception)
        {
            var oldc = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(methodName + " - " + exception.ToString());
            Console.ForegroundColor = oldc;

            LogEntry logEntry =
                new LogEntry()
                {
                    Categories = new string[] { Enumerations.LoggingCategory.Exception.ToString() },
                    Message = exception.ToString(),
                    Severity = TraceEventType.Critical,
                    Title = methodName
                };

            logEntry.ExtendedProperties.Add("StackTrace", exception.StackTrace);
            Logger.Write(logEntry);
        }

        /// <summary>
        /// Logs an information
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="message"></param>
        public static void Information(string methodName, string message)
        {
            var oldc = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(methodName + " - " + message);
            Console.ForegroundColor = oldc;

            LogEntry logEntry =
                new LogEntry()
                {
                    Categories = new string[] { Enumerations.LoggingCategory.Information.ToString() },
                    Message = message,
                    Severity = TraceEventType.Information,
                    Title = methodName
                };

            Logger.Write(logEntry);
        }

        /// <summary>
        /// Logs a trace
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="message"></param>
        public static void Trace(string methodName, string message)
        {
            Console.WriteLine(methodName + " - " + message);

            LogEntry logEntry =
                new LogEntry()
                {
                    Categories = new string[] { Enumerations.LoggingCategory.Trace.ToString() },
                    Message = message,
                    Severity = TraceEventType.Verbose,
                    Title = methodName
                };

            Logger.Write(logEntry);
        }

        /// <summary>
        /// Logs a warning
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="message"></param>
        public static void Warning(string methodName, string message)
        {
            var oldc = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(methodName + " - " + message);
            Console.ForegroundColor = oldc;

            LogEntry logEntry =
                new LogEntry()
                {
                    Categories = new string[] { Enumerations.LoggingCategory.Warning.ToString() },
                    Message = message,
                    Severity = TraceEventType.Warning,
                    Title = methodName
                };

            Logger.Write(logEntry);
        }
    }
}
