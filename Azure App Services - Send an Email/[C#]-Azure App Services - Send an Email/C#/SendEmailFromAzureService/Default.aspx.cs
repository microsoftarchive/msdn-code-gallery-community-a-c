using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MailMessage msg = new MailMessage();
        msg.To.Add(new MailAddress("***Replace with -> To Email Address***", "Benjamin"));
        msg.From = new MailAddress("***Replace with -> From Email Address*", "You");
        msg.Subject = "Azure Web App Email using smtp.office365.com";
        msg.Body = "Test message using smtp.office365.com on Azure from a Web App";
        msg.IsBodyHtml = true;

        SmtpClient client = new SmtpClient();
        client.UseDefaultCredentials = false;
        client.Credentials = new System.Net.NetworkCredential("O365 UID", "O365 PASS");
        client.Port = 587;
        client.Host = "smtp.office365.com";
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.EnableSsl = true;
        try
        {
            client.Send(msg);
            statusLabel.Text = "Message Sent Succesfully";
        }
        catch (Exception ex)
        {
            statusLabel.Text = ex.ToString();
        }
    }
}