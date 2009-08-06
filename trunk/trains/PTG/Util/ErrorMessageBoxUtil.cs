using System;
using System.Windows.Forms;

namespace PeriodicTimetableGeneration.Util
{

    /// <summary>
    /// Helper for GUI.
    /// </summary>
    public static class ErrorMessageBoxUtil
    {

        /// <summary>
        /// Shows the error message in the message box.
        /// </summary>
        /// <param name="message">Message to be shown.</param>
        public static void ShowError(string message)
        {
            ShowError(message, "Error occured.");
        }

        /// <summary>
        /// Shows the error message in the message box.
        /// </summary>
        /// <param name="e">Message of the exception will be shown.</param>
        public static void ShowError(Exception e)
        {
            ShowError(e.Message, "Error occured.");
        }

        /// <summary>
        /// Shows the error message in the message box.
        /// </summary>
        /// <param name="message">Message to be shown.</param>
        /// <param name="caption">Caption of the message.</param>
        public static void ShowError(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

    }

}
