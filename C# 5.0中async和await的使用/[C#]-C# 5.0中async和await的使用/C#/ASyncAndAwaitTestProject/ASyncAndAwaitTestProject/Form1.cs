using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace ASyncAndAwaitTestProject
{
    // 同步代码所存在的问题——如果有一个耗时的操作时，此时就会出现界面“卡死”，用户不能操作界面的任何按钮。
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       // 单击事件
        private void btnClick_Click(object sender, EventArgs e)
        {
            this.btnClick.Enabled = false;

            long length = AccessWeb();
            this.btnClick.Enabled = true;
            // 这里可以做一些不依赖回复的操作
            OtherWork();

            this.richTextBox1.Text += String.Format("\n 回复的字节长度为:  {0}.\r\n", length);
            txbMainThreadID.Text = Thread.CurrentThread.ManagedThreadId.ToString();
        }

        private  long AccessWeb()
        {
            MemoryStream content = new MemoryStream();

            // 对MSDN发起一个Web请求
            HttpWebRequest webRequest = WebRequest.Create("http://msdn.microsoft.com/zh-cn/") as HttpWebRequest;
            if (webRequest != null)
            {
                // 返回回复结果
                using (WebResponse response = webRequest.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        responseStream.CopyTo(content);
                    }
                }
            }

            txbAsynMethodID.Text = Thread.CurrentThread.ManagedThreadId.ToString();
            return content.Length;
        }

        // 模拟做其他工作的方法
        private void OtherWork()
        {
            this.richTextBox1.Text += "\r\n等待服务器回复中.................\n";
        }
    }
}
