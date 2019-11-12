using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTMLConverter
{
    public partial class Form1 : Form
    {
        #region Constructor

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        //HTML Conversion
        private void convertBtn_Click(object sender, EventArgs e)
        {
            //Initialize HTML converter
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter(HtmlRenderingEngine.WebKit);
            
            //WebKit converter settings
            WebKitConverterSettings webKitSettings = new WebKitConverterSettings();
            
            string urlToConvert = string.Empty;
            if (rdo_urlBtn.Checked)
            {
                if (this.openFileDialog1.FileName == string.Empty)
                    urlToConvert = url_TxtBox.Text;
                else
                    urlToConvert = openFileDialog1.FileName;
            }
            if (!IsUrlValid(urlToConvert) && urlToConvert != string.Empty)
            {
                if (MessageBox.Show("Please enter a valid URL", "Alert!!!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information)
                    == DialogResult.OK)
                {
                    url_TxtBox.Text = string.Empty;
                }
            }
            else
            {
                int delay = 0;
                if(int.TryParse(this.delay_txtBox.Text,out delay))
                {

                    //Set additional delay
                    webKitSettings.AdditionalDelay = delay;

                    //Assign the WebKit binaries path
                    //webKitSettings.WebKitPath = @"../../QtBinaries";

                    //Enable javascript
                    webKitSettings.EnableJavaScript = this.JavaScript_CheckBox.Checked;

                    //HTML to PDF conversion
                    if (this.rdo_PDFBtn.Checked)
                    {
                        //Enable hyperlink
                        webKitSettings.EnableHyperLink = this.hyperlink_checkBox.Checked;

                        //Enable bookmarks
                        webKitSettings.EnableBookmarks = this.bookmark_checkBox.Checked;

                        //Enble form
                        webKitSettings.EnableForm = this.form_checkBox.Checked;

                        //Enable toc
                        webKitSettings.EnableToc = this.toc_checkBox.Checked;

                        //Page rotation angle
                        webKitSettings.PageRotateAngle = (PdfPageRotateAngle)Enum.Parse(typeof(PdfPageRotateAngle), this.rotation_comboBox.SelectedItem.ToString());

                        int margin = 0;
                        if (int.TryParse(this.margin_comboBox.Text, out margin))
                        {
                            //Set page margins
                            webKitSettings.Margin.All = margin;

                            //Set page orientation.
                            if (this.rdo_portraitBtn.Checked)
                                webKitSettings.Orientation = PdfPageOrientation.Portrait;
                            else
                                webKitSettings.Orientation = PdfPageOrientation.Landscape;

                            //Adding Header
                            if (this.header_checkBox.Checked)
                                webKitSettings.PdfHeader = this.AddHeader(webKitSettings.PdfPageSize.Width, "Syncfusion Essential PDF", " ");

                            //Adding Footer
                            if (this.footer_checkBox.Checked)
                                webKitSettings.PdfFooter = this.AddFooter(webKitSettings.PdfPageSize.Width, "@Copyright 2015");

                            htmlConverter.ConverterSettings = webKitSettings;

                            PdfDocument document = null;
                            try
                            {
                                if (rdo_urlBtn.Checked)
                                {
                                    //Convert url to PDF document.
                                    document = htmlConverter.Convert(urlToConvert);
                                }
                                else
                                    //Convert HTML string to PDF document
                                    document = htmlConverter.Convert(this.htmlString_txtBox.Text, this.baseURL_txtBox.Text);
                                
                                // Save and close the document.
                                document.Save("Sample.pdf");
                                document.Close(true);

                                //Message box confirmation to view the created PDF document.
                                if (MessageBox.Show("Do you want to view the PDF file?", "PDF File Created",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                                    == DialogResult.Yes)
                                {
                                    //Launching the PDF file using the default Application.[Acrobat Reader]
                                    System.Diagnostics.Process.Start("Sample.pdf");
                                    this.Close();
                                }
                                else
                                {
                                    // Exit
                                    this.Close();
                                }
                            }
                            catch (PdfException ex)
                            {
                                if (MessageBox.Show("WebKit assemblies are missing", "Alert!!!", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                                {

                                }
                            }

                        }
                        else
                        {
                            if (MessageBox.Show("Please enter a valid margin", "Alert!!!",
                                MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                margin_comboBox.Text = "20";
                            }
                        }
                    }
                    //HTML to SVG Conversion
                    else if (this.rdo_SvgBtn.Checked)
                    {
                        //Assign the WebKit settings
                        htmlConverter.ConverterSettings = webKitSettings;
                        try
                        {
                            //Convert url to svg
                            htmlConverter.ConvertToSvg(urlToConvert, "Sample.svg");

                            //Message box confirmation to view the created SVG document.
                            if (MessageBox.Show("Do you want to view the SVG file?", "SVG File Created",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                                == DialogResult.Yes)
                            {
                                //Launching the SVG file using the default Application.[Default Browser]
                                System.Diagnostics.Process.Start("Sample.svg");
                                this.Close();
                            }
                            else
                            {
                                // Exit
                                this.Close();
                            }
                        }
                        catch (PdfException ex)
                        {
                            if (MessageBox.Show("WebKit assemblies are missing", "Alert!!!", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {

                            }
                        }
                    }
                    // HTML to Image Conversion
                    else if (this.rdo_ImageBtn.Checked)
                    {
                        //Assign the WebKit settings
                        htmlConverter.ConverterSettings = webKitSettings;
                        try
                        {
                            Image[] images;
                            if (this.rdo_urlBtn.Checked)
                            {
                                //Convert HTML to image
                                images = htmlConverter.ConvertToImage(urlToConvert);
                            }
                            else
                            {
                                //Convert HTML string to image
                                images = htmlConverter.ConvertToImage(this.htmlString_txtBox.Text, this.baseURL_txtBox.Text);
                            }

                            //Save the image
                            images[0].Save("Sample.png", System.Drawing.Imaging.ImageFormat.Png);
                            images[0].Dispose();

                            //Message box confirmation to view the created Image document.
                            if (MessageBox.Show("Do you want to view the image file?", "Image File Created",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                                == DialogResult.Yes)
                            {
                                //Launching the Image file using the default Application.[Image viewer]
                                System.Diagnostics.Process.Start("Sample.png");
                                this.Close();
                            }
                            else
                            {
                                // Exit
                                this.Close();
                            }
                        }
                        catch (PdfException ex)
                        {
                            if (MessageBox.Show("WebKit assemblies are missing", "Alert!!!", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {

                            }
                        }
                    }
                    //HTML to MHTML conversion
                    else
                    {
                        //Assign the WebKit settings
                        htmlConverter.ConverterSettings = webKitSettings;
                        try
                        {
                            //Convert url to mhtml
                            htmlConverter.ConvertToMhtml(urlToConvert, "Sample.mhtml");

                            //Message box confirmation to view the created MHTML document.
                            if (MessageBox.Show("Do you want to view the MHTML file?", "MHTML File Created",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                                == DialogResult.Yes)
                            {
                                //Launching the MHTML file using the default Application.[Default browser]
                                System.Diagnostics.Process.Start("Sample.mhtml");
                                this.Close();
                            }
                            else
                            {
                                // Exit
                                this.Close();
                            }
                        }
                        catch (PdfException ex)
                        {
                            if (MessageBox.Show("WebKit assemblies are missing", "Alert!!!", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {

                            }
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show("Please enter a valid delay", "Alert!!!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        == DialogResult.OK)
                    {
                        delay_txtBox.Text = "0";
                    }
                }
            }
        }

        #region Form Control Events
        
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //Here is an open form2 from form1
            if (rdo_htmlStringBtn.Checked)
            {
                Form2 form2 = new Form2(this);
                form2.ShowDialog();
            }
        }

        private void rdo_urlBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo_urlBtn.Checked)
            {
                url_TxtBox.Refresh();
                groupBox7.Visible = true;
                groupBox6.Visible = false;
            }
        }

        //HTML files selector
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "HTML file(*.html,*.htm,*.mhtml,*.mht)|*.html;*.htm;*.mhtml;*.mht|Text file (*.txt)|*.txt|SVG file (*.svg)|*.svg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                url_TxtBox.Text = openFileDialog1.SafeFileName;
            }
        }

        //Enable and disable controls for HTML to SVG 
        private void rdo_SvgBtn_CheckedChanged(object sender, EventArgs e)
        {
            this.DisableControls();
            this.rdo_htmlStringBtn.Enabled = false;
            this.rdo_urlBtn.Checked = true;
        }

        //Enable and disable controls for HTML to Image 
        private void rdo_ImageBtn_CheckedChanged(object sender, EventArgs e)
        {
            this.DisableControls();
            this.rdo_htmlStringBtn.Enabled = true;
        }

        //Enable and disable unsupported options for HTML to MHTML 
        private void rdo_MhtmlBtn_CheckedChanged(object sender, EventArgs e)
        {
            this.DisableControls();
            this.rdo_htmlStringBtn.Enabled = false;
            this.rdo_urlBtn.Checked = true;
        }

        //Enable controls for HTML to PDF
        private void rdo_PDFBtn_CheckedChanged(object sender, EventArgs e)
        {
            this.EnableControls();
            this.rdo_htmlStringBtn.Enabled = true;
        }

        //Disable form fields for unsupported options
        public void DisableControls()
        {
            this.toc_checkBox.Enabled = false;
            this.bookmark_checkBox.Enabled = false;
            this.form_checkBox.Enabled = false;
            this.hyperlink_checkBox.Enabled = false;
            this.groupBox3.Enabled = false;
        }

        //Enable form fields for supported options
        public void EnableControls()
        {
            this.toc_checkBox.Enabled = true;
            this.bookmark_checkBox.Enabled = true;
            this.form_checkBox.Enabled = true;
            this.hyperlink_checkBox.Enabled = true;
            this.groupBox3.Enabled = true;
        }

        private void htmlString_txtBox_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.ShowDialog();
        }

        #endregion

        #endregion

        #region helper methods
        /// <summary>
        /// Draws header to the document.
        /// </summary>
        private PdfPageTemplateElement AddHeader(float width, string title, string description)
        {
            RectangleF rect = new RectangleF(0, 0, width, 50);
            //Create a new instance of PdfPageTemplateElement class.     
            PdfPageTemplateElement header = new PdfPageTemplateElement(rect);
            PdfGraphics g = header.Graphics;

            //Draw the image in the Header.
            SizeF imageSize = new SizeF(110f, 27f);
            //Locating the logo on the right corner.
            PointF imageLocation = new PointF(width - imageSize.Width - 20, (int)(rect.Height / 4));
            PdfImage img = new PdfBitmap(@"../../Resources/syncfusion_logo.gif");
            g.DrawImage(img, imageLocation, imageSize);

            //Draw title.
            PdfFont font = new PdfTrueTypeFont(new Font("Helvetica", 16, FontStyle.Bold), true);
            PdfSolidBrush brush = new PdfSolidBrush(Color.FromArgb(44, 71, 120));
            float x = (width / 2) - (font.MeasureString(title).Width) / 2;
            g.DrawString(title, font, brush, new RectangleF(x, (rect.Height / 4) + 3, font.MeasureString(title).Width, font.Height));

            //Draw description
            brush = new PdfSolidBrush(Color.Gray);
            font = new PdfTrueTypeFont(new Font("Helvetica", 6, FontStyle.Bold), true);
            PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Bottom);
            g.DrawString(description, font, brush, new RectangleF(0, 0, header.Width, header.Height - 8), format);

            //Draw some lines in the header
            PdfPen pen = new PdfPen(Color.DarkBlue, 0.7f);
            g.DrawLine(pen, 0, 0, header.Width, 0);
            pen = new PdfPen(Color.DarkBlue, 2f);
            g.DrawLine(pen, 0, 03, header.Width + 3, 03);
            pen = new PdfPen(Color.DarkBlue, 2f);
            g.DrawLine(pen, 0, header.Height - 3, header.Width, header.Height - 3);
            g.DrawLine(pen, 0, header.Height, header.Width, header.Height);

            return header;
        }

        /// <summary>
        /// Draws footer to the document.
        /// </summary>
        private PdfPageTemplateElement AddFooter(float width, string footerText)
        {
            RectangleF rect = new RectangleF(0, 0, width, 50);
            //Create a new instance of PdfPageTemplateElement class.
            PdfPageTemplateElement footer = new PdfPageTemplateElement(rect);
            PdfGraphics g = footer.Graphics;

            // Draw footer text.
            PdfSolidBrush brush = new PdfSolidBrush(Color.Gray);
            PdfFont font = new PdfTrueTypeFont(new Font("Helvetica", 6, FontStyle.Bold), true);
            float x = (width / 2) - (font.MeasureString(footerText).Width) / 2;
            g.DrawString(footerText, font, brush, new RectangleF(x, g.ClientSize.Height - 10, font.MeasureString(footerText).Width, font.Height));

            //Create page number field
            PdfPageNumberField pageNumber = new PdfPageNumberField(font, brush);

            //Create page count field
            PdfPageCountField count = new PdfPageCountField(font, brush);

            PdfCompositeField compositeField = new PdfCompositeField(font, brush, "Page {0} of {1}", pageNumber, count);
            compositeField.Bounds = footer.Bounds;
            compositeField.Draw(g, new PointF(470, 40));

            return footer;

        }

        //check URL is valid or not
        private bool IsUrlValid(string url)
        {
            string pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(url);
        }
        #endregion

    }
}
