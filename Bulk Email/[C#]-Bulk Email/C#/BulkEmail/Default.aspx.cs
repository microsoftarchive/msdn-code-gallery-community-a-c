using System;
using System.Net.Mail;

namespace BulkEmail
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                string[] to = txtTo.Text.Split(';');

                foreach (string emailAdd in to)
                {
                    if (!string.IsNullOrEmpty(emailAdd))
                        SendEmail(emailAdd);
                }

                txtTo.Text = "";
                txtSubject.Text = "";
                txtMessage.Text = "";
                lblSent.Text = "Message sent.";
                MessagePopUp.Show();
            }
            catch
            {
                lblSent.Text = "Message failed.";
                MessagePopUp.Show();
            }
        }

        private void SendEmail(string EmailAddress)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(EmailAddress);
            mail.From = new MailAddress("myusername@gmail.com");
            mail.Subject = txtSubject.Text;
            mail.Body = txtMessage.Text;

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("myusername@gmail.com", "mypassword");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}
