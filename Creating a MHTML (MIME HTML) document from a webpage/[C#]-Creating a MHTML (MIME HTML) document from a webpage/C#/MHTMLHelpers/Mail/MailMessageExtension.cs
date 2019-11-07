using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;

namespace MHTMLHelpers.Mail
{
    
    public static class MailMessageExtension
    {

        public static void Write(this MailMessage message, MemoryStream ms)
        {
            var sendMethod = typeof(MailMessage).GetMethod("Send", BindingFlags.Instance | BindingFlags.NonPublic);

            sendMethod.Invoke(message, BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { GetMailWriter(ms), false }, null);
        }

        private static object GetMailWriter(MemoryStream ms)
        {
            var assembly = typeof(MailMessage).Assembly;
            var mailWriterType = assembly.GetType("System.Net.Mail.MailWriter");
            var mailWriterConstructorInfo = mailWriterType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { typeof(Stream) }, null);

            return mailWriterConstructorInfo.Invoke(new object[] { ms });
        }

    }

}
