using AE.Net.Mail;
using OpenPop.Common.Logging;
using ReadInboxEmail.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ReadInboxEmail.WebApplication.Controllers
{
    public class MailBoxController : Controller
    {
        // GET: MailBox
        public ActionResult Index()
        {

            DashBoardMailBoxJob model = new DashBoardMailBoxJob();

            model = ReceiveMails();
            model.data = "";
            return View(model);
        }

        private DashBoardMailBoxJob ReceiveMails()
        {
            DashBoardMailBoxJob model = new DashBoardMailBoxJob();
            model.Inbox = new List<MailMessege>();

            try
            {
                EmailConfiguration email = new EmailConfiguration ();
                email.POPServer = "imap.gmail.com"; // type your popserver
                email.POPUsername = ""; // type your username credential
                email.POPpassword = ""; // type your password credential
                email.IncomingPort = "993";
                email.IsPOPssl = true;


                int success = 0;
                int fail = 0;
                ImapClient ic = new ImapClient(email.POPServer, email.POPUsername, email.POPpassword, AuthMethods.Login, Convert.ToInt32(email.IncomingPort), (bool)email.IsPOPssl);
                // Select a mailbox. Case-insensitive
                ic.SelectMailbox("INBOX");
                int i = 1;
                int msgcount = ic.GetMessageCount("INBOX");
                int end = msgcount - 1;
                int start = msgcount - 40;
                // Note that you must specify that headersonly = false
                // when using GetMesssages().
                MailMessage[] mm = ic.GetMessages(start, end, false);
                foreach (var item in mm)
                {
                    MailMessege obj = new MailMessege();
                    try
                    {

                        obj.UID = item.Uid;
                        obj.subject = item.Subject;
                        obj.sender = item.From.ToString();
                        obj.sendDate = item.Date;
                        if (item.Attachments == null) { }
                        else obj.Attachments = item.Attachments;
 
                        model.Inbox.Add(obj);
                        success++;
                    }
                    catch (Exception e)
                    {
                        DefaultLogger.Log.LogError(
                            "TestForm: Message fetching failed: " + e.Message + "\r\n" +
                            "Stack trace:\r\n" +
                            e.StackTrace);
                        fail++;
                    }
                    i++;

                }
                ic.Dispose();
                model.Inbox = model.Inbox.OrderByDescending(m => m.sendDate).ToList();
                model.mess = "Mail received!\nSuccesses: " + success + "\nFailed: " + fail + "\nMessage fetching done";

                if (fail > 0)
                {
                    model.mess = "Since some of the emails were not parsed correctly (exceptions were thrown)\r\n" +
                                    "please consider sending your log file to the developer for fixing.\r\n" +
                                    "If you are able to include any extra information, please do so.";
                }
            }

            catch (Exception e)
            {
                model.mess = "Error occurred retrieving mail. " + e.Message;
            }
            finally
            {

            }
            return model;
        }

        public ActionResult GetMessegeBody(string id)
        {
            JsonResult result = new JsonResult();

            EmailConfiguration email = new EmailConfiguration();
            email.POPServer = "imap.gmail.com";
            email.POPUsername = "";
            email.POPpassword = "";
            email.IncomingPort = "993";
            email.IsPOPssl = true;

            ImapClient ic = new ImapClient(email.POPServer, email.POPUsername, email.POPpassword, AuthMethods.Login, Convert.ToInt32(email.IncomingPort), (bool)email.IsPOPssl);
            // Select a mailbox. Case-insensitive
            ic.SelectMailbox("INBOX");

            int msgcount = ic.GetMessageCount("INBOX");
            MailMessage mm = ic.GetMessage(id, false);

            if (mm.Attachments.Count() > 0)
            {
                foreach (var att in mm.Attachments)
                {
                    string fName;
                    fName = att.Filename;
                }
            }
            StringBuilder builder = new StringBuilder();

            builder.Append(mm.Body);
            string sm = builder.ToString();

            CustomerEmailDetails model = new CustomerEmailDetails();
            model.UID = mm.Uid;
            model.subject = mm.Subject;
            model.sender = mm.From.ToString();
            model.sendDate = mm.Date;
            model.Body = sm;
            if (mm.Attachments == null) { }
            else model.Attachments = mm.Attachments;
             
            return View("CreateNewCustomer", model);
        }

        [HttpGet]
        public ActionResult CreateNewCustomer(CustomerEmailDetails model)
        {
             
                if (ModelState.ContainsKey("{key}"))
                    ModelState["{key}"].Errors.Clear();
                return View(model);
            
        }
    }
}