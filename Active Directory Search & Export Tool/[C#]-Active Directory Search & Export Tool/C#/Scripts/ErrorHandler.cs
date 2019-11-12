using System;
using System.Windows.Forms;

// <summary> 
// This namespaces if for generic application classes
// </summary>
namespace ADSearch.Scripts
{
    /// <summary> 
    /// Used to handle exceptions
    /// </summary>
    public class ErrorHandler
    {

        /// <summary> 
        /// Used to produce an error message and create a log record
        /// </summary>
        /// <param name="ex">Represents errors that occur during application execution.</param>
        /// <param name="isSilent">Used to show a message to the user and log an error record or just log a record.</param>
        /// <remarks></remarks>
        public static void DisplayMessage(Exception ex, Boolean isSilent = false)
        {
            System.Diagnostics.StackFrame sf = new System.Diagnostics.StackFrame(1);
            System.Reflection.MethodBase caller = sf.GetMethod();
            string currentProcedure = (caller.Name).Trim();
            string errorMessageDescription = ex.ToString();
            errorMessageDescription = System.Text.RegularExpressions.Regex.Replace(errorMessageDescription, @"\r\n+", " "); //the carriage returns were messing up my log file
            string msg = "Contact your system administrator. A record has been created in the log file." + Environment.NewLine;
            msg += "Procedure: " + currentProcedure + Environment.NewLine;
            msg += "Description: " + ex.ToString() + Environment.NewLine;
            //Console.WriteLine(msg);
            //Clipboard.SetText(ex.ToString());
            if (isSilent == false)
            {
                MessageBox.Show(msg, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}