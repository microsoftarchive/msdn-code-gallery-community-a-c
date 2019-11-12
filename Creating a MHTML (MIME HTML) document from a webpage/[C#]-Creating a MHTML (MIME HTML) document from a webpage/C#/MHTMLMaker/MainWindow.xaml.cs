using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using MHTMLHelpers;
using MHTMLHelpers.CDO;
using MHTMLHelpers.Mail;
using MHTMLHelpers.WebRequest;

namespace MHTMLMaker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IWebRequestHelper _webRequestHelper;
        private readonly IMHTMLHelper _cdoMHTMLHelper;
        private readonly IMHTMLHelper _mailMHTMLHelper;

        public MainWindow()
        {
            InitializeComponent();

            _webRequestHelper = new WebRequestHelper();
            _cdoMHTMLHelper = new CDOMHTMLHelper(_webRequestHelper);
            _mailMHTMLHelper = new MailMHTMLHelper(_webRequestHelper);
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            var url = txtUrl.Text;
            wbHtml.Navigate(url);

            var cdoFilePath = WriteFile(Guid.NewGuid() + ".mhtml", _cdoMHTMLHelper.GetMHTML(url));
            wbCDOMHtml.Navigate("file://" + cdoFilePath.Replace("\\", "/"));

            var mailFilePath = WriteFile(Guid.NewGuid() + ".mhtml", _mailMHTMLHelper.GetMHTML(url));
            wbMailMHtml.Navigate("file://" + mailFilePath.Replace("\\", "/"));
        }

        private static string WriteFile(string name, byte[] content)
        {
            var filePath = Path.Combine(Path.GetTempPath(), name);
            using (var fs = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write))
            {
                fs.Write(content, 0, content.Length);
            }
            return filePath;
        }
    }
}
