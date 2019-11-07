using System;
using System.Runtime.InteropServices;

namespace Microsoft.Net.BITS
{
	using Interop;

	/// <summary>
    /// Exceptions specific to BITS
    /// </summary>
    public class BackgroundCopyException : Exception
    {
        const string unkErr = "Unknown";

        int code;
        BackgroundCopyErrorContext ctx;
        string ctxDesc, errDesc, protocol;
        IBackgroundCopyFile iVal;

        internal BackgroundCopyException(IBackgroundCopyError err)
        {
            const uint lang = 0x1; // LANG_NEUTRAL, SUBLANG_DEFAULT
            err.GetError(out ctx, out code);
            try { err.GetErrorContextDescription(lang, out ctxDesc); }
            catch { ctxDesc = unkErr; }
            try { err.GetErrorDescription(lang, out errDesc); }
            catch { errDesc = unkErr; }
            err.GetProtocol(out protocol);
            err.GetFile(out iVal);
        }

        internal BackgroundCopyException(COMException cex)
        {
            code = cex.ErrorCode;
            errDesc = BackgroundCopyManager.GetErrorMessage(code);
            if (errDesc == null)
            {
                Marshal.ThrowExceptionForHR(code);
            }
        }

        /// <summary>
        /// Context in which the error occurred.
        /// </summary>
        public BackgroundCopyErrorContext Context
        {
            get { return ctx; }
        }

        /// <summary>
        /// Description of the context in which the error occurred.
        /// </summary>
        public string ContextDescription
        {
            get { return ctxDesc; }
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        /// <value>The error code.</value>
        public int ErrorCode
        {
            get { return code; }
        }

        /// <summary>
        /// If error was related to a file, returns information about the file and its progress. Otherwise, returns NULL.
        /// </summary>
        public BackgroundCopyFileInfo File
        {
            get { if (iVal == null) return null; return new BackgroundCopyFileInfo(iVal); }
        }

        /// <summary>
        /// The error text associated with the error.
        /// </summary>
        public override string Message
        {
            get { return errDesc; }
        }

        /// <summary>
        /// Contains the protocol used to transfer the file. The string contains "http" for the HTTP protocol and "file" for the SMB protocol and to NULL if the error is not related to the transfer protocol.
        /// </summary>
        public string Protocol
        {
            get { return protocol; }
        }
    }
}