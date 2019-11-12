using System;
namespace MailServer
{

    public class SendMail : MarshalByRefObject,IMail.ISend
    {
        private static Object lockObj;
        private string messages;
        private int register;

        public SendMail()
        {
            lockObj = new Object();
            register = 0;
        }

        public int Register()
        {
            lock (lockObj)
            {
                register += 1;
            }
            return register;
        }
        public string SendMessage(int id, string message)
        {
            this.messages += "\n" + id + ": " + message;
            return messages;
        }

        public string getMessages()
        {
            return this.messages;
        }
    }
}