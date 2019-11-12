using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System.Drawing;

namespace Table
{
    class Program
    {
        static void Main(string[] args)
        {
            Document doc = new Document();
            Section sec = doc.AddSection();
            Paragraph para = sec.AddParagraph();
            para.AppendText("Spire.Doc--- Create Table");
            para.Format.HorizontalAlignment = HorizontalAlignment.Center;

            Spire.Doc.Table table = sec.AddTable(false);
            table.ResetCells(7, 3);
            //First Row
            TextRange range;
            TableRow Row = table.Rows[0];
            Row.Height = 30;

            Row.Cells[0].CellFormat.BackColor = Color.LightBlue;
            para = Row.Cells[0].AddParagraph();
            para.AppendPicture(Image.FromFile(@"../../images/1.png"));
            range = para.AppendText(".Net");
            para.Format.HorizontalAlignment = HorizontalAlignment.Center;
            range.CharacterFormat.TextColor = Color.White;

            Row.Cells[1].CellFormat.BackColor = Color.LightGreen;
            para = Row.Cells[1].AddParagraph();
            para.AppendPicture(Image.FromFile(@"../../images/2.png"));
            range = para.AppendText(".WPF");
            para.Format.HorizontalAlignment = HorizontalAlignment.Center;
            range.CharacterFormat.TextColor = Color.White;

            Row.Cells[2].CellFormat.BackColor = Color.LightPink;
            para = Row.Cells[2].AddParagraph();
            para.AppendPicture(Image.FromFile(@"../../images/3.png"));
            range = para.AppendText("Silverlight");
            para.Format.HorizontalAlignment = HorizontalAlignment.Center;
            range.CharacterFormat.TextColor = Color.White;

            //From Second Row To Seventh Row
            for (int i = 1; i < table.Rows.Count; i++)
            {
                table.Rows[i].Height = 20;
                for (int j = 0; j < table.Rows[i].Cells.Count; j++)
                {
                    para = table.Rows[i].Cells[j].AddParagraph();
                    if (i < 5)
                    {
                        if (j == 0)
                        {
                            para.AppendPicture(Image.FromFile(@"../../images/red.png"));
                        }
                        else
                        {
                            para.AppendPicture(Image.FromFile(@"../../images/c.png"));
                        }
                    }

                    switch (i)
                    {
                        case 1:
                            para.AppendText("Spire.Doc");
                            break;
                        case 2:
                            para.AppendText("Spire.Office");
                            break;
                        case 3:
                            para.AppendText("Spire.XLS");
                            break;
                        case 4:
                            para.AppendText("Spire.PDF");
                            break;
                        case 5:
                            if (j < 2)
                            {
                                para.AppendPicture(Image.FromFile(@"../../images/c.png"));
                                para.AppendText("Spire.PDFViewer");
                            }
                            else
                            {
                                para.Format.HorizontalAlignment = HorizontalAlignment.Center;
                                para.AppendText("/");
                            }
                            break;
                        case 6:
                            if (j < 2)
                            {
                                if (j == 0)
                                {
                                    para.AppendPicture(Image.FromFile(@"../../images/blue.png"));
                                }
                                else
                                {
                                    para.AppendPicture(Image.FromFile(@"../../images/c.png"));
                                }
                                para.AppendText("Spire.Barcode");
                            }
                            else
                            {
                                para.Format.HorizontalAlignment = HorizontalAlignment.Center;
                                para.AppendText("/");
                            }
                            break;
                    }

                }
            }
            //Save and launch
            doc.SaveToFile(@"..\..\CreateTable.docx", FileFormat.Docx);
            doc.Close();
            System.Diagnostics.Process.Start(@"..\..\CreateTable.docx");
        }
    }
}
