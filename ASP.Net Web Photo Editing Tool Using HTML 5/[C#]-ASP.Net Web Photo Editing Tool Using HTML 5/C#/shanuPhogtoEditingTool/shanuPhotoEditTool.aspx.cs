using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using System.Web.Script.Services;

using System.Web.Services;
using System.Net;
using System.Net.Mail;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mime;
/// <summary>
/// Author      : Shanu
/// Create date : 2014-07-06
/// Description : SHANU WEB PAINTING TOOL USING HTML 5 CANVAS
/// Latest      : Ver1.0
/// Modifier    : SHANU
/// Modify date : 2014-07-08
/// </summary>


namespace shanuPhotoEditor2010
{
    public partial class shanuPhotoEditTool : System.Web.UI.Page
    {
        public static Bitmap bmp;
        String userGmailEmailID = "userGmailEmailID";
        string userGmailPasswod = "userGmailPasswod";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnImage_Click(object sender, EventArgs e)
        {

            string imageData = this.hidImage.Value;

            Random rnd = new Random();
            string imagePath = HttpContext.Current.Server.MapPath("Shanuimg" + rnd.Next(12, 2000).ToString() + ".jpg");

            using (FileStream fs = new FileStream(imagePath, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    byte[] data = Convert.FromBase64String(imageData);
                    bw.Write(data);
                    bw.Close();

                    sendMail(imagePath);
                }
            }
        }

        private void sendMail(string FilePath)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            string msg = string.Empty;
            try
            {
                MailAddress fromAddress = new MailAddress(txtFromEmail.Text.Trim());
                message.From = fromAddress;
                message.To.Add(txtToEmail.Text.Trim());

                message.Attachments.Add(new Attachment(FilePath));

                message.Subject = txtSub.Text.Trim();
                message.IsBodyHtml = true;
                message.Body = txtMessage.Text.Trim();
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(userGmailEmailID, userGmailPasswod);

                smtpClient.Send(message);
              
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }



        }
    }
}