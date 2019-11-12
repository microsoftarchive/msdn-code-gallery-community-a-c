using OpenPop.Mime;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace ReadInboxEmail.WebApplication.Models
{
    public class DashBoardMailBoxJob
    {
        //public MailBoxJob MailBoxJobModel { get; set; }
        public Dictionary<int, Message> messages = new Dictionary<int, Message>();
        public TreeView listAttachments { get; set; }
        public TreeView listMessages { get; set; }
        public string mess { get; set; }
        public string data { get; set; }
        public List<MailMessege> Inbox { get; set; }
    }
}