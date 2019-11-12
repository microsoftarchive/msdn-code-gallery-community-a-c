using System;
using System.Windows.Forms;

namespace DesktopLibrary
{
    /// <summary>
    /// Contains wrappers for MessageBox
    /// </summary>
    public static class Dialogs
    {
        /// <summary>
        /// Ask a question with No as the default button
        /// </summary>
        /// <param name="pMessage"></param>
        /// <param name="pTitle">Title which defaults to 'Question'</param>
        /// <returns></returns>
        public static bool Question(string pMessage, string pTitle = "Question")
        {
            return (MessageBox.Show(pMessage, pTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes);
        }
        /// <summary>
        /// Ask a question with the ability to define the default button to Yes or No
        /// </summary>
        /// <param name="pMessage"></param>
        /// <param name="pTitle">Title for message box</param>
        /// <param name="pDefaultButton"></param>
        /// <returns></returns>
        public static bool Question(string pMessage, string pTitle, DialogResult pDefaultButton)
        {
            MessageBoxDefaultButton button = 0;
            if (pDefaultButton == DialogResult.No)
            {
                button = MessageBoxDefaultButton.Button2;
            }

            return (MessageBox.Show(pMessage, pTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, button) == DialogResult.Yes);
        }
        /// <summary>
        /// Display a dialog which uses the Error icon, user supplied message and title.
        /// </summary>
        /// <param name="pMessage"></param>
        /// <param name="pTitle"></param>
        public static void ExceptionDialog(string pMessage, string pTitle = "Error")
        {
            MessageBox.Show(pMessage, pTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ExceptionDialog(string pMessage, string pTitle, Exception pException)
        {
            MessageBox.Show($"{pMessage}{Environment.NewLine} {pException.Message}", pTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Display an exception message along with user text.
        /// </summary>
        /// <param name="pException">A valid exception object</param>
        /// <param name="pMessage"></param>
        /// <param name="pTitle"></param>
        public static void ExceptionDialog(Exception pException, string pMessage, string pTitle = "Encountered a problem")
        {
            MessageBox.Show($"{pMessage}{Environment.NewLine}{pException.Message}", pTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// For quick use when debugging
        /// </summary>
        /// <param name="pException">A valid exception object</param>
        public static void ExceptionDialog(Exception pException)
        {
            MessageBox.Show(pException.Message);
        }
        /// <summary>
        /// Display a message box with the proper icon
        /// </summary>
        /// <param name="pMessage"></param>
        /// <param name="pTitle"></param>
        public static void InformationDialog(string pMessage, string pTitle = "Information")
        {
            MessageBox.Show(pMessage, pTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
