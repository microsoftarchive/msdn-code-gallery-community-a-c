using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Threading;
using ContaNet.Tools;
using Microsoft.VisualBasic;

namespace CSharpDemo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        bool Mobile = false;
        String[,] AR;

        protected void Page_Load(object sender, EventArgs e)
        {

            Mobile = GetMobile();
            var core = new NSCore(Page, "", mystyle(), ShowMenu(), ToolBar());
            var show = new ContaNet.Tools.NSShow(Page);
            var util = new NSUtil(Page);
            var grdreturn = new ContaNet.Tools.NSShow.GridValues();
            String[] Artic = { };
            String[] config;
            String des1 = "";
            double importe = 0;
            double descuento = 0;
            var m = new NSMenu();
            var M = new NSShow.MenuValues();
            int tope = 0;
            var htm = new ContaNet.Tools.NSHTML();
            var rm = new ContaNet.Tools.NSShow.MenuValues();
            var sb = new System.Text.StringBuilder();
            var tv = new ContaNet.Tools.NSTreeView();
            String des;
            String Name;
            Random rnd = new Random();
            int aa = rnd.Next(1000000);
            var grd1 = new NSGrid();
            var Txt = new System.Text.StringBuilder();
            String[,] txt2;
            System.Globalization.NumberFormatInfo nfi_g0 = new System.Globalization.NumberFormatInfo();
            var tipovar = new NSEnums.NSVars();
            String FileName;
            var mr = new ContaNet.Tools.NSShow.MenuValues();
            var CX = new ContaNet.Tools.NSContainer();
            switch (core.Funct)
            {
                case "":
                    return;
                case "TEST":
                    CX.Caption = "test";
                    CX.Href = "data/test2.htm";
                    CX.NewPageIcon = true;
                    CX.Show(Page);
                    break;
                case "TEST1":
                    String Stuff;
                    Stuff = core.Grid.Clip();
                    File.WriteAllText(Server.MapPath(".") + "\\data\\LEO.txt", Stuff);
                    System.Diagnostics.Debugger.Break();
                    break;
                case "HTMLFILE":
                    show.HTMLFile("HTML", "data/test.html", CenterScreen: true);
                    break;
                case "OK":
                    show.Message("OK");
                    break;
                case "LOGIN":
                    m.Funct = "2";
                    m.Caption = "Login";
                    m.Top = 100;
                    m.Left = 100;

                    m.AddItem("bt/intro.png", ContaNet.Tools.NSEnums.NSVars.Image, 2, "Enter here");
                    m.AddButton("Send an email", "images/newclient.png", "", "MAILTO");
                    m.AddLabel("Just click below to enter", ContaNet.Tools.NSEnums.LabelColor.Blue, NSEnums.Align.Center);
                    m.AddLabel("No password or name required", ContaNet.Tools.NSEnums.LabelColor.Red, NSEnums.Align.Center);
                    m.AddItem("Name", ContaNet.Tools.NSEnums.NSVars.Text, 30, "", "", "", Server.MapPath(".") + "MyKeyboard.txt");
                    m.AddItem("Password", ContaNet.Tools.NSEnums.NSVars.Password, 30, "", "", "", Server.MapPath(".") + "MyKeyboard.txt");
                    m.Show(Page);
                    break;
                case "ABCD":
                    mr.SetTextValue(2, "hola", "in spanish");
                    mr.SetTextValue(3, "hello", "in english");
                    mr.SetFocus(3);
                    mr.ReturnValues(Page);
                    break;
                case "2":
                    util.set_Cookie("LOGIN", default(DateTime), "TRUE");
                    show.Reload();
                    break;

                case "10":
                case "10A": /* sample data entry*/
                    string Reg;
                    m.Top = 100; //10
                    m.Left = 100;
                    m.Height = 500;
                    m.Funct = "55";
                    //  m.ForeColor = Drawing.Color.Black
                    if (core.Funct == "10A")
                    {

                        m.AddCancelFunction("CANCEL", "SPANISH");
                        m.TouchPadOff = true;
                        Reg = "ES";
                    }
                    else
                    {
                        m.AddCancelFunction("CANCEL1", "ENGLISH");
                        Reg = "EN";
                    }
                    m.Caption = "This is a test";
                    //  m1.FontFamily = "Open sans"
                    //  m1.FontSize = 40
                    //  m1.FontColor = "red"
                    m.CenterScreen = true;
                    m.AddItem("MaskedEdit Telephone", NSEnums.NSVars.MaskedEdit, 14, "(111) 222-3333", "(###) ###-####");
                    m.AddItem("MaskedEdit SSN", NSEnums.NSVars.MaskedEdit, 14, "111-22-3333", "###-##-####");

                    m.AddItem("STATES", NSEnums.NSVars.States, 0);
                    m.AddItem("STATES (with abreviation)", NSEnums.NSVars.States_Abrev, 0);

                    m.AddItem("Text entry (30 characters)", NSEnums.NSVars.Text, 30, "Original text");

                    if (Reg == "EN")
                    {

                        m.AddItem("A Date", NSEnums.NSVars.DateSelect, 8, string.Format("{0:MM/dd/yy}", DateTime.Now));
                        m.AddItem("Date with century", NSEnums.NSVars.DateSelect, 10, string.Format("{0:MM/dd/yyyy}", DateTime.Now));
                        m.AddItem("Date with just day and month", NSEnums.NSVars.DateSelect, 5, string.Format("{0:MM/dd}", DateTime.Now));
                    }
                    else
                    {
                        m.AddItem("Fecha", NSEnums.NSVars.DateSelect, 8, string.Format("{0:dd/MM/yy}", DateTime.Now));
                        m.AddItem("Fecha con siglo", NSEnums.NSVars.DateSelect, 10, string.Format("{0:dd/MM/yyyy}", DateTime.Now));
                        m.AddItem("Fecha con solo dia y mes", NSEnums.NSVars.DateSelect, 5, string.Format("{0:dd/MM}", DateTime.Now));
                    }
                    m.AddItem("No decimals", NSEnums.NSVars.Number, 12);
                    m.AddItem("one decimal", NSEnums.NSVars.Number_1dec, 12);
                    m.AddItem("two decimals", NSEnums.NSVars.Number_2dec, 12, "");
                    m.AddItem("three decimals", NSEnums.NSVars.Number_3dec, 12);
                    m.AddItem("four decimals", NSEnums.NSVars.Number_4dec, 12);
                    m.AddItem("five decimals", NSEnums.NSVars.Number_5dec, 12);

                    m.AddItem("Check box 1 (not checked by default)", NSEnums.NSVars.Checkbox, 0, "");
                    m.AddItem("Check box 2 (checked by default)", NSEnums.NSVars.Checkbox, 0, "1");
                    m.AddItem("Option 1", NSEnums.NSVars.SelectOption, 0, "");
                    m.AddItem("Option 2", NSEnums.NSVars.SelectOption, 0, "1");
                    m.AddItem("Mutiple selection", NSEnums.NSVars.MultipleSelection, 2, "one,two,three,four,five");
                    m.AddItem("Multiple selection (hit 0 or 1 and enter)", NSEnums.NSVars.MultipleSelectionEditable, 20, "one,two,three,four,five");
                    m.AddLabel("Red label align left", NSEnums.LabelColor.Red, NSEnums.Align.Left);
                    m.AddLabel("Yellow label align center", NSEnums.LabelColor.Yellow, NSEnums.Align.Center);
                    m.AddLabel("Green label align right", NSEnums.LabelColor.Green, NSEnums.Align.Right);
                    m.AddItem("Color", NSEnums.NSVars.Colors, 0, "");
                    m.AddItem("Fonts", NSEnums.NSVars.FontNames, 0);
                    m.AddItem("Month", NSEnums.NSVars.Month, 0, "");
                    m.AddItem("NIF (Spanish ID)", NSEnums.NSVars.Nif, 10, "");
                    m.AddItem("NOTES", NSEnums.NSVars.Notes, 50, "");
                    m.AddItem("NUMERATOR", NSEnums.NSVars.Numerator, 10, "");
                    m.AddItem("Country", NSEnums.NSVars.Country, 30, "");


                    m.AddItem("PASSWORD", NSEnums.NSVars.Password, 20, "");
                    m.AddItem("Zero filled number", NSEnums.NSVars.ZeroFilledNumber, 10, "000000000");
                    m.AddItem("File upload", NSEnums.NSVars.FileUpload, 50, "");
                    string Text = m.Show(Page);
                    break;

                case "11":
                    grd1.Caption = "Estimates";
                    grd1.Calculator = true;
                    //grd1.Calendar = true;
                    // .fullScreen = True
                    grd1.RepeatPreviousLine = true;
                    grd1.HiddenData = "Hidden Grid Data";
                    grd1.AddTextBox("Month one", "January,February,March,April,May,June,July,August,September,October,November,December", NSEnums.NSVars.MultipleSelection, 4, "GetMonth", "", 0, "11MONTH");
                    grd1.AddTextBox("Month two", "January,February,March,April,May,June,July,August,September,October,November,December", NSEnums.NSVars.MultipleSelectionReturnsNumber, 4, "GetMonth2", "", 0, "11MONTH");
                    grd1.AddTextBox("Date", "31/12/14", NSEnums.NSVars.DateSelect, 10, "Date1", "");
                    grd1.AddTextBox("Total", "", NSEnums.NSVars.Number_2dec, 12, "TotalGrid", "", 1);
                    grd1.AddTextBox("Date", "31/12/14", NSEnums.NSVars.DateSelect, 10, "Date2", "", 1);

                    grd1.AddCol("Chanel", NSEnums.NSVars.NonModifiableText, 3);
                    grd1.AddCol("Date", NSEnums.NSVars.DateSelect, 8, "");
                    grd1.AddCol("Description", NSEnums.NSVars.Text, 35, "", NSEnums.Align.Left, "1111");
                    grd1.AddCol("KEY", NSEnums.NSVars.ZeroFilledNumber, 6);
                    grd1.AddCol("Amount", NSEnums.NSVars.Number, 12, "", NSEnums.Align.Right, "ADD");
                    grd1.AddCol("Amount 1", NSEnums.NSVars.Number_1dec, 12, "", NSEnums.Align.Right, "ADD");
                    grd1.AddCol("Amount 2", NSEnums.NSVars.Number_2dec, 12, "", NSEnums.Align.Right, "ADD");
                    grd1.AddCol("Amount 3", NSEnums.NSVars.Number_3dec, 12, "", NSEnums.Align.Right, "ADD");
                    grd1.AddCol("Amount 4", NSEnums.NSVars.Number_4dec, 12, "", NSEnums.Align.Right, "ADD");
                    grd1.AddCol("Amount 5", NSEnums.NSVars.Number_5dec, 12, "", NSEnums.Align.Right, "ADD");
                    grd1.AddCol("Check", NSEnums.NSVars.Checkbox, 1);
                    grd1.ASPXPage = "Webform1.aspx";
                    grd1.Rows = 10;
                    grd1.Show(Page);
                    break;

                case "ADD":
                    double Total = 0;
                    for (int y = 0; y <= core.Grid.Rows(); y++)
                    {
                        for (int x = 4; x <= 9; x++)
                        {
                            //System.Globalization.NumberFormatInfo nfi_g0 = new  System.Globalization.NumberFormatInfo();
                            //nfi_g0.CurrencyGroupSeparator = ".";
                            if (core.Grid.CellValue(y, x) != "")
                            {
                                Total += Convert.ToDouble(core.Grid.CellValue(y, x), nfi_g0);
                            }
                        }
                    }

                    //var grdreturn = new ContaNet.Tools.NSShow.GridValues();
                    grdreturn.SetTextValue("TotalGrid", Convert.ToString(Total));
                    grdreturn.ReturnValues(Page);
                    break;
                case "11MONTH":
                    //System.Diagnostics.Debugger.Break();
                    break;

                case "1111":

                    String[] Articulos = { "01 ContaNet ORO", "02 Plata", "03 CRM", "04 Platino" };
                    String[] Importes = { "798.25", "255", "489", "2500" };

                    if (core.Values[0] == "" | core.Values[0] == "0")
                    {
                        show.List("my items", Articulos);
                    }
                    else
                    {
                        int row = core.Grid.Row();
                        int col = core.Grid.Col();
                        //var grdreturn = new ContaNet.Tools.NSShow.GridValues();
                        des = core.Grid.CellValue(row, col);
                        int i1 = 0;
                        i1 = Articulos.Length-1;
                        for (int x = 0; x <= i1; x++)
                        {
                            if (Articulos[x].StartsWith(des))
                            {
                                grdreturn.AddColValue(row, 0, "111");
                                grdreturn.AddColValue(row, 2, Articulos[x].Substring(3));
                                grdreturn.AddColValue(row, 3, Importes[x]);
                                break;
                            }
                        }
                        grdreturn.SetTextValue("TotalGrid", "250,25");
                        //  grdreturn.Setfocus(row + 1, 1)
                        //  grdreturn.Clear = True
                        grdreturn.ReturnValues(Page);
                    }
                    break;

                case "111":
                    String Stuff1;
                    Stuff1 = core.Grid.Clip();
                    File.WriteAllText(Server.MapPath(".") + @"\data\mytest.txt", Stuff1);
                    show.CloseCallingWindow();
                    break;

                case "113":
                    var grd2 = new NSGrid();
                    grd2.LineNumbers = false;
                    grd2.Caption = "Invoice";
                    grd2.ReturnCol = 4;
                    grd2.AddButton("New Client", "images/newclient.png", "", "113F");
                    grd2.AddTextBox("Client Name (type a name and enter)", "", NSEnums.NSVars.Text, 35, "ClientName", "", 0, "113A");
                    grd2.AddTextBox("Client ID", "", NSEnums.NSVars.NonModifiableText, 10, "ClientID");
                    grd2.AddTextBox("Date", DateTime.Now.ToString("MM/dd/yy"), NSEnums.NSVars.DateSelect, 8, "InvoiceDate", "", 0);
                    grd2.AddTextBox("Total", "", NSEnums.NSVars.NonModifiableNumber, 12, "Total");

                    grd2.AddCol("Item", NSEnums.NSVars.Text, 10, "", NSEnums.Align.Left, "113D");
                    grd2.AddCol("Description", NSEnums.NSVars.Text, 45, "", NSEnums.Align.Left, "113E");
                    grd2.AddCol("Units", NSEnums.NSVars.Number, 12, "", NSEnums.Align.Left, "113C");
                    grd2.AddCol("Amount", NSEnums.NSVars.Number_2dec, 15, "", NSEnums.Align.Left, "113C");
                    grd2.AddCol("%", NSEnums.NSVars.Number, 2, "", NSEnums.Align.Left, "113C");
                    grd2.AddCol("Total", NSEnums.NSVars.NonModifiableText, 15);

                    grd2.Top = "100px";
                    grd2.Left = "200px";
                    grd2.Funct = "SAVEINVOICE";
                    grd2.HelpFile = "help/invoicehelp.html";
                    grd2.Rows = 5;
                    grd2.Show(Page);
                    break;
                case "SAVEINVOICE":
                    var util2 = new ContaNet.Tools.NSUtil(Page);
                    String Client = "Client ID: " + core.Grid.TextBoxValue("ClientID") + "<br/>";
                    Client += "Name: " + core.Grid.TextBoxValue("ClientName");
                    Text = core.Grid.Clip();
                    Total = 0;
                    int rows;
                    rows = core.Grid.Rows();
                    for (int row = 0; row <= rows; row++)
                    {
                        Total += util2.Val(core.Grid.CellValue(row, 5));
                    }
                    Text += System.Environment.NewLine;
                    Text += "*" + "\t" + "Total" + "\t" + "\t" + "\t" + "\t" + Convert.ToString(Total);
                    htm.BackgroundColor = "white";
                    htm.TextColor = "black";
                    htm.Caption = "Invoice";
                    htm.Header = Client;
                    htm.Text = Text;
                    htm.AddCol("Item", NSHTML.Types.Text);
                    htm.AddCol("Description", NSHTML.Types.Text);
                    htm.AddCol("Units", NSHTML.Types.Number);
                    htm.AddCol("Amount", NSHTML.Types.Number);
                    htm.AddCol("%", NSHTML.Types.Text);
                    htm.AddCol("Total", NSHTML.Types.Number);
                    htm.Show(Page);
                    break;
                case "113A":
                    int Found = -1;
                    int position = 0;
                    String clientName = core.Grid.TextBoxValue("CLIENTNAME").ToUpper();
                    //var Util = new ContaNet.Tools.Util(Page);
                    String[,] TA;
                    TA = util.Tab2Array(File.ReadAllText(Server.MapPath(".") + @"\data\mytest.txt", System.Text.Encoding.ASCII));

                    tope = TA.GetUpperBound(0);
                    String[] clients = new String[tope];

                    if (clientName == "")
                    {
                        for (int x = 0; x < tope; x++)
                        {
                            clients[x] = TA[x, 0] + " - " + TA[x, 1].Trim() + " " + TA[x, 2];
                        }
                        show.List("Select one", clients, "113B");
                    }
                    else
                    {

                        for (int x = 0; x <= tope; x++)
                        {
                            if (TA[x, 1].Trim().ToUpper().Contains(clientName))
                            {
                                Found += 1;
                                position = x;
                                // Array.Resize(ref clients, Found);
                                clients[Found] = TA[x, 0] + " - " + TA[x, 1].Trim() + " " + TA[x, 2];
                            }
                        }

                        switch (Found)
                        {
                            case -1:
                                show.Message("Client not found");
                                break;
                            case 0:
                                //var grdreturn = new ContaNet.Tools.NSShow.GridValues();
                                grdreturn.SetTextValue("ClientID", TA[position, 0]);
                                grdreturn.SetTextValue("ClientName", TA[position, 1].Trim() + " " + TA[position, 2]);
                                grdreturn.Setfocus(0, 0);
                                grdreturn.ReturnValues(Page);
                                break;
                            default:
                                show.List("Select one", clients, "113B");
                                break;
                        }
                    }
                    break;

                case "113B":
                    var grdreturnn = new ContaNet.Tools.NSShow.GridValues();
                    grdreturnn.SetTextValue("ClientID", core.Values[0].Substring(0, core.Values[0].IndexOf(" ")));
                    grdreturnn.SetTextValue("ClientName", core.Values[0].Substring(core.Values[0].IndexOf("-") + 2));
                    grdreturnn.Setfocus(0, 0);
                    grdreturnn.ReturnValues(Page);
                    break;

                case "113C":
                    var util1 = new ContaNet.Tools.NSUtil(Page);
                    int row1;
                    row1 = core.Grid.Row();
                    var grdreturn1 = new ContaNet.Tools.NSShow.GridValues();

                    nfi_g0.CurrencyGroupSeparator = ".";
                    System.Globalization.NumberFormatInfo nfi_g1 = new System.Globalization.NumberFormatInfo();
                    nfi_g1.CurrencyGroupSeparator = ".";
                    importe = Convert.ToDouble(core.Grid.CellValue(row1, 2)) * Convert.ToDouble(core.Grid.CellValue(row1, 3));
                    System.Globalization.NumberFormatInfo nfi_g2 = new System.Globalization.NumberFormatInfo();
                    nfi_g2.CurrencyGroupSeparator = ".";
                    descuento = importe * Convert.ToDouble(core.Grid.CellValue(row1, 4)) * 0.01;
                    importe -= descuento;
                    grdreturn1.AddColValue(row1, 5, util.NSFormat(importe, ""));
                    grdreturn1.ReturnValues(Page);
                    break;

                case "113D":
                case "113E":
                case "113G":
                    int FocusCol = 0;
                    int Counter = -1;
                    AR = util.Tab2Array(System.IO.File.ReadAllText(Server.MapPath(".") + @"\data\Artic.txt"));
                    tope = AR.GetUpperBound(0);
                    if (core.Funct == "113G")
                    {
                        des1 = core.Grid.CellValue(core.Grid.Row(), core.Grid.Col());
                        des1 = des1.Substring(0, des1.IndexOf(" "));
                        if (des1 == "")
                        {
                            return;
                        }
                    }
                    else
                    {
                        des1 = core.Grid.CellValue(core.Grid.Row(), core.Grid.Col());
                    }

                    if (des1 == "" | des1 == "0")
                    {
                        Array.Resize(ref Artic, tope);
                        for (int x = 0; x < tope; x++)
                        {
                            Artic[x] = AR[x, 0] + " " + AR[x, 1];
                        }
                        show.List("Choose one", Artic, "113G");
                        return;
                    }
                    //int row = core.Grid.Row;
                    //var grdreturn = new ContaNet.Tools.NSShow.GridValues();
                    if (core.Funct == "113E")
                    {
                        des1 = "*" + des1.ToUpper() + "*";
                        FocusCol = 1;
                    }
                    Found = -1;
                    if (des1 == "")
                    {
                        grdreturn.Setfocus(core.Grid.Row(), 0);
                        grdreturn.ReturnValues(Page);
                    }
                    else
                    {
                        for (int x = 0; x <= tope; x++)
                        {
                            switch (core.Funct)
                            {
                                case "113D":
                                case "113G":
                                    if (AR[x, 0].Trim() == des1.Trim())
                                    {
                                        Found = x;
                                    }
                                    break;
                                case "113E":
                                    if (AR[x, 1].ToUpper() == des1)
                                    {
                                        Found = x;
                                        Counter += 1;
                                        Array.Resize(ref Artic, Counter);
                                        Artic[Counter] = AR[x, 0] + " " + AR[x, 1];
                                    }
                                    break;
                            }
                        }
                        if (Found > -1)
                        {
                            if (Counter > 0)
                            {
                                show.List("Choose one", Artic, "113G");
                                return;
                            }
                            grdreturn.AddColValue(core.Grid.Row(), 0, AR[Found, 0]);
                            grdreturn.AddColValue(core.Grid.Row(), 1, AR[Found, 1]);
                            grdreturn.AddColValue(core.Grid.Row(), 2, "1");
                            grdreturn.AddColValue(core.Grid.Row(), 3, AR[Found, 3]);
                            grdreturn.AddColValue(core.Grid.Row(), 4, "10");
                            importe = Convert.ToDouble(AR[Found, 3]);
                            descuento = importe * 10 * 0.01;
                            importe -= descuento;
                            grdreturn.AddColValue(core.Grid.Row(), 5, util.NSFormat(importe, "###,###,##0.00"));
                            grdreturn.SetTextValue("Total", util.NSFormat(GetTotal(core.Grid) + importe, "###,###,##0.00"));
                            grdreturn.Setfocus(core.Grid.Row() + 1, FocusCol);
                        }
                        else
                        {
                            grdreturn.Setfocus(core.Grid.Row(), 0);
                        }
                        grdreturn.ReturnValues(Page);
                    }
                    break;

                case "113F":
                case "113H":
                    var util3 = new ContaNet.Tools.NSUtil(Page);
                    String ruta = System.IO.File.ReadAllText(Server.MapPath(".") + "\\data\\Mytest.txt");
                    String valueT = "ID\r\nFirst Name\r\nLast Name\r\nPhone\r\nTitleCompany\r\nSales\r\nChecked\r\n,";
                    String[] Titles = Regex.Split(valueT, "\r\n");
                    String valueTY;
                    valueTY = "0\r\n0\r\n0\r\n0\r\n0\r\n3\r\n30\r";
                    String[] Types = Regex.Split(valueTY, "\r\n");
                    String ValueW;
                    ValueW = "5\r\n35\r\n35\r\n13\r\n35\r\n35\r\n13\r\n1\r\n,";
                    String[] Width = Regex.Split(ValueW, "\r\n");
                    AR = util3.Tab2Array(ruta);
                    int ClientNumber = 0;

                    for (int x = 0; x <= AR.GetUpperBound(0) - 1; x++)
                    {
                        if (ClientNumber < Convert.ToInt32(AR[x, 0])) ClientNumber = Convert.ToInt32(AR[x, 0]);
                    }
                    ClientNumber += 1;
                    //var m55 = new NSMenu();
                    m.Funct = "333A";
                    m.HiddenData = Convert.ToString(ClientNumber);
                    m.Caption = "Create a new client: ID=" + Convert.ToString(ClientNumber);
                    m.AddImage("images/clients/photo.jpg", 150, 150, NSEnums.Align2.MiddleLeft, "IMAGECLICK");
                    for (int y = 1; y <= Titles.Length - 2; y++)
                    {
                        if (y == 3)
                        {
                            m.AddItem("Telephone", NSEnums.NSVars.MaskedEdit, 14, "", "(###) ###-####");
                        }
                        else {
                            m.AddItem(Titles[y], (NSEnums.NSVars)Convert.ToInt32(Types[y]), Convert.ToInt32(Width[y]), "");
                        }

                    }
                    m.Show(Page);
                    break;

                case "114":
                    var htm3 = new NSHTML();
                    htm3.Funct = "114A";
                    htm3.Caption = "Price list";
                    htm3.AddCol("Units", NSHTML.Types.MultipleSelection);
                    htm3.AddCol("Description", NSHTML.Types.Text);
                    htm3.AddCol("Price (in Euros)", NSHTML.Types.Number);
                    String Seleccion = "0,1,2,3,4,5,6,7,8,9,10";
                    Txt.Append(Seleccion + "\t" + "User license (valid for two servers)" + "\t" + "395" + Environment.NewLine);
                    Txt.Append(Seleccion + "\t" + "Aditional licenses" + "\t" + "175" + Environment.NewLine);
                    Txt.Append(Seleccion + "\t" + "Pack of 10 licenses" + "\t" + "1500" + Environment.NewLine);
                    Txt.Append(Seleccion + "\t" + "Pack of 100 licenses" + "\t" + "10000" + Environment.NewLine);
                    Txt.Append("_Updates" + Environment.NewLine);
                    Txt.Append(Seleccion + "\t" + "Includes all updates for one year (per license)" + "\t" + "90" + Environment.NewLine);
                    Txt.Append(Seleccion + "\t" + "Silver assistance plan (one year)" + "\t" + "390" + Environment.NewLine);
                    Txt.Append(Seleccion + "\t" + "Glod assistance plan (one year)" + "\t" + "780" + Environment.NewLine);
                    htm3.Text = Txt.ToString();
                    htm3.Show(Page);
                    break;

                case "114A":
                    //System.Diagnostics.Debugger.Break();
                    break;

                case "12":
                    var grd3 = new NSGrid();
                    grd3.Caption = "Clients";
                    grd3.HelpFile = "info.html";
                    grd3.ActivateDeleteLines = true;
                    grd3.ActivateInsertLines = true;
                    grd3.AddCol("ID", NSEnums.NSVars.NonModifiableText, 10, "111");
                    grd3.AddCol("First Name", NSEnums.NSVars.Text, 35, "");
                    grd3.AddCol("Last Name", NSEnums.NSVars.Text, 35);
                    grd3.AddCol("Phone", NSEnums.NSVars.MaskedEdit, 13, "(###) ###-####");
                    grd3.AddCol("Title", NSEnums.NSVars.Text, 40);
                    grd3.AddCol("Company", NSEnums.NSVars.Text, 35);
                    grd3.AddCol("Sales", NSEnums.NSVars.Number_2dec, 12);
                    grd3.AddCol("Checked", NSEnums.NSVars.Checkbox, 1);
                    grd3.ASPXPage = "Webform1.aspx";
                    grd3.Funct = "111";
                    grd3.Clip = System.IO.File.ReadAllText(Server.MapPath(".") + @"\data\mytest.txt");
                    grd3.CenterScreen = true;
                    grd3.Show(Page);
                    break;
                case "CANCEL":
                    // Stop
                    break;
                case "CANCEL1":
                    //Stop
                    break;
                case "CLEAR":
                    //var ContaNet.Tools.NSShow.GridValues grdreturn = new ContaNet.Tools.NSShow.GridValues();
                    grdreturn.Clear = true;
                    grdreturn.Setfocus(0, 1);
                    grdreturn.ReturnValues(Page);
                    break;
                case "CLIP":
                    //var grdreturn = new ContaNet.Tools.NSShow.GridValues();
                    grdreturn.Clip(System.IO.File.ReadAllText(Server.MapPath(".") + @"\data\mytest.txt"));
                    grdreturn.ReturnValues(Page);
                    break;

                case "STYLE1":
                    //String[] config;
                    config = GetStyle();

                    String Numbers = "0";
                    for (int x = 10; x <= 300; x += 10) { Numbers += "," + x; }
                    String Numbers2 = "5";
                    for (int x = 6; x <= 40; x++) { Numbers2 += "," + x; }
                    if (Convert.ToDouble(config[11]) > 40)
                    {
                        config[11] = "20";
                    }
                    m.Funct = "13A";
                    m.Caption = "Page style";
                    m.AddItem("Background", NSEnums.NSVars.MultipleSelection, 0, GetBackground(), config[0]);
                    m.AddItem("Center background", NSEnums.NSVars.Checkbox, 0, config[1]);
                    m.AddItem("Menu background image", NSEnums.NSVars.MultipleSelection, 0, GetBackground(), config[2]);
                    m.AddItem("Menu color", NSEnums.NSVars.Colors, 0, config[3]); //?
                    m.AddItem("Menu border width", NSEnums.NSVars.MultipleSelection, 0, "1,2,3,4,5,6,7,8,9", config[4]);
                    m.AddItem("Menu border style", NSEnums.NSVars.BorderStyle, 0, config[5]);
                    m.AddItem("Menu font color", NSEnums.NSVars.Colors, 0, config[6]);
                    m.AddItem("No scrollbars", NSEnums.NSVars.Checkbox, 0, config[7]);
                    m.AddItem("Menu background color", NSEnums.NSVars.Colors, 0, config[8]);
                    m.AddItem("Menu border radius", NSEnums.NSVars.MultipleSelection, 0, Numbers, config[9]);
                    m.AddItem("Menu font family", NSEnums.NSVars.FontNames, 0, config[10]);
                    m.AddItem("Menu font size", NSEnums.NSVars.MultipleSelection, 0, Numbers2, config[11]);
                    m.AddItem("Menu border color", NSEnums.NSVars.Colors, 0, config[12]);
                    m.AddItem("Background Color", NSEnums.NSVars.Colors, 0, config[13]);
                    m.AddItem("Icon Style", NSEnums.NSVars.MultipleSelection, 0, "1,2", config[14]);
                    m.AddItem("Icon Columns", NSEnums.NSVars.MultipleSelection, 0, "1,2,3,4,5,6,7,8,9,10,11,12", config[15]);
                    m.AddItem("Menu gradient color", NSEnums.NSVars.Colors, 0, config[16]);
                    m.AddItem("Menu font color 1", NSEnums.NSVars.Colors, 0, config[17]);
                    m.AddItem("Menu font color 2", NSEnums.NSVars.Colors, 0, config[18]);
                    m.AddItem("Menu font color 3", NSEnums.NSVars.Colors, 0, config[19]);
                    m.AddItem("Shadow", NSEnums.NSVars.Checkbox, 1, config[20]);
                    m.Show(Page);

                    break;

                case "STYLE2":
                    //var m54 = new NSMenu();
                    m.Funct = "STYLE2A";
                    m.Caption = "Save current style";
                    m.AddLabel("The style will be available to other users of the demo", NSEnums.LabelColor.Bold, NSEnums.Align.Center);
                    m.AddItem("Name for the current style", NSEnums.NSVars.Text, 30);
                    m.Show(Page);

                    break;

                case "STYLE2A":
                    try
                    {

                        FileName = core.Menu.GetValue(1);
                        if (FileName.Trim().Length < 2) show.ErrorMessage("Please include a proper file name");
                        System.IO.File.Copy(Server.MapPath(".") + @"\data\style.txt", Server.MapPath(".") + @"\data\styles\" + FileName + ".txt");
                        show.CloseCallingWindow();

                    }
                    catch (Exception ex)
                    {
                        show.ErrorMessage(ex.Message);
                    }
                    break;


                case "STYLE3":
                    //var m = new NSMenu();
                    m.Funct = "STYLE3A";
                    m.Caption = "Try a style";
                    m.AddItem("Select one", ContaNet.Tools.NSEnums.NSVars.MultipleSelection, 0, GetFiles(Server.MapPath(".") + @"\data\styles"));
                    m.Show(Page);
                    break;

                case "STYLE3A":
                    String FileName1 = core.Menu.GetValue(0);
                    if (!System.IO.File.Exists(Server.MapPath(".") + @"\data\styles\" + FileName1)) show.ErrorMessage("File does not exist");
                    System.IO.File.Copy(Server.MapPath(".") + @"\data\styles\" + FileName1, Server.MapPath(".") + @"\data\style.txt", true);
                    show.Reload();
                    break;

                case "13A":
                    for (int x = 0; x <= core.Menu.Count(); x++)
                    {
                        sb.Append(core.Menu.GetValue(x) + ",");
                    }
                    File.WriteAllText(Server.MapPath(".") + @"\data\style.txt", sb.ToString(), System.Text.Encoding.ASCII);
                    util.set_Cookie("STYLE", DateTime.Now.AddDays(1), "STYLE.TXT");
                    show.Reload();
                    break;
                case "32C":
                case "32A":
                    //var htm = new ContaNet.Tools.NSHTML();
                    htm.Top = "0px";
                    htm.Left = "0px";
                    //htm.Height = "300px";
                    //htm.BorderWidth = 1;
                    htm.Caption = "HTML TEST";
                    htm.BackgroundColor = "white";
                    htm.TextColor = "black";
                    htm.NewPageIcon = true;
                    if (core.Funct == "32A") htm.FullScreen = true;
                    htm.Header = DateTime.Now.ToLongDateString();
                    htm.AddButton("Add new client", "images/newclient.png", "", "113H");
                    htm.Text = System.IO.File.ReadAllText(Server.MapPath(".") + @"\data\mytest.txt");
                    //  htm.AddCol(SpecialColumns.CSSClass)
                    htm.AddCol("ID", NSHTML.Types.Text, 0, NSEnums.Align.Left, "odd");
                    htm.AddCol("First Name", NSHTML.Types.Text, 0, NSEnums.Align.Left, "even");
                    htm.AddCol("Last Name", NSHTML.Types.Text, 0, NSEnums.Align.Left, "odd");
                    htm.AddCol("Phone", NSHTML.Types.Text, 13, NSEnums.Align.Left, "even");
                    htm.AddCol("Title", NSHTML.Types.Text, 0, NSEnums.Align.Left, "odd");
                    htm.AddCol("Company", NSHTML.Types.Text, 0, NSEnums.Align.Left, "even");
                    htm.AddCol("Sales", NSHTML.Types.Number, 0, NSEnums.Align.Right, "odd");
                    htm.AddCol("Checked", NSHTML.Types.Text, 0, NSEnums.Align.Center, "even");
                    htm.Show(Page);
                    break;

                case "32B": // case "32C":
                    htm.Top = "100px";
                    htm.Left = "100px";
                    htm.Height = "300px";
                    htm.BorderWidth = 0;
                    htm.Caption = "HTML TEST";
                    htm.BackgroundColor = "white";
                    htm.TextColor = "black";
                    htm.NewPageIcon = true;
                    if (core.Funct == "32A") htm.FullScreen = true;
                    htm.Header = DateTime.Now.ToLongDateString();
                    string txt = System.IO.File.ReadAllText(Server.MapPath(".") + @"\data\mytest.txt");
                    string[] tx = txt.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    //var sb = new System.Text.StringBuilder();
                    int count = 0;
                    for (int x = 0; x <= tx.GetUpperBound(0); x++)
                    {
                        if (x % 10 == 0)
                        {
                            count += 1;
                            sb.Append("_subheading" + "\t" + "Group " + count + Environment.NewLine);
                            sb.Append("*subheading2" + "\t" + "ID" + "\t" + "First Name" + "\t" + "Last Name" + "\t" + "Phone" + "\t" + "Title" + "\t" + "Company" + "\t" + "Sales" + "\t" + "Checked" + Environment.NewLine);
                        }
                        if (x % 2 == 0)
                        {
                            sb.Append("even" + "\t" + tx[x] + Environment.NewLine); // modify class in Webform1.aspx
                        }
                        else
                        {
                            sb.Append("odd" + "\t" + tx[x] + Environment.NewLine);
                        }
                    }
                    htm.Text = sb.ToString();
                    htm.AddRowClassCol();
                    htm.AddCol("", NSHTML.Types.Text);
                    htm.AddCol("", NSHTML.Types.Text);
                    htm.AddCol("", NSHTML.Types.Text);
                    htm.AddCol("", NSHTML.Types.Text, 13);
                    htm.AddCol("", NSHTML.Types.Text);
                    htm.AddCol("", NSHTML.Types.Text);
                    htm.AddCol("", NSHTML.Types.Number);
                    htm.AddCol("", NSHTML.Types.Text);
                    htm.Show(Page);
                    break;

                case "33":
                case "33A":

                    htm.Caption = "HTML TEST";
                    htm.HiddenData = "Data from HTML";
                    htm.NewPageIcon = true;
                    htm.BackgroundColor = "white";
                    htm.TextColor = "black";
                    htm.Header = DateTime.Now.ToLongDateString();
                    htm.Text = System.IO.File.ReadAllText(Server.MapPath(".") + @"\data\mytest.txt");
                    htm.AddHyperlinkCol("ID", 1, "333", "33A");
                    htm.AddCol("First Name", NSHTML.Types.Text);
                    htm.AddCol("Last Name", NSHTML.Types.Text);
                    htm.AddCol("Phone", NSHTML.Types.Text, 13);
                    htm.AddCol("Title", NSHTML.Types.Text);
                    htm.AddCol("Company", NSHTML.Types.Text);
                    htm.AddCol("Sales", NSHTML.Types.Number);
                    htm.AddCol("Checked", NSHTML.Types.Text);
                    htm.Show(Page);
                    break;

                case "34":
                case "34A":
                    htm.Caption = "HTML TEST";
                    htm.Header = DateTime.Now.ToLongDateString();
                    htm.BorderWidth = 1;
                    htm.BorderColor = "darkblue";
                    htm.PositiveNumberColor = "black";
                    htm.NegativeNumberColor = "black";
                    htm.BackgroundColor = "antiquewhite";
                    htm.TextColor = "black";
                    htm.Text = System.IO.File.ReadAllText(Server.MapPath(".") + @"\data\mytest.txt");
                    htm.AddCol("ID", NSHTML.Types.Invisible);
                    htm.AddHyperlinkCol("First Name", 1, "333", "34A");
                    htm.AddCol("Last Name", NSHTML.Types.Text);
                    htm.AddCol("Phone", NSHTML.Types.Text, 13);
                    htm.AddCol("Title", NSHTML.Types.Text);
                    htm.AddCol("Company", NSHTML.Types.Text);
                    htm.AddCol("Sales", NSHTML.Types.Number);
                    htm.AddCol("Checked", NSHTML.Types.Text);
                    htm.Show(Page);

                    break;

                case "35":
                    var htm1 = new ContaNet.Tools.NSHTML();
                    htm1.Caption = "HTML TEST";
                    htm1.HiddenData = "Test";
                    htm1.Header = DateTime.Now.ToLongDateString();
                    htm1.BorderWidth = 1;
                    htm1.BorderColor = "chocolate";
                    htm1.BackgroundColor = "beige";
                    htm1.TextColor = "black";
                    htm1.Funct = "335";
                    htm1.Text = System.IO.File.ReadAllText(Server.MapPath(".") + @"\data\mytest.txt");
                    htm1.AddCol("ID", NSHTML.Types.Text);
                    htm1.AddEditableCol("First Name", 1, 0, 25);
                    htm1.AddCol("Last Name", NSHTML.Types.Text);
                    htm1.AddCol("Phone", NSHTML.Types.Text, 13);
                    htm1.AddCol("Title", NSHTML.Types.Text);
                    htm1.AddCol("Company", NSHTML.Types.Text);
                    htm1.AddCol("Sales", NSHTML.Types.Number);
                    htm1.AddCol("Checked", NSHTML.Types.Text);
                    htm1.Show(Page);
                    break;
                case "36": // checkbox
                    var htm2 = new ContaNet.Tools.NSHTML();
                    htm2.TextColor = "black";
                    htm2.Caption = "HTML TEST";
                    htm2.Funct = "360";
                    htm2.Header = DateTime.Now.ToLongDateString();
                    htm2.Text = System.IO.File.ReadAllText(Server.MapPath(".") + @"\data\mytest.txt");
                    htm2.AddCol("ID", NSHTML.Types.Text);
                    htm2.AddCol("First Name", NSHTML.Types.Text);
                    htm2.AddCol("Last Name", NSHTML.Types.Text);
                    htm2.AddCol("", NSHTML.Types.Invisible);
                    htm2.AddCol("", NSHTML.Types.Invisible);
                    htm2.AddCol("", NSHTML.Types.Invisible);
                    htm2.AddCol("", NSHTML.Types.Invisible);
                    htm2.AddCol(NSHTML.SpecialColumns.Checkbox, "Check", 1, "");
                    htm2.Show(Page);
                    break;
                case "HTMIMAGE":
                    htm.Caption = "Clients";
                    htm.HiddenData = "Data from HTML";
                    htm.NewPageIcon = true;
                    htm.BackgroundColor = "white";
                    htm.TextColor = "black";
                    htm.Header = DateTime.Now.ToLongDateString();
                    string CurrentPath = Server.MapPath(".") + @"\images\clients\";
                    String[,] Text2;
                    Text2 = util.Tab2Array(File.ReadAllText(Server.MapPath(".") + @"\data\mytest.txt"));
                    string ImageName = "";
                    for (int x = 0; x <= Text2.GetUpperBound(0); x++)
                    {
                        if (sb.Length > 0) sb.Append(Environment.NewLine);
                        for (int y = 0; y <= Text2.GetUpperBound(1); y++)
                        {
                            switch (y)
                            {
                                case 0:
                                    if (File.Exists(CurrentPath + "PHOTO" + Text2[x, y] + ".JPG"))
                                    {
                                        //Random rnd = new Random();
                                        ImageName = "images/clients/photo" + Text2[x, y] + ".jpg" + "?" + Convert.ToString(rnd.Next(1000000));
                                    }
                                    else
                                    {
                                        ImageName = "images/clients/photo.jpg";
                                    }
                                    sb.Append(Text2[x, y] + "\t" + ImageName);
                                    break;
                                default:
                                    sb.Append("\t" + Text2[x, y]);
                                    break;
                            }
                        }
                    }
                    htm.Text = sb.ToString();
                    htm.AddCol("ID", NSHTML.Types.Invisible);
                    htm.AddImageCol("Image", 50, 50, "", 1, "333", "HTMIMAGE");
                    htm.AddCol("First Name", NSHTML.Types.Text);
                    htm.AddCol("Last Name", NSHTML.Types.Text);
                    htm.AddCol("Phone", NSHTML.Types.Text);
                    htm.AddCol("Title", NSHTML.Types.Text);
                    htm.AddCol("Company", NSHTML.Types.Text);
                    htm.AddCol("Sales", NSHTML.Types.Number);
                    htm.AddCol("Checked", NSHTML.Types.Text);
                    htm.Show(Page);
                    break;
                case "ARTIMAGECLICK":
                    m.HiddenData = core.HiddenData;
                    m.Caption = "New Photo";
                    m.Funct = "UPLOADARTPHOTO";
                    m.AddItem("Photo", NSEnums.NSVars.FileUpload, 0);
                    m.Show(Page);
                    break;
                case "UPLOADARTPHOTO":
                    string photo = core.Values[0];
                    File.Copy(Server.MapPath(".") + @"\uploads\" + core.Values[0], Server.MapPath(".") + @"\IMAGES\articles\PHOTO" + core.HiddenData + ".JPG", true);
                    rm.SetTextValue(0, "images/articles/photo" + core.HiddenData + ".jpg?" + Convert.ToString(aa));
                    rm.ReturnValues(Page);
                    break;
                case "IMAGECLICK":
                    m.HiddenData = core.HiddenData;
                    m.Caption = "New Photo";
                    m.Funct = "UPLOADPHOTO";
                    m.AddItem("Photo", NSEnums.NSVars.FileUpload, 0);
                    m.Show(Page);
                    break;

                case "UPLOADPHOTO":
                    File.Copy(Server.MapPath(".") + @"\uploads\" + core.Values[0], Server.MapPath(".") + @"\IMAGES\CLIENTS\PHOTO" + core.HiddenData + ".JPG", true);
                    rm.SetTextValue(0, "images/clients/photo" + core.HiddenData + ".jpg?" + Convert.ToString(aa));
                    rm.ReturnValues(Page);
                    //show.CloseCallingWindow()
                    break;
                case "333":
                    string Photo = "";
                    AR = util.Tab2Array(File.ReadAllText(Server.MapPath(".") + @"\data\mytest.txt"));
                    string titulos = "ID,First Name,Last Name,Phone,Title,Company,Sales,Checked";
                    string tipos = "0,0,0,202,0,0,3,30";
                    string anchos = "5,35,35,13,35,35,13,1";
                    string mascaras = ",,,(###)###-####,,,,";
                    Titles = titulos.Split(',');
                    Types = tipos.Split(',');
                    String[] Widths = anchos.Split(',');
                    String[] Masks = mascaras.Split(',');
                    //tope = AR.GetUpperBound(1);
                    for (int x = 0; x <= AR.GetUpperBound(1); x++)
                    {
                        if (AR[x, 0] == core.Values[0])
                        {
                            if (File.Exists(Server.MapPath(".") + @"\IMAGES\CLIENTS\PHOTO" + core.Values[0] + ".JPG"))
                            {
                                Photo = "PHOTO" + core.Values[0] + ".JPG";
                                rnd = new Random();
                                aa = rnd.Next(1000000);

                                Photo += "?" + Convert.ToString(aa);
                            }
                            else
                            {
                                Photo = "Photo.jpg";
                            }
                            Photo = "images/clients/" + Photo;
                            m.Funct = "333A";
                            m.HiddenData = core.Values[0];
                            m.Caption = "Edit client data";
                            m.AddImage(Photo, 150, 150, NSEnums.Align2.MiddleLeft, "IMAGECLICK");
                            for (int y = 1; y <= Titles.GetUpperBound(0); y++)
                            {
                                switch (Types[y])
                                {
                                    case "0":
                                        tipovar = NSEnums.NSVars.Text;
                                        break;
                                    case "202":
                                        tipovar = NSEnums.NSVars.MaskedEdit;
                                        break;
                                    case "3":
                                        tipovar = NSEnums.NSVars.Number_2dec; //NSDouble;
                                        break;
                                    case "30":
                                        tipovar = NSEnums.NSVars.Checkbox;
                                        break;
                                }
                                m.AddItem(Titles[y], tipovar, Convert.ToInt32(Widths[y]), AR[x, y], Masks[y]);
                            }
                            m.Show(Page);
                        }
                    }
                    break;
                case "333A":
                    if (core.Menu.GetValue(1).Trim() == "")
                    {
                        show.Message("A name must be assigned to the client");
                    }
                    String NewClient = "";
                    bool found = false;
                    AR = util.Tab2Array(File.ReadAllText(Server.MapPath(".") + @"\data\mytest.txt"));
                    String ID = core.HiddenData;
                    tope = AR.GetUpperBound(0);
                    for (int x = 0; x <= tope; x++)
                    {
                        if (AR[x, 0] == ID)
                        {
                            int tope2 = AR.GetUpperBound(1);
                            for (int yy = 1; yy <= tope2; yy++)
                            {
                                if (AR[x, yy].Trim() != core.Menu.GetValue(yy).Trim())
                                {
                                    found = true;
                                    AR[x, yy] = core.Menu.GetValue(yy).Trim();
                                }
                            }
                        }
                    }
                    if (!found)
                    {
                        NewClient += Environment.NewLine;
                        NewClient += core.HiddenData;
                        for (int y = 1; y <= core.Menu.Count(); y++)
                        {
                            NewClient += "\t" + core.Menu.GetValue(y - 1).Trim();
                        }
                    }
                    File.WriteAllText(Server.MapPath(".") + @"\data\mytest.txt", util.Array2Tab(AR) + NewClient, System.Text.Encoding.ASCII);
                    show.CloseCallingWindow();
                    break;


                case "CREATECLIENT":
                case "CREATECLIENT2":

                    var utilidad = new ContaNet.Tools.NSUtil(Page);
                    String aux = "ID,First Name,Last Name,Phone,Title,Company,Sales,Checked";
                    String[,]AR3 = utilidad.Tab2Array(File.ReadAllText(Server.MapPath(".") + @"\data\mytest.txt"));
                    String[] Titles2 = aux.Split(',');
                    String[] Type = "0,0,0,0,0,0,3,30".Split(',');
                    string[] Widths2 = "5,35,35,13,35,35,13,1".Split(',');

                    int ClientNumber2 = GetNextClient();
                    var m2 = new NSMenu(Page);

                    m2.Funct = "CREATECLIENT3";
                    m2.HiddenData = ClientNumber2.ToString();
                    string aux2 = ClientNumber2.ToString();
                    m2.Caption = "Create a new client: ID=" + aux2 ;
                    m2.AddImage("images/clients/photo.jpg", 150, 150, NSEnums.Align2.MiddleLeft, "IMAGECLICK");
                    for (int y = 0; y <= Titles2.Length; y++)
                    {

                        if (y == 3){

                            m2.AddItem("Telephone", NSEnums.NSVars.MaskedEdit, 14, "", "(###) ###-####");
                        
                                }
                        else {


                            if (Type[y] == "0")
                            {

                                m2.AddItem(Titles2[y], NSEnums.NSVars.Text, Int32.Parse(Widths2[y]), "");

                            } else if (Type[y] == "3")
                            {

                                m2.AddItem(Titles2[y], NSEnums.NSVars.Number, Int32.Parse(Widths2[y]), "");

                            }
                            else if (Type[y] == "30")
                            {

                                m2.AddItem(Titles2[y], NSEnums.NSVars.Checkbox, Int32.Parse(Widths2[y]), "");

                            }

                            //m2.AddItem(Titles2[y], NSEnums.NSVars.Type[y] , Int32.Parse(Widths2[y]), "");
                        
                        }
                      

                    }
                    m2.HelpFile = "helpfiles/Code for creating a client.htm";
                   m2.Show(Page);
               
                break;

                case "CREATECLIENT3":
                case "CREATECLIENT4":
                    aux = core.Menu.GetValue(1).Trim();
                    if ( aux == "" ) {
                        show.Message("A name must be assigned to the client");
                    }

                    string NewClient2 = "";
                    bool found2 = false;
                    bool Found3 = false;
                    var util4 = new ContaNet.Tools.NSUtil(Page);
                    string[,] AR2 = util.Tab2Array(File.ReadAllText(Server.MapPath(".") + @"\data\mytest.txt"));
                    string ID2 = core.HiddenData;
                    try {

                        if (Int32.Parse(ID2) > GetNextClient()) {

                            show.Message("Invalid client id");
                            break;
                        }

                    }
                    catch (Exception ex) {
                        show.Message("Invalid client id");
                    }
                    if (core.Funct == "CREATECLIENT4") {
                        for (int x = 0; x <= AR2.Length; x++) {

                            if (AR2[x, 0] == ID2)
                            {

                                Found3 = true;
                                for (int yy = 1; yy <= AR2.Length - 1; yy++)
                                {
                                    aux = core.Menu.GetValue(yy).Trim();
                                    if (AR2[x, yy].Trim() != aux) {
                                        found2 = true;
                                        AR2[x, yy] = core.Menu.GetValue(yy);
                                    }

                                }



                            }

                        }
                    }

                    else {
                        if (!Found3)
                        {

                            NewClient2 += Environment.NewLine;
                            NewClient2 += core.HiddenData;
                            int aux3 = core.Menu.Count();
                            for (int yyy = 0; yyy <= aux3 ; yyy++) {
                                NewClient2 += "\t" + core.Menu.GetValue(yyy).Trim();
                            }

                        }
                    
                    }
                    
                File.WriteAllText(Server.MapPath(".") + @"\data\mytest.txt", util4.Array2Tab(AR2) + NewClient2);

                show.CloseCallingWindow();
                break;
                case "334":
                    show.Message("Invisible column " + core.Values[0]);
                    break;
                case "335":
                    // core.Values contains modified values
                    found = false;
                    AR = util.Tab2Array(File.ReadAllText(Server.MapPath(".") + @"\data\mytest.txt"));
                    tope = AR.GetUpperBound(1);
                    for (int x = 0; x <= tope; x++)
                    {
                        string Value = core.HTML.GetEditText(AR[x, 0]).Value;
                        if (AR[x, 1].Trim() != Value.Trim())
                        {
                            found = true;
                            AR[x, 1] = Value.Trim();
                        }
                    }
                    if (found) File.WriteAllText(Server.MapPath(".") + @"\data\mytest.txt", util.Array2Tab(AR), System.Text.Encoding.ASCII);
                    show.CloseCallingWindow();
                    break;
                case "360":
                    found = false;
                    AR = util.Tab2Array(File.ReadAllText(Server.MapPath(".") + @"\data\mytest.txt"));
                    tope = AR.GetUpperBound(1);
                    for (int x = 0; x <= tope; x++)
                    {
                        string NewValue = core.HTML.GetCheckbox(AR[x, 0]).Value;
                        if (AR[x, 7].Trim() != NewValue.Trim())
                        {
                            found = true;
                            AR[x, 7] = NewValue.Trim();
                        }
                    }
                    if (found) File.WriteAllText(Server.MapPath(".") + @"\data\mytest.txt", util.Array2Tab(AR), System.Text.Encoding.ASCII);
                    show.CloseCallingWindow();
                    break;
                case "370":
                case "371":
                case "372":
                case "373":
                    htm.Caption = "Clients";
                    htm.TextColor = "black";
                    htm.BackgroundColor = "white";
                    htm.NewPageIcon = false;
                    htm.Header = DateTime.Now.ToLongDateString();
                    htm.Text = File.ReadAllText(Server.MapPath(".") + @"\data\mytest.txt");
                    htm.AddCol("ID", NSHTML.Types.Text);
                    htm.AddCol("First Name", NSHTML.Types.Text);
                    htm.AddCol("Last Name", NSHTML.Types.Text);
                    htm.AddCol("Phone", NSHTML.Types.Text);
                    htm.AddCol("Title", NSHTML.Types.Text);
                    htm.AddCol("Company", NSHTML.Types.Text);
                    htm.AddCol("Sales", NSHTML.Types.Number);
                    htm.AddCol("Checked", NSHTML.Types.Invisible);
                    int Pos = Convert.ToInt32(core.Funct) - 370;
                    switch (Pos)
                    {
                        case 0:
                            htm.ToolBar = ToolBar2(1);
                            htm.ToolBarPosition = NSHTML.ToolbarAlign.Left;
                            break;
                        case 1:
                            htm.ToolBar = ToolBar2(10);
                            htm.ToolBarPosition = NSHTML.ToolbarAlign.Top;
                            break;
                        case 2:
                            htm.ToolBar = ToolBar2(1);
                            htm.ToolBarPosition = NSHTML.ToolbarAlign.Right;
                            break;
                        case 3:
                            htm.ToolBar = ToolBar2(10);
                            htm.ToolBarPosition = NSHTML.ToolbarAlign.Bottom;
                            break;
                    }
                    //htm.ToolBarPosition = ((NSHTML.ToolbarAlign)Convert.ToInt32(core.Funct) - 370);
                    htm.Show(Page);
                    break;
                case "200":
                    show.Video("Trailer", "http://media.w3.org/2010/05/sintel/trailer.mp4");
                    break;
                case "CNVideo":
                    show.Video("ContaNet Tools", "http://contanettools.cloudapp.net/demo/info/video/contanet tools.mp4", "images/cntools.jpg", -1, -1, 500, 700, true);
                    break;
                case "2030":
                case "2031":
                case "2032":
                case "2033":
                case "2034":
                case "2035":
                case "2036":
                case "2037":
                case "2038":
                case "2039":
                case "20310":
                case "20311":
                case "20312":
                case "20313":
                case "20314":
                case "20315":
                case "20316":
                case "20317":
                case "20318":
                case "20319":
                case "20320":
                case "20321":
                case "20322":
                case "20323":
                case "20324":
                case "20325":
                case "20326":
                case "20327":
                case "20328":
                case "20329":
                case "20330":
                case "20331":
                case "20332":
                case "20333":
                case "20334":
                case "20335":
                case "20336":
                case "20337":
                case "20338":
                case "20339":
                case "20340":
                case "20341":
                case "20342":
                case "20343":
                case "20344":
                case "20345":
                case "20346":
                case "20347":
                case "20348":
                case "20349":
                case "20350":
                case "20351":
                case "20352":
                case "20353":
                case "20354":
                case "20355":
                case "20356":
                case "20357":
                case "20358":
                case "20359":
                case "20360":
                case "20361":
                case "20362":
                case "20363":
                case "20364":
                case "20365":
                case "20366":
                case "20367":
                case "20368":
                case "20369":
                case "20370":
                case "20371":
                case "20372":
                case "20373":
                case "20374":
                case "20375":
                case "20376":
                case "20377":
                case "20378":
                case "20379":
                case "20380":
                case "20381":
                case "20382":
                case "20383":
                case "20384":
                case "20385":
                case "20386":
                case "20387":
                case "20388":
                case "20389":
                case "20390":
                case "20391":
                case "20392":
                case "20393":
                case "20394":
                case "20395":
                case "20396":
                case "20397":
                case "20398":
                case "20399":
                    string[] Files = GetFiles(Server.MapPath(".") + @"\info\video", "*.mp4").Split(Convert.ToChar(","));
                    if (File.Exists(Server.MapPath(".") + @"\info\video\" + Files[Convert.ToInt32(core.Funct.Substring(3))]))
                    {
                        show.Video(Files[Convert.ToInt32(core.Funct.Substring(3))], Server.MapPath(".") + @"\info\video\" + Files[Convert.ToInt32(core.Funct.Substring(3))]);
                    }
                    else
                    {
                        show.ErrorMessage("Folder does not exist: " + Server.MapPath(".") + @"\info\video\" + Files[Convert.ToInt32(core.Funct.Substring(3))]);
                    }
                    break;
                case "210":
                    show.Audio("More Than Words", "audio/MoreThanWords.mp3");
                    break;
                case "211":
                    tv.Funct = "3022";
                    tv.ShowFiles.Path = Server.MapPath(".") + @"\info\music";
                    tv.ShowFiles.SearchPattern = "*.mp3";
                    tv.ShowFiles.ShowEmptyFolders = false;
                    tv.ShowFiles.ReturnFullPath = true;
                    tv.Caption = "Music";
                    tv.ASPXPage = "";
                    tv.BackgroundColor = "grey";
                    tv.Show(Page);
                    break;
                case "220":
                    show.Image("Boavista, Cabo Verde", "images/test/cabo verde 204.jpg", 100, 100, 600, 0, true);
                    break;
                case "221":
                    show.Image("Maui", "images/test/maui 109.jpg");
                    break;
                case "302": case "302X": case "302N":
                    tv.Funct = "3021";
                    String funcion = core.Funct;
                    if (funcion.Equals("302")) {

                        tv.IncludePreviewOfPictureFiles(true, 70, 100);

                    } else if (funcion.Equals("302X")) {

                        tv.IncludePreviewOfPictureFiles(true, 90, 120);

                    } else if (funcion.Equals("302N")) {

                        tv.IncludePreviewOfPictureFiles(false);

                    }

                    tv.ShowFiles.Path = Server.MapPath(".") + @"\info\images";
                    tv.ShowFiles.SearchPattern = "";
                    tv.ShowFiles.ShowEmptyFolders = false;
                    tv.ShowFiles.ReturnFullPath = true;
                    tv.Caption = "Images";
                    tv.ASPXPage = "";
                    tv.BackgroundColor = "white";
                    tv.Show(Page);
                    break;
                case "3022":
                    Name = core.Values[0].Substring(core.Values[0].LastIndexOf(@"\") + 1, core.Values[0].LastIndexOf(".") - core.Values[0].LastIndexOf(@"\") - 1);
                    show.Audio(Name, core.Values[0]);
                    break;
                case "3021":
                    Name = core.Values[0].Substring(core.Values[0].LastIndexOf(@"\") + 1, core.Values[0].LastIndexOf(".") - core.Values[0].LastIndexOf(@"\") - 1);
                    show.Image(Name, core.Values[0]);
                    break;
                case "303":
                    m.Funct = "3031";
                    m.Caption = "Locate files";
                    m.AddItem("File extension", NSEnums.NSVars.MultipleSelection, 0, "jpg,xls,xlsx,doc,pdf,mp3,mp4");
                    m.AddItem("Root folder", NSEnums.NSVars.MultipleSelection, 0, "Documents,Images,Videos,Music");
                    m.AddItem("File name like", NSEnums.NSVars.Text, 20, "*");
                    m.Show(Page);
                    break;
                case "3031":
                    string Folder = "";
                    string TipoArch = "";
                    string NameLike = "";
                    try
                    {
                        Folder = core.Menu.GetValue(1);
                        NameLike = core.Menu.GetValue(2);
                        TipoArch = core.Menu.GetValue(0);

                        if (NameLike.Contains("*") | NameLike.Contains("?"))
                        {
                        }
                        else if (NameLike == "")
                        {
                            NameLike = "*";
                        }
                        else
                        {
                            NameLike = "*" + NameLike + "*";
                        }

                        switch (Folder.ToUpper())
                        {
                            case "DOCUMENTS":
                                Folder = Server.MapPath(".") + @"\info";
                                break;
                            case "IMAGES":
                                Folder = Server.MapPath(".") + @"\info\images";
                                break;
                            case "MUSIC":
                                Folder = Server.MapPath(".") + @"\info\music";
                                break;
                            default:
                                Folder = Server.MapPath(".") + @"\info";
                                break;
                        }

                    }
                    catch (Exception ex)
                    {
                        show.ErrorMessage(ex.Message);
                    }
                    tv.Funct = "3031R";
                    tv.ShowFiles.Path = Folder;
                    tv.ShowFiles.SearchPattern = NameLike + "." + TipoArch;
                    tv.ShowFiles.ShowEmptyFolders = false;
                    tv.ShowFiles.ReturnFullPath = true;
                    tv.Caption = NameLike + "." + TipoArch.ToUpper();
                    tv.BackgroundColor = "grey";
                    tv.Show(Page);
                    break;
                case "3031R":
                    ShowFile(core.Values[0]);
                    break;
                case "1301":
                    show.Message(core.Values[0]);
                    break;
                case "304": // file upload
                    m.Funct = "304A";
                    m.Caption = "Upload file";
                    m.AddItem("Upload a file", NSEnums.NSVars.FileUpload, 80);
                    m.AddItem("Present after upload", NSEnums.NSVars.SelectOption, 0, "1");
                    m.AddItem("Copy to folder", NSEnums.NSVars.SelectOption, 0, "");
                    m.AddItem("Destination folder in documents", NSEnums.NSVars.Text, 40, "ContaNetTools");
                    m.Show(Page);
                    break;
                case "304A":
                    if (!File.Exists(Page.Server.MapPath(".") + @"\uploads\" + core.Menu.GetValue(0)))
                    {
                        show.ErrorMessage("El archvio no existe");
                        return;
                    }
                    if (core.Menu.GetOption() == 1)
                    {
                        ShowFile(Page.Server.MapPath(".") + @"\uploads\" + core.Menu.GetValue(0));
                    }
                    else
                    {
                        try
                        {
                            Folder = Server.MapPath(".") + @"\info\" + core.Menu.GetValue(3);
                            if (!Directory.Exists(Folder)) Directory.CreateDirectory(Folder);
                            File.Copy(Page.Server.MapPath(".") + @"\uploads\" + core.Menu.GetValue(0), Folder + @"\" + core.Menu.GetValue(0));

                        }
                        catch (Exception ex)
                        {
                            show.ErrorMessage(ex.Message);
                        }
                        show.CloseCallingWindow();
                    }
                    break;
                case "52":
                    m.Caption = "Nuevo Evento";
                    m.ASPXPage = "WebForm1.aspx";
                    m.Funct = "52A";
                    m.AddItem("Usuario", NSEnums.NSVars.Text, 20, "");
                    m.AddItem("Fecha", NSEnums.NSVars.DateSelect, 8, DateTime.Now.ToString("dd/MM/yy"));
                    m.AddItem("Hora", NSEnums.NSVars.Text, 5, "");
                    m.AddItem("Con Aviso", NSEnums.NSVars.Checkbox, 0, "0");
                    m.AddItem("Asunto", NSEnums.NSVars.Notes, 99, "");
                    m.AddItem("Dias", NSEnums.NSVars.MultipleSelection, 0, "1,2,3,4,5,6,7,8,9,10");
                    m.AddItem("Nif Cliente", NSEnums.NSVars.Nif, 15, "");
                    m.HiddenData = core.HiddenData;
                    m.Show(Page);
                    break;
                case "52A":
                    show.Message(core.HiddenData);
                    break;
                case "55":
                    txt = "";
                    for (int x = 0; x <= core.Menu.Count(); x++)
                    {
                        txt += core.Menu.GetDescription(x) + "\t" + core.Menu.GetValue(x) + Environment.NewLine;
                    }
                    htm.BackgroundColor = "white";
                    htm.TextColor = "black";
                    htm.Caption = "DATA";
                    htm.AddCol("Description", NSHTML.Types.Text);
                    htm.AddCol("Value", NSHTML.Types.Text);
                    htm.Text = txt;
                    htm.Show(Page);
                    break;
                case "56":
                    //var grd1 = new NSGrid;
                    grd1.Caption = "Estimates";
                    grd1.Calculator = true;
                    //grd1.Calendar = true;
                    // .fullScreen = True
                    grd1.RepeatPreviousLine = true;
                    grd1.AddTextBox("Total", "", NSEnums.NSVars.Number_2dec, 12, "TotalGrid", "");
                    grd1.AddTextBox("Date", "31/12/14", NSEnums.NSVars.DateSelect, 10, "Date1", "");
                    grd1.AddTextBox("Total", "", NSEnums.NSVars.Number_2dec, 12, "TotalGrid", "", 1);
                    grd1.AddTextBox("Date", "31/12/14", NSEnums.NSVars.DateSelect, 10, "Date2", "", 1);
                    grd1.AddCol("Chanel", NSEnums.NSVars.NonModifiableNumber, 3);
                    grd1.AddCol("Date", NSEnums.NSVars.DateSelect, 8, "");
                    grd1.AddCol("Description", NSEnums.NSVars.Text, 35, "", NSEnums.Align.Left, "1111");
                    grd1.AddCol("Amount", NSEnums.NSVars.Number_2dec, 12);
                    grd1.AddCol("Check", NSEnums.NSVars.Checkbox, 1, "");
                    grd1.ASPXPage = "Webform1.aspx";
                    //  .Funct = 111
                    grd1.Rows = 10;
                    grd1.Show(Page);
                    break;
                case "58":
                    show.HTMLFile("Help file", Page.Server.MapPath(".") + @"\data\help.html");
                    break;
                case "571":
                    Folder = Server.MapPath(".") + @"\info";
                    tv.Funct = "3031R";
                    tv.ShowFiles.Path = Folder;
                    tv.ShowFiles.SearchPattern = "*.xls";
                    tv.ShowFiles.ShowEmptyFolders = false;
                    tv.ShowFiles.ReturnFullPath = true;
                    tv.Caption = "EXCEL";
                    tv.BackgroundColor = "grey";
                    tv.Show(Page);
                    break;
                case "999":
                    switch (core.Values[0])
                    {
                        case "LST":
                            var sv = new NSShow(Page);
                            sv.List("Chose a value", "ONE,TWO,THREE,FOUR".Split(Convert.ToChar(",")));
                            break;
                    }
                    break;
                case "SELARTIC":
                    txt2 = util.Tab2Array(File.ReadAllText(Server.MapPath(".") + @"\data\artic.txt"));
                    ImageName = "";
                    CurrentPath = Server.MapPath(".") + @"\images\articles\";
                    Seleccion = "0,1,2,3,4,5,6,7,8,9,10";

                    for (int x = 0; x <= txt2.GetUpperBound(0)-1; x++)
                    {
                        if (sb.Length > 0) sb.Append(Environment.NewLine);
                        //System.Globalization.NumberFormatInfo nfi_g0 = new System.Globalization.NumberFormatInfo();
                        nfi_g0.CurrencyGroupSeparator = ".";
                        if (Convert.ToDouble(txt2[x, 0], nfi_g0) > 0)
                        {
                            for (int y = 0; y <= 4; y++)
                            {
                                switch (y)
                                {
                                    case 0:
                                        sb.Append(txt2[x, y]);
                                        break;
                                    case 1:
                                        if (File.Exists(CurrentPath + "PHOTO" + txt2[x, 0] + ".JPG"))
                                        {
                                            //Random rnd = new Random();
                                            ImageName = "images/articles/photo" + txt2[x, 0] + ".jpg" + "?" + Convert.ToString(rnd.Next(1000000));
                                        }
                                        else
                                        {
                                            ImageName = "images/articles/photo.jpg";
                                        }
                                        sb.Append("\t" + ImageName);
                                        break;
                                    case 3:
                                        sb.Append("\t" + Seleccion);
                                        break;
                                    case 4:
                                        sb.Append("\t" + txt2[x, y - 1]);
                                        break;
                                    default:
                                        sb.Append("\t" + txt2[x, y - 1]);
                                        break;
                                }
                            }
                        }
                    }

                    htm.Caption = "Articles";
                    // htm.NewPageIcon = True
                    htm.HiddenData = "Test hidden data";
                    // htm.Header = Now.ToLongDateString
                    htm.BackgroundColor = "white";
                    htm.TextColor = "black";
                    htm.Text = sb.ToString();
                    htm.AddCol("ID", NSHTML.Types.Text);
                    htm.AddImageCol("Image", 50, 50, "", 1, "LARGEPHOTO");
                    htm.AddCol("Description", NSHTML.Types.Text);
                    htm.AddCol(NSHTML.SpecialColumns.MultipleSelection, "Units", 1);
                    htm.AddCol("Price", NSHTML.Types.Number);
                    htm.Funct = "SAVEORDER";
                    htm.Show(Page);
                    break;
                case "SAVEORDER":
                    double Value2 = 0;
                    double Total1 = 0;
                    double Total2 = 0;
                    txt2 = util.Tab2Array(File.ReadAllText(Server.MapPath(".") + @"\data\artic.txt"));
                    for (int x = 0; x <= txt2.GetUpperBound(0); x++)
                    {
                        //System.Globalization.NumberFormatInfo nfi_g0 = new  System.Globalization.NumberFormatInfo();
                        nfi_g0.CurrencyGroupSeparator = ".";
                        Value2 = Convert.ToDouble(core.HTML.GetMultipleSelection(txt2[x, 0]).Value, nfi_g0);
                        if (Value2 != 0)
                        {
                            Total1 = Value2 * util.Val(txt2[x, 3]);
                            Total2 += Total1;
                            sb.Append(txt2[x, 0] + "\t" + txt2[x, 1] + "\t" + Convert.ToString(Value2) + "\t" + txt2[x, 3] + "\t" + Total1 + Environment.NewLine);
                        }
                    }
                    sb.Append("*" + "\t" + "TOTAL" + "\t" + "\t" + "\t" + Convert.ToString(Total2) + Environment.NewLine);
                    //var ContaNet.Tools.NSHTML htm = new ContaNet.Tools.NSHTML();
                    htm.Caption = "Your order";
                    htm.AddCol("ID", NSHTML.Types.Text);
                    htm.AddCol("Description", NSHTML.Types.Text);
                    htm.AddCol("Units", NSHTML.Types.Number);
                    htm.AddCol("Price", NSHTML.Types.Number);
                    htm.AddCol("Total", NSHTML.Types.Number);
                    htm.Text = sb.ToString();
                    htm.TextColor = "black";
                    htm.BackgroundColor = "white";
                    htm.Show(Page);
                    break;
                case "LARGEPHOTO":
                    string IMG = core.Values[0];
                    if (!File.Exists(Server.MapPath(".") + @"\images\articles\photo" + IMG + ".JPG")) IMG = "";
                    show.Image(GetArticle(core.Values[0]), "images/articles/photo" + IMG + ".JPG", -1, -1, 500);
                    break;
                case "B3":
                    txt2 = util.Tab2Array(File.ReadAllText(Server.MapPath(".") + @"\data\artic.txt"));
                    ImageName = "";
                    CurrentPath = Server.MapPath(".") + @"\images\articles\";
                    for (int x = 0; x <= txt2.GetUpperBound(0); x++)
                    {
                        if (sb.Length > 0) sb.Append(Environment.NewLine);
                        for (int y = 0; y <= txt2.GetUpperBound(1); y++)
                        {
                            nfi_g0.CurrencyGroupSeparator = ".";
                            //if (Convert.ToDouble(txt2[x, 0], nfi_g0) > 0)
                            if (txt2[x, 0] != "")
                            {
                                switch (y)
                                {
                                    case 0:
                                        if (File.Exists(CurrentPath + "PHOTO" + txt2[x, y] + ".JPG"))
                                        {
                                            ImageName = "images/articles/photo" + txt2[x, y] + ".jpg" + "?" + Convert.ToString(rnd.Next(1000000));
                                        }
                                        else
                                        {
                                            ImageName = "images/articles/photo.jpg";
                                        }
                                        sb.Append(txt2[x, y] + "\t" + ImageName);
                                        break;
                                    default:
                                        sb.Append("\t" + txt2[x, y]);
                                        break;
                                }
                            }
                        }
                    }

                    htm.Caption = "Articles";
                    htm.NewPageIcon = true;
                    htm.HiddenData = "Test hidden data";
                    // htm.Header = Now.ToLongDateString
                    htm.BackgroundColor = "white";
                    htm.TextColor = "black";
                    htm.Text = sb.ToString();
                    htm.AddHyperlinkCol("ID", 1, "B3A", "B3");
                    htm.AddImageCol("Image", 50, 50, "", 1, "ChangeImage", "B3");
                    htm.AddCol("Description", NSHTML.Types.Text);
                    htm.AddCol("Units", NSHTML.Types.Number);
                    htm.AddCol("Price", NSHTML.Types.Number);
                    htm.Show(Page);
                    break;
                case "ChangeImage":
                    m.HiddenData = core.Values[0];
                    m.Caption = "New Photo";
                    m.Funct = "SavePhoto2";
                    m.AddItem("Photo", NSEnums.NSVars.FileUpload, 0);
                    m.Show(Page);
                    break;
                case "SavePhoto2":
                    photo = core.Values[0];
                    File.Copy(Server.MapPath(".") + @"\uploads\" + core.Values[0], Server.MapPath(".") + @"\IMAGES\articles\PHOTO" + core.HiddenData + ".JPG", true);
                    show.CloseCallingWindow();
                    break;
                case "WPW":
                    show.WebPage("Contanet", "http://www.contanet.es", 10, 10, 600, 500);
                    break;
                case "B3A":
                    AR = util.Tab2Array(File.ReadAllText(Server.MapPath(".") + @"\data\artic.txt"));
                    Titles = "ID,Description,Units,Price".Split(',');
                    Types = "0,0,3,3".Split(',');
                    Widths = "5,35,13,13".Split(',');
                    tope = AR.GetUpperBound(1);
                    for (int x = 0; x <= tope; x++)
                    {
                        if (AR[x, 0] == core.Values[0])
                        {
                            m.Funct = "B3B";
                            m.Caption = core.Values[0];
                            m.HiddenData = core.Values[0];
                            photo = "";
                            if (File.Exists(Server.MapPath(".") + @"\IMAGES\articles\PHOTO" + core.Values[0] + ".JPG"))
                            {
                                photo = "PHOTO" + core.Values[0] + ".JPG";
                                int aaa = rnd.Next(1000000);
                                photo += "?" + Convert.ToString(aaa);
                            }
                            else
                            {
                                photo = "Photo.jpg";
                            }
                            photo = "images/articles/" + photo;
                            m.AddImage(photo, 150, 150, NSEnums.Align2.MiddleLeft, "ARTIMAGECLICK");
                            for (int y = 1; y <= Titles.GetUpperBound(0); y++)
                            {
                                switch (Types[y])
                                {
                                    case "0":
                                        tipovar = NSEnums.NSVars.Text;
                                        break;
                                    case "202":
                                        tipovar = NSEnums.NSVars.MaskedEdit;
                                        break;
                                    case "3":
                                        tipovar = NSEnums.NSVars.Number_2dec; //NSDouble;
                                        break;
                                    case "30":
                                        tipovar = NSEnums.NSVars.Checkbox;
                                        break;
                                }
                                m.AddItem(Titles[y], tipovar, Convert.ToInt32(Widths[y]), AR[x, y]);
                            }
                            m.Show(Page);
                            break;
                        }
                    }
                    break;
                case "B3B":
                    if (core.Menu.GetValue(1).Trim() == "")
                    {
                        show.Message("A description must be assigned to the article");
                    }
                    string NewArtic = "";
                    found = false;
                    AR = util.Tab2Array(File.ReadAllText(Server.MapPath(".") + @"\data\artic.txt"));
                    ID = core.Menu.Caption.Trim();
                    for (int x = 0; x <= AR.GetUpperBound(1); x++)
                    {
                        if (AR[x, 0] == ID)
                        {
                            for (int y = 1; y <= AR.GetUpperBound(2); y++)
                            {
                                if (AR[x, y].Trim() != core.Menu.GetValue(y).Trim())
                                {
                                    found = true;
                                    AR[x, y] = core.Menu.GetValue(y - 1).Trim();
                                }
                            }
                        }
                    }
                    if (!found)
                    {
                        NewArtic += Environment.NewLine;
                        NewArtic += core.Menu.Caption.Trim();
                        for (int y = 1; y <= core.Menu.Count(); y++)
                        {
                            NewArtic += "\t" + core.Menu.GetValue(y).Trim();
                        }
                    }
                    File.WriteAllText(Server.MapPath(".") + @"\data\artic.txt", util.Array2Tab(AR) + NewArtic, System.Text.Encoding.ASCII);
                    CleanUpFile("artic.txt");
                    show.CloseCallingWindow();
                    break;
                case "B4":
                    //var NSGrid grd1 = new NSGrid();
                    //  .Top = 0
                    //  .Left = 0
                    //  .Height = 1000
                    grd1.Caption = "ARTICLES";
                    grd1.AddCol("ID", NSEnums.NSVars.NonModifiableText, 10);
                    grd1.AddCol("Description", NSEnums.NSVars.Text, 35, "");
                    grd1.AddCol("Units", NSEnums.NSVars.Number_2dec, 12);
                    grd1.AddCol("Price", NSEnums.NSVars.Number_2dec, 12);
                    grd1.Funct = "B41";
                    grd1.Clip = File.ReadAllText(Server.MapPath(".") + @"\data\artic.txt");
                    grd1.Show(Page);
                    break;
                case "B41":
                    File.WriteAllText(Server.MapPath(".") + @"\data\artic.txt", core.Grid.Clip(), System.Text.Encoding.ASCII);
                    break;
                case "B5":
                    AR = util.Tab2Array(File.ReadAllText(Server.MapPath(".") + @"\data\artic.txt"));
                    int NewID = 0;
                    for (int x = 0; x <= AR.GetUpperBound(1); x++)
                    {
                        try
                        {
                            if (Convert.ToInt32(AR[x, 0]) > NewID) NewID = Convert.ToInt32(AR[x, 0]);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    NewID += 1;
                    m.Caption = "Create a new article";
                    //  .AddImage(Photo, 150, 150, Align2.MiddleLeft, "IMAGECLICK")
                    m.AddItem("ID", NSEnums.NSVars.NonModifiableText, 5, Convert.ToString(NewID));
                    m.AddItem("Description", NSEnums.NSVars.Text, 35, "");
                    m.AddItem("Units", NSEnums.NSVars.Number, 12, "");
                    m.AddItem("Price", NSEnums.NSVars.Number_2dec, 12, "");
                    m.Funct = "B5A";
                    m.Show(Page);
                    break;
                case "B5A":
                    NewArtic = Environment.NewLine;
                    for (int y = 1; y <= core.Menu.Count(); y++)
                    {
                        NewArtic += core.Menu.GetValue(y - 1).Trim() + "\t";
                    }
                    //File.WriteAllText(Server.MapPath(".") + @"\data\artic.txt", NewArtic, System.Text.Encoding.ASCII);
                    File.AppendAllText(Server.MapPath(".") + @"\data\artic.txt", NewArtic, System.Text.Encoding.ASCII);
                    show.CloseCallingWindow();
                    break;
                case "B6":
                    htm.Caption = "Delete Articles";
                    htm.NewPageIcon = true;
                    htm.Header = DateTime.Now.ToLongDateString();
                    htm.Text = File.ReadAllText(Server.MapPath(".") + @"\data\artic.txt");
                    htm.AddHyperlinkCol("ID", 1, "B6A", "B6");
                    htm.AddCol("Description", NSHTML.Types.Text);
                    htm.AddCol("Units", NSHTML.Types.Number);
                    htm.AddCol("Price", NSHTML.Types.Number);
                    htm.BackgroundColor = "WHITE";
                    htm.TextColor = "BLACK";
                    htm.Show(Page);
                    break;
                case "B6A":
                    var id = core.Values[0];
                    util = new ContaNet.Tools.NSUtil(Page);
                    AR = util.Tab2Array(File.ReadAllText(Server.MapPath(".") + @"\data\artic.txt"));
                    string[,] Ar2 = new string[AR.GetUpperBound(0) + 1, AR.GetUpperBound(1) + 1];
                    //Dim Ar2(UBound(AR, 1), UBound(AR, 2)) As String
                    Counter = -1;
                    for (int x = 0; x <= AR.GetUpperBound(0); x++)
                    {
                        if (AR[x, 0] != id)
                        {
                            Counter += 1;
                            for (int y = 0; y <= AR.GetUpperBound(1); y++)
                            {
                                Ar2[Counter, y] = AR[x, y];

                            }
                        }
                    }
                    File.WriteAllText(Server.MapPath(".") + @"\data\artic.txt", util.Array2Tab(Ar2), System.Text.Encoding.ASCII);
                    CleanUpFile("ARTIC.TXT");
                    show.CloseCallingWindow();
                    break;
                case "1005":
                case "1006":
                    string Des = "Country";
                    m.Funct = "1005A";
                    if (core.Funct == "1005")
                    {
                        m.Caption = "Choose one";
                    }
                    else
                    {
                        m.Caption = "Elegir uno";
                        Des = "Pais";
                    }
                    m.AddItem(Des, NSEnums.NSVars.Country, 30, "");
                    m.AddItem(Des + " (ISO3166-2)", NSEnums.NSVars.Countries_ISO3166_2, 30, "");
                    m.AddItem(Des + " (ISO3166-3)", NSEnums.NSVars.Countries_ISO3166_3, 30, "");
                    m.AddItem(Des + " (ISO3166-N)", NSEnums.NSVars.Countries_ISO3166_N, 30, "");
                    if (core.Funct == "1005")
                    {
                        m.AddItem("ISO4127", NSEnums.NSVars.CurrencyCodes_ISO4127, 30);
                    }
                    else
                    {
                        m.AddItem("ISO6391", NSEnums.NSVars.Countries_ISO6391_Spanish, 30); 
                    }
                    m.Show(Page);
                    break;
                case "1005A":
                    //string HTM = "";
                    sb.Clear();
                    for (int X = 0; X <= core.Menu.Count(); X++)
                    {
                         sb.Append (core.Menu.GetDescription(X) + "\t" + core.Menu.GetValue(X) + Environment.NewLine);
                    }
                    var MC = new ContaNet.Tools.NSMenu();
                    MC.Caption = "You Chose";
                    MC.AddItem("Countries:", NSEnums.NSVars.Notes, 50, sb.ToString());
                    MC.Show(Page);
                    break;
                    //var HTML = new ContaNet.Tools.NSHTML();
                    //HTML.Caption = "You chose";
                    //HTML.Text = sb.ToString();// HTM;
                    //HTML.Show(Page);
                    break;
                case "ChangeStyle":
                    m.Funct = "ChangeStyle1";
                    m.Caption = "Styles";
                    string Styles = GetFiles(Server.MapPath(".") + @"\data\styles");
                    string[] S1 = Styles.Split(Convert.ToChar(","));
                    for (int x = 0; x < S1.GetUpperBound(0); x++)
                    {
                        m.AddItem(S1[x].Substring(0, S1[x].Length - 4), NSEnums.NSVars.SelectOption, 0);
                    }
                    m.Show(Page);
                    break;
                case "ChangeStyle1":
                    FileName = core.Menu.GetDescription(core.Menu.GetOption() - 1) + ".txt";
                    var stylePath = Page.Server.MapPath(".") + "\\data\\style.txt";
                    System.IO.File.Copy(Page.Server.MapPath(".") + "\\data\\styles\\" + FileName, stylePath, true);
                    util.set_Cookie("STYLE", DateTime.Now.AddDays(1), FileName);
                    show.Reload();
                    break;
                case "ShowHelp":
                    //var ContaNet.Tools.NSTreeView tv = new ContaNet.Tools.NSTreeView();
                    tv.Funct = "ShowHelp1";
                    tv.ShowFiles.Path = Server.MapPath(".") + @"\help";
                    tv.ShowFiles.SearchPattern = "*.pdf";
                    tv.ShowFiles.ShowEmptyFolders = false;
                    tv.ShowFiles.ReturnFullPath = true;
                    tv.Caption = "Help";
                    tv.BackgroundColor = "pink";
                    tv.Show(Page);
                    break;
                case "ShowHelp1":
                    show.PDF("Help", core.Values[0], true, false, 100, 100, 600, 700, true);
                    break;
                case "AboutDemos":
                    show.Message("Note that this is not intended to be a demostration of how to use a database. We have used text files for our database to keep it as simple as possible for demostration purposes.");
                    break;
                case "VBDEMO":
                case "CSDEMO":
                case "DLL":
                    m.Funct = core.Funct + "1";
                    m.Caption = "End users licence";
                    m.AddLabel("Please read the following end users licence", NSEnums.LabelColor.Red, NSEnums.Align.Center);
                    m.AddItem("English", NSEnums.NSVars.SelectOption, 0, "1", "", "EULAEN");
                    m.AddItem("Español", NSEnums.NSVars.SelectOption, 0, "", "", "EULAES");
                    m.AddItem("", NSEnums.NSVars.NonModifiableNotes, 60, File.ReadAllText(Server.MapPath(".") + @"\data\eula.txt", System.Text.Encoding.UTF7));
                    m.AddLabel("Mark the checkbox if you approve and accept the conditions", NSEnums.LabelColor.Red, NSEnums.Align.Center);
                    m.AddItem("I accept the conditions", NSEnums.NSVars.Checkbox, 0, "");
                    m.Show(Page);
                    break;
                case "EULAEN":
                    rm.SetCaption("End users licence");
                    rm.SetTextValue(0, "Please read the following end users licence");
                    rm.SetTextValue(3, File.ReadAllText(Server.MapPath(".") + @"\data\eula.txt", System.Text.Encoding.UTF7).Replace("\t", " "));
                    rm.SetTextValue(4, "Mark the checkbox if you approve and accept the conditions");
                    rm.SetTextValue(5, "I accept the conditions");
                    rm.ReturnValues(Page);
                    break;
                case "EULAES":
                    rm.SetCaption("Licencia de usuario");
                    rm.SetTextValue(0, "Por favor lea detenidamente la licencia de usuario");
                    rm.SetTextValue(3, File.ReadAllText(Server.MapPath(".") + @"\data\cluf.txt", System.Text.Encoding.UTF7));
                    rm.SetTextValue(4, "Marque la casilla si acepta las condiciones");
                    rm.SetTextValue(5, "Acepto las condiciones");
                    rm.ReturnValues(Page);
                    break;
                case "VBDEMO1":
                    if (core.Menu.GetValue(5) == "1") show.DownloadFile(Server.MapPath(".") + @"\DOWNLOADS\VBDEMO.ZIP");
                    show.Message("You must accept the terms and conditions to download the demo");
                    break;
                case "CSDEMO1":
                    if (core.Menu.GetValue(5) == "1") show.DownloadFile(Server.MapPath(".") + @"\DOWNLOADS\CSDEMO.ZIP");
                    show.Message("You must accept the terms and conditions to download the demo");
                    break;
                case "DLL1":
                    if (core.Menu.GetValue(5) == "1") show.DownloadFile(Server.MapPath(".") + @"\DOWNLOADS\CONTANET.TOOLS.ZIP");
                    show.Message("You must accept the terms and conditions to download the DLL");
                    break;
                case "1999":
                    util.set_Cookie("LOGIN", default(DateTime), "");
                    show.RedirectPage("WebForm1.aspx");
                    // show.Reload()
                    break;
                case "RELOAD":
                    show.RedirectPage("WebForm1.aspx", "RELOAD2");
                    break;
                case "REALOAD2":
                    break;
                case "PROGRESS":
                    m.AddProgressBar("ENDPROGRESS");
                    m.Funct = "PROGRESS2";
                    m.Caption = "Progress bar demo";
                    m.AddLabel("Progress bar for long operations", NSEnums.LabelColor.Grey, NSEnums.Align.Center);
                    m.Show(Page);
                    break;
                case "PROGRESS2":
                    var pc = new ProgressCtrl();
                    pc.Progress(Page, core);
                    show.DoNothing();
                    break;
                case "ENDPROGRESS":
                    show.Message("Progress finished");
                    break;
                case "ADDITION":
                    m.Caption = "ADDITION";
                    m.Funct = "ADDTOTAL";
                    for (int x = 0; x <= 5; x++)
                    {
                        m.AddItem("Amount " + x, NSEnums.NSVars.Number_2dec, 12, "", "", "ADDIT" + Convert.ToString(x));
                    }
                    m.AddItem("TOTAL", NSEnums.NSVars.NonModifiableNumber, 12);
                    m.Show(Page);
                    break;
                case "ADDIT0":
                case "ADDIT1":
                case "ADDIT2":
                case "ADDIT3":
                case "ADDIT4":
                case "ADDIT5":
                    Total = 0;
                    for (int X = 0; X <= 5; X++)
                    {
                        Total += util.Val(core.Menu.GetValue(X));
                    }

                    mr.SetTextValue(6, Convert.ToString(Total), "Total");
                    mr.SetFocus(Convert.ToInt32(core.Funct.Substring(5, 1)) + 1);
                    mr.ReturnValues(Page);
                    break;
                case "ADDTOTAL":
                    show.Message("Total is: " + core.Menu.GetValue(6));
                    break;
                case "MATH":
                    m.Caption = "MATH";
                    m.Funct = "MATH2";
                    m.AddItem("Start with", NSEnums.NSVars.Number_2dec, 12, "", "", "MATH3");
                    m.AddItem("Add this to it", NSEnums.NSVars.Number_2dec, 12, "", "", "MATH3");
                    m.AddItem("Subtract this", NSEnums.NSVars.Number_2dec, 12, "", "", "MATH3");
                    m.AddItem("Multiply by", NSEnums.NSVars.Number_2dec, 12, "", "", "MATH3");
                    m.AddItem("Divide by", NSEnums.NSVars.Number_2dec, 12, "", "", "MATH3");
                    m.AddItem("TOTAL", NSEnums.NSVars.NonModifiableNumber, 12);
                    m.Show(Page);
                    break;
                case "MATH2":
                    show.Message("Amount is " + core.Menu.GetValue(5));
                    break;
                case "MATH3":
                    double Amount;
                    Amount = util.Val(core.Menu.GetValue(0));
                    var MENU = new NSShow.MenuValues();
                    Amount += util.Val(core.Menu.GetValue(1));
                    MENU.SetTextValue(1, core.Menu.GetValue(1), Convert.ToString(Amount));
                    Amount -= util.Val(core.Menu.GetValue(2));
                    MENU.SetTextValue(2, core.Menu.GetValue(2), Convert.ToString(Amount));
                    Amount = Amount * util.Val(core.Menu.GetValue(3));
                    MENU.SetTextValue(3, core.Menu.GetValue(3), Convert.ToString(Amount));
                    double imp = util.Val(core.Menu.GetValue(4));
                    if (imp != 0) { Amount = Amount / imp; } else { Amount = 0; }
                    MENU.SetTextValue(4, core.Menu.GetValue(4), Convert.ToString(Amount));
                    MENU.SetTextValue(5, Convert.ToString(Amount), "--- Total");
                    MENU.ReturnValues(Page);
                    //return;
                    break;
                case "DYSELECT":
                    m.Caption = "Dinamic select";
                    m.Funct = "DYSELECTOK";
                    m.AddItem("Article code (Try 0, 1, or TOM)", NSEnums.NSVars.Text, 10, "", "", "DYSELECT2");
                    m.AddItem("Description", NSEnums.NSVars.Text, 30);
                    m.AddItem("Price", NSEnums.NSVars.Number_2dec, 12);
                    m.Show(Page);
                    break;
                case "DYSELECTOK":
                    show.Message("OK");
                    break;
                case "DYSELECT2":
                    int y2 = 0;
                    AR = util.Tab2Array(File.ReadAllText(Server.MapPath(".") + @"\data\artic.txt"));
                    //string[] Artic = new string[1];
                    des = core.Menu.GetValue(0).Trim();
                    if (des == "" | des == "0")
                    {
                        Artic = new string[AR.GetUpperBound(1)];
                        for (int x = 0; x <= AR.GetUpperBound(1)-1; x++)
                        {
                            Artic[x] = AR[x, 0] + " " + AR[x, 1];
                        }
                        show.List("Choose one", Artic, "DYSELECT3");
                        return;
                    }
                    else
                    {
                        bool Found2 = false;
                        for (int X = 0; X <= AR.GetUpperBound(0); X++)
                        {
                            if (des == AR[X, 0])
                            {
                                MENU = new NSShow.MenuValues();
                                MENU.SetTextValue(1, AR[X, 1]);
                                MENU.SetTextValue(2, AR[X, 3]);
                                MENU.SetFocus(4);
                                MENU.ReturnValues(Page);
                                Found2 = true;
                                return;
                            }
                        }
                        if (!Found2)
                        {
                            des = des.ToUpper();
                            for (int X = 0; X <= AR.GetUpperBound(0); X++)
                            {
                                if (AR[X, 1].ToUpper().IndexOf(des) > 0)
                                {
                                    Array.Resize(ref Artic, y2);
                                    Artic[y2] = AR[X, 0] + " " + AR[X, 1];
                                    y2 = y2 + 1;
                                    Found2 = true;
                                }
                            }
                            if (Found2)
                            {
                                show.List("Choose one", Artic, "DYSELECT3");
                            }
                            else
                            {
                                m.Caption = "Create a new article";
                                m.AddItem("ID", NSEnums.NSVars.NonModifiableText, 5, des);
                                m.AddItem("Description", NSEnums.NSVars.Text, 35, "");
                                m.AddItem("Units", NSEnums.NSVars.Number, 12, "");
                                m.AddItem("Price", NSEnums.NSVars.Number_2dec, 12, "");
                                m.Funct = "CR4";
                                m.Show(Page);
                            }
                        }
                    }
                    break;
                case "DYSELECT3":
                    Des = core.Values[0];
                    Des = Des.Substring(0, Des.IndexOf(" "));
                    AR = util.Tab2Array(File.ReadAllText(Server.MapPath(".") + @"\data\artic.txt"));
                    for (int X = 0; X <= AR.GetUpperBound(0); X++)
                    {
                        if (Des == AR[X, 0])
                        {
                            M.SetTextValue(0, AR[X, 0]);
                            M.SetTextValue(1, AR[X, 1]);
                            M.SetTextValue(2, AR[X, 3]);
                            M.SetFocus(4);
                            M.ReturnValues(Page);
                            return;
                        }
                    }
                    break;
                case "CR4":
                    NewArtic = Environment.NewLine;
                    for (int y = 1; y <= core.Menu.Count(); y++)
                    {
                        NewArtic += core.Menu.GetValue(y - 1).Trim() + "\t";
                    }
                    File.WriteAllText(Server.MapPath(".") + @"\data\artic.txt", NewArtic, System.Text.Encoding.ASCII);
                    CleanUpFile("artic.txt");
                    M.SetTextValue(1, core.Menu.GetValue(1));
                    M.SetTextValue(2, core.Menu.GetValue(3));
                    M.SetFocus(4);
                    M.ReturnValues(Page);
                    break;
                case "OPTION":
                    m.Funct = "OPTIONMULTI";
                    m.Caption = "Option/Multiselect";
                    m.AddItem("Clients", NSEnums.NSVars.SelectOption, 0, "", "", "OPTION1");
                    m.AddItem("Articles", NSEnums.NSVars.SelectOption, 0, "", "", "OPTION2");
                    m.AddItem("MultiSelect", NSEnums.NSVars.MultipleSelection, 0);
                    m.Show(Page);
                    break;
                case "OPTIONMULTI":
                    show.Message(core.Menu.GetValue(2));
                    break;
                case "OPTION2":
                    AR = util.Tab2Array(File.ReadAllText(Server.MapPath(".") + @"\data\artic.txt"));
                    for (int x = 0; x <= AR.GetUpperBound(0); x++)
                    {
                        sb.Append(AR[x, 0] + " " + AR[x, 1] + ",");
                    }
                    M.SetTextValue(2, sb.ToString(), "Articles");
                    M.ReturnValues(Page);
                    break;
                case "OPTION1":
                    AR = util.Tab2Array(File.ReadAllText(Server.MapPath(".") + @"\data\mytest.txt"));
                    for (int x = 0; x <= AR.GetUpperBound(0); x++)
                    {
                        sb.Append(AR[x, 0] + " " + AR[x, 1] + ",");
                    }
                    M.SetTextValue(2, sb.ToString(), "Clients");
                    M.ReturnValues(Page);
                    break;
                case "OPTM2A":
                case "OPTM2B":
                    var Tipo = NSEnums.NSVars.MultipleSelection;
                    string Caption = "SELECT";
                    if (core.Funct == "OPTM2A") Tipo = NSEnums.NSVars.Combo; Caption = "DataList";
                    m.Funct = "OPTIONMULTI";
                    m.Caption = Caption;
                    m.AddLabel("Try United States or Spain", NSEnums.LabelColor.Green, NSEnums.Align.Center);
                    m.AddItem("Country", NSEnums.NSVars.Country, 0, "", "", "COUNTRY1");
                    m.AddItem("STATE/PROVINCE", Tipo, 0,"one,two,three,four");
                    m.Show(Page);
                    break;
                case "COUNTRY1":
                    switch (core.Menu.GetValue(1).ToUpper())
                    {
                        case "UNITED STATES":
                        case "ESTADOS UNIDOS":
                            string[] states = util.States();
                            M.SetTextValue(2, String.Join(",", states), "States");
                            M.ReturnValues(Page);
                            break;
                        case "SPAIN":
                        case "ESPAÑA":
                            string[] prov = util.ProvinciasDeEspaña();
                            M.SetTextValue(2, String.Join(",", prov), "Spanish Provinces");
                            M.ReturnValues(Page);
                            break;
                        default:
                            M.SetTextValue(2, "", " ");
                            M.ReturnValues(Page);
                            break;
                    }
                    break;
                default:
                    show.Message("Option chosen was:  " + core.Funct);
                    show.Message("OK");
                    break;
                case "TREEVIEWTEST1":
                    ShowTreeview("one");
                    break;
                case "TREEVIEWTEST2":
                    ShowTreeview("TWO");
                    break;
                case "TESTCOOKIE":
                    var U = new NSUtil(Page);
                    U.set_Cookie("TEST1", default(DateTime), "Progamación ");
                    break;
                case "TESTCOOKIE2":
                    var U1 = new NSUtil(Page);
                    show.Message(U1.get_Cookie("TEST1"));
                    break;
            }
        }

        protected void CleanUpFile(string FileName)
        {
            string FiName = Server.MapPath(".") + @"\data\" + FileName;
            var util = new ContaNet.Tools.NSUtil(Page);
            String data = File.ReadAllText(FiName).Replace(Convert.ToString(Convert.ToChar(10)) + Convert.ToString(Convert.ToChar(10)), Convert.ToString(Convert.ToChar(10)));
            //String AR[,];
            AR = util.Tab2Array(data);
            string[] AR2 = data.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            var sb = new System.Text.StringBuilder();
            int Max = 0;
            for (int x = 0; x <= AR.GetUpperBound(0) - 1; x++)
            {
                if (AR[x, 0] != "") {
                    if (Max < Convert.ToInt32(AR[x, 0])) Max = Convert.ToInt32(AR[x, 0]);
                }
            }
            for (int x = 1; x <= Max; x++)
            {
                for (int y = 0; y <= AR.GetUpperBound(0) - 1; y++)
                {
                    if (AR[y, 0] != "")
                    {
                        if (Convert.ToInt32(AR[y, 0]) == x)
                        {
                            sb.Append(AR2[y].Replace(Convert.ToString(Convert.ToChar(10)), "") + Environment.NewLine);
                            break;
                        }
                    }
                }
            }
            //File.Delete(FiName);
            File.WriteAllText(FiName, sb.ToString(), System.Text.Encoding.ASCII);
        }

        public void ShowFile(string FileName)
        {

            var show = new ContaNet.Tools.NSShow(Page);

            string fName = FileName.Substring(FileName.LastIndexOf(@"\") + 1, FileName.LastIndexOf(".") - FileName.LastIndexOf(@"\"));

            if (FileName.ToUpper().EndsWith(".JPG"))
            {
                show.Image(fName + " " + File.GetCreationTime(FileName).ToString(), FileName, 10, 10, 300);
            }
            else if (FileName.ToUpper().EndsWith(".PDF"))
            {
                show.PDF(fName + " " + File.GetCreationTime(FileName).ToString(), FileName, true, false, 100, 100, 500, 800);
            }
            else if (FileName.ToUpper().EndsWith(".MP3"))
            {
                show.Audio(fName + " " + File.GetCreationTime(FileName).ToString(), FileName);
            }
            else if (FileName.ToUpper().EndsWith(".MP4"))
            {
                show.Video(fName + " " + File.GetCreationTime(FileName).ToString(), FileName);
            }
            else
            {
                show.DownloadFile(FileName);
            }

        }

        public double GetTotal(ContaNet.Tools.NSCore.NSGrid Grid)
        {
            double Total = 0;
            for (int x = 0; x <= Grid.Rows(); x++)
            {
                if (Grid.CellValue(x, 5) == null)
                {
                }
                else
                {
                    if (Grid.CellValue(x, 5) != "") { Total += Convert.ToDouble(Grid.CellValue(x, 5)); }
                }
            }
            return Total;
        }

        public int GetNextClient()
        {
           
            var util = new ContaNet.Tools.NSUtil(Page);
            String[,] AR = util.Tab2Array(File.ReadAllText(Server.MapPath(".") + @"\data\mytest.txt"));
            int ClientNumber = 0;
            for(int x = 0 ; x <= AR.Length ; x++)
            {

               

                if (ClientNumber < Int32.Parse(AR[x,0])) {
                    ClientNumber = Int32.Parse(AR[x, 0]);
                        }

            }


            ClientNumber += 1;
            return ClientNumber;

        }

        protected void test(String s)
        {
            var hello = s;
        }
        protected NSStyles mystyle()
        {

            var nstyle = new ContaNet.Tools.NSStyles();
            var util = new NSUtil(Page);
            var stylePath = Page.Server.MapPath(".") + "\\data\\CONTANETTOOLS.txt";
            if (System.IO.File.Exists(stylePath))
            {
                var txt = System.IO.File.ReadAllText(stylePath);
                //////String[] config = txt.Split(',');
                string[] config = GetStyle();

                int FontSize = 20;
                FontSize = Convert.ToInt32(config[11]);
                if (FontSize > 40) FontSize = 20;

                nstyle.BackGroundImage = "images/background/" + config[0];
                nstyle.CenterBackGroundImage = Convert.ToBoolean(Convert.ToInt32(config[1]));
                nstyle.MenuBackGroundImage = "images/background/" + config[2];
                nstyle.DefaultMenuColor = config[3];
                nstyle.DefaultMenuGradientColor = config[16];
                nstyle.DefaultMenuBorderWidth = Convert.ToInt32(config[4]);
                nstyle.DefaultMenuBorderStyle = ContaNet.Tools.NSStyles.NSBorderStyle.groove;  // Convert.ChangeType (config[5], ContaNet.Tools.NSStyles.NSBorderStyle);
                nstyle.DefaultMenuFontColor = config[6];
                nstyle.NoScrollBars = Convert.ToBoolean(Convert.ToInt32(config[7]));
                nstyle.DefaultMenuBackgroundColor = config[8];
                nstyle.MenuBorderRadius = Convert.ToInt32(config[9]);
                nstyle.DefaultMenuFontFamily = config[10];
                nstyle.DefaultMenuFontSize = FontSize;
                nstyle.MenuBorderColor = config[12];
                nstyle.BackGroundColor = config[13];
                nstyle.Shadow = Convert.ToBoolean(Convert.ToInt32(config[20]));
                nstyle.AddText("", "", "Arial", "35px", "bold", "steelblue", "5%", "5%", "", "", "", "", "", "TIMERTEST");
            }
            else
            {
                if (util.get_Cookie("LOGIN") != "TRUE")
                {
                    nstyle.BackGroundImage = "images/background/gris.jpg";
                    nstyle.MenuBackGroundImage = "images/background/marmol_verde.jpg";
                }
                else
                {
                    nstyle.BackGroundImage = "images/background/marmol_verde.jpg";
                    nstyle.MenuBackGroundImage = "images/background/gris.jpg";
                }
                nstyle.DefaultMenuColor = "Green";
                nstyle.DefaultMenuBorderWidth = 1;
                nstyle.DefaultMenuBorderStyle = NSStyles.NSBorderStyle.groove;
                nstyle.DefaultMenuFontColor = "Black";

                //nstyle.CreateDirectoryTree(Page, "Contanet Tools", "Directory Tree", "", "", "",null ,NSStyles.ShowDirectoryTree.Hidden , "sitemap.xml");
            }
            return nstyle;
        }


        protected NSDropDownMenu ShowMenu()
        {

            var m = new NSDropDownMenu();

            var util = new NSUtil(Page);

            if (util.get_Cookie("LOGIN") != "TRUE") return m;
            string[] config = GetStyle();
            string menuColor;
            string menuFont;
            int menuFontSize = 30;

            menuColor = config[3];
            menuFont = config[10];
            System.Globalization.NumberFormatInfo nfi_g0 = new System.Globalization.NumberFormatInfo();
            nfi_g0.CurrencyGroupSeparator = ".";
            if (Convert.ToDouble(config[11], nfi_g0) > 0)
            {
                menuFontSize = Convert.ToInt32(Convert.ToDouble(config[11], nfi_g0));
                if (menuFontSize > 40) menuFontSize = 20;
            }
            m.Top = 0;
            m.Left = 0;
            m.FontSize1 = Convert.ToInt32(menuFontSize);
            m.FontSize2 = Convert.ToInt32(menuFontSize * 0.80000000000000004);
            m.MenuColor = menuColor;
            m.MenuGradientColor = config[16];
            m.FontColor1 = config[17];
            m.FontColor2 = config[18];
            m.FontColor3 = config[19];
            m.FontFamily = menuFont;

            // Data Entry
            string Mobile1 = "";
            if (Mobile) Mobile1 = "MOBILE";
            if (Mobile) m.AddNode("MENU", Mobile1);

            m.AddNode("Data Entry", "TOP1", Mobile1);
            m.AddNode("Sample data entry", "", "TOP1", "10");
            m.AddNode("Same as before but in Spanish format", "", "TOP1", "10A");
            m.AddNode("This shows a grid", "", "TOP1", "11");
            m.AddNode("Choose a country", "COUNTRY", "TOP1");
            m.AddNode("English", "", "COUNTRY", "1005");
            m.AddNode("Spanish", "", "COUNTRY", "1006");

            m.AddNode("ServerSide Validation", "SERVERSIDE", "TOP1");
            m.AddNode("Addition", "", "SERVERSIDE", "ADDITION");
            m.AddNode("Do some math", "", "SERVERSIDE", "MATH");
            m.AddNode("Dynamic selection", "", "SERVERSIDE", "DYSELECT");
            m.AddNode("Option/Multiselect", "", "SERVERSIDE", "OPTION");
            m.AddNode("Countries/States", "STATES", "SERVERSIDE");
            m.AddNode("DataList", "", "STATES", "OPTM2A");
            m.AddNode("Select", "", "STATES", "OPTM2B");

            m.AddNode("Various", "VARIOUS", Mobile1);

            //'Videos
            m.AddNode("Videos", "VIDEOS", "VARIOUS");
            m.AddNode("Animated Movie", "", "VIDEOS", "200");

            if (Directory.Exists(Server.MapPath(".") + @"\info\video"))
            {
                //File.GetFiles(Server.MapPath(".") + @"\info\video");
                string[] Files = GetFiles(Server.MapPath(".") + @"\info\video", "*.mp4").Split(Convert.ToChar(","));
                for (int x = 0; x < Files.GetUpperBound(0); x++)
                {
                    m.AddNode(Files[x].Substring(0, Files[x].Length - 4), "", "VIDEOS", "203" + Convert.ToString(x));
                }
            }

            //'Audio
            m.AddNode("Audio", "AUDIO", "VARIOUS");
            m.AddNode("Other", "", "AUDIO", "211");
            //' Images
            m.AddNode("Images", "Images", "VARIOUS");
            m.AddNode("Boavista", "", "Images", "220");
            m.AddNode("Maui", "", "Images", "221");


            m.AddNode("Menu example", "MoreM", "VARIOUS");
            m.AddNode("SUB 1", "sub2", "MoreM");
            m.AddNode("Sub sub 2 (contanet)", "", "sub2", "", "", "http://www.contanet.es");
            m.AddNode("Sub sub 1", "SUB3", "sub2", "10");
            m.AddNode("Sub sub 3", "", "SUB3", "10");


            //Other
            m.AddNode("Images", "Images2", "VARIOUS");
            m.AddNode("Small Preview", "", "Images2", "302");
            m.AddNode("Large Preview", "", "Images2", "302X");
            m.AddNode("No Preview", "", "Images2", "302N");
            m.AddNode("Search", "", "VARIOUS", "303");
            m.AddNode("File Upload", "", "VARIOUS", "304");
            m.AddNode("Styles", "STYLES", "VARIOUS");
            m.AddNode("Change style", "", "STYLES", "STYLE1");
            m.AddNode("Save current style", "", "STYLES", "STYLE2");
            m.AddNode("Load a style", "", "STYLES", "STYLE3");

            m.AddNode("Open a web page (contanet.es)", "", "VARIOUS", "", "", "http://www.contanet.es");
            m.AddNode("Open a web page in a window", "", "VARIOUS", "WPW");
            m.AddNode("javascript function called Test", "", "VARIOUS", "", "Test('ok')");
            m.AddNode("Reload Web Page", "", "VARIOUS", "RELOAD");
            m.AddNode("Progress", "", "VARIOUS", "PROGRESS");
            m.AddNode("Treeview test", "TREEVIEWTEST", "VARIOUS");
            m.AddNode("Treeview with standar icon","" , "TREEVIEWTEST", "TREEVIEWTEST1");
            m.AddNode("Treeview with personalized icon","" , "TREEVIEWTEST", "TREEVIEWTEST2");
            m.AddNode("Set Cookie","" , "VARIOUS", "TESTCOOKIE");
            m.AddNode("Get Cookie","" , "VARIOUS", "TESTCOOKIE2");


            //' Sample billing program
            m.AddNode("Billing", "BILLING", Mobile1);
            m.AddNode("Clients", "CLIENTS", "BILLING");
            m.AddNode("Clients (HTML)", "", "CLIENTS", "HTMIMAGE");
            m.AddNode("Clients (GRID)", "", "CLIENTS", "12");
            m.AddNode("Add new client", "", "CLIENTS", "113F");
            m.AddNode("ARTICLES", "ARTIC", "BILLING");
            m.AddNode("Articles (HTML)", "", "ARTIC", "B3");
            m.AddNode("Articles (GRID)", "", "ARTIC", "B4");
            m.AddNode("Add new article", "", "ARTIC", "B5");
            m.AddNode("Delete articles", "", "ARTIC", "B6");

            m.AddNode("Sample Invoice", "", "BILLING", "113");
            m.AddNode("Select articles", "", "BILLING", "SELARTIC");


            //' HTML

            m.AddNode("HTML", "HTML", Mobile1);
            m.AddNode("Show HTML", "HTML2", "HTML");
            m.AddNode("Rows with class", "", "HTML2", "32B");
            m.AddNode("Columns with class", "", "HTML2", "32C");


            m.AddNode("Show HTML (full screen)", "", "HTML", "32A");
            m.AddNode("Show HTML (with link)", "", "HTML", "33");
            m.AddNode("Show HTML (With invisible column)", "", "HTML", "34");
            m.AddNode("Show HTML (With editable column)", "", "HTML", "35");
            m.AddNode("Show HTML (With checkbox)", "", "HTML", "36");
            m.AddNode("Show HTML (With toolbar)", "HTMTB", "HTML");
            m.AddNode("Show HTML (With image)", "", "HTML", "HTMIMAGE");
            m.AddNode("Left", "", "HTMTB", "370");
            m.AddNode("Top", "", "HTMTB", "371");
            m.AddNode("Right", "", "HTMTB", "372");
            m.AddNode("Bottom", "", "HTMTB", "373");

            // DEMO

            m.AddNode("Demo", "DEMO", Mobile1);
            m.AddNode("VB.Net demo", "", "DEMO", "VBDEMO");
            m.AddNode("C# demo", "", "DEMO", "CSDEMO");
            m.AddNode("Most recent version of DLL", "", "DEMO", "DLL");
            m.AddNode("About the demos", "", "DEMO", "AboutDemos");
            m.AddNode("Purchase", "PURCHASE", Mobile1);
            m.AddNode("Vist page with purchase information", "", "PURCHASE", "", "", "https://www.conta.net/nsfactura/factura.aspx");

            // LOGOFF

            m.AddNode("Log off", "LOGOFF", Mobile1);
            m.AddNode("Log off", "", "LOGOFF", "1999");
            return m;

        }

        public bool GetMobile()
        {
            string strUserAgent = Request.UserAgent.ToString().ToLower();
            if (strUserAgent.Contains("ipad")) return false;
            if (String.Compare(strUserAgent, "") != 0)
            {
                System.Web.HttpBrowserCapabilities myBrowserCaps = Request.Browser;
                if (((((System.Web.Configuration.HttpCapabilitiesBase)myBrowserCaps).IsMobileDevice) | strUserAgent.Contains("iphone") | strUserAgent.Contains("blackberry") | strUserAgent.Contains("mobile") | strUserAgent.Contains("windows ce") | strUserAgent.Contains("opera mini") | strUserAgent.Contains("palm")))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public String[] GetStyle()
        {
            String[] config;
            var util = new NSUtil(Page);
            String Style;
            Style = util.get_Cookie("STYLE", default(DateTime));
            if (Style == "")
            {
                Style = Server.MapPath(".") + @"\data\ContaNetTools.txt";
            }
            else if (Style.ToUpper() == "STYLE.TXT")
            {
                Style = Server.MapPath(".") + @"\data\STYLE.txt";
            }
            else
            {
                Style = Server.MapPath(".") + @"\data\styles\" + Style;
            }

            if (File.Exists(Style))
            {
                config = File.ReadAllText(Style).Split(Convert.ToChar(","));
            }
            else
            {
                util.set_Cookie("STYLE", default(DateTime), " ");
                Style = Server.MapPath(".") + @"\data\ContaNetTools.txt";
                config = File.ReadAllText(Style).Split(Convert.ToChar(","));
            }
            Array.Resize(ref config, 22);
            if (config[15] == "") config[15] = "10";
            if (config[16] == "") config[16] = "black";
            if (config[16] == null) config[16] = "black";
            if (config[17] == "") config[17] = "white";
            if (config[17] == null) config[17] = "white";
            if (config[18] == "") config[18] = "white";
            if (config[18] == null) config[18] = "white";
            if (config[19] == "") config[19] = "black";
            if (config[19] == null) config[19] = "black";
            if (config[20] == "") config[20] = "1";
            if (config[20] == null) config[20] = "1";
            return config;
        }

        public string GetArticle(string ID)
        {
            var util = new ContaNet.Tools.NSUtil(Page);
            String[,] txt2;
            txt2 = util.Tab2Array(File.ReadAllText(Server.MapPath(".") + @"\data\artic.txt"));
            for (int x = 0; x <= txt2.GetUpperBound(0); x++)
            {
                if (txt2[x, 0] == ID) return txt2[x, 1];
            }
            return "";
        }
        public String GetBackground()
        {//?
            var sb = new System.Text.StringBuilder();
            String[] Files = System.IO.Directory.GetFiles(Server.MapPath(".") + @"\images\background");
            foreach (String FileName in Files)
            {
                sb.Append("," + System.IO.Path.GetFileName(FileName));
            }
            return sb.ToString();
        }


        internal string GetFiles(string Folder, string Extension = "*.*")
        {
            var sb = new System.Text.StringBuilder();
            string[] pa = new string[1];
            pa[0] = Extension;
            string[] Files = System.IO.Directory.GetFiles(Folder, pa[0], SearchOption.TopDirectoryOnly);
            foreach (String FileName in Files)
            {
                sb.Append(System.IO.Path.GetFileName(FileName) + ",");
            }
            return sb.ToString();
        }
        public NSToolBar ToolBar()
        {
            var tb = new NSToolBar();
            var util = new NSUtil(Page);
            string ruta = "";
            string[] config = GetStyle();
            if (config[14] == "2") ruta = "images/bt2/";
            if (config[15] == "") config[15] = "10";
            tb.Top = "8%";
            tb.Left = "3%";
            tb.Caption = "";
            if (Request.UserAgent.ToString().ToLower().Contains("ipad"))
            {
                if (Convert.ToInt32(config[15]) > 8) { tb.Cols = 8; } else { tb.Cols = Convert.ToInt32(config[15]); }
            }
            else if (!Mobile)
            {
                tb.Cols = Convert.ToInt32(config[15]);
            }
            else
            {
                tb.Cols = 3;
            }
            tb.Id = "main";
            if (util.get_Cookie("LOGIN") != "TRUE")
            {
                tb.Top = "3%";
                tb.Left = "3%";
                tb.AddItem("LOGIN", "intro", "LOGIN");
            }
            else
            {
                // Return tb
                tb.AddItem("Change Style", ruta + "update", "ChangeStyle");
                tb.AddItem("Page design", ruta + "design", "STYLE1");
                tb.AddItem("Images", ruta + "camera", "302");

                tb.AddItem("ContaNet.Tools video", ruta + "VIDEO", "CNVideo");
                tb.AddItem("Consult excel files", ruta + "EXCEL", "571");
                tb.AddItem("New", ruta + "new", "HTMLFILE");
                tb.AddItem("Show a grid", ruta + "grid", "12");

                tb.AddItem("Invoice", ruta + "tools", "113");


                tb.AddItem("What?", ruta + "QUESTION", "ShowHelp");
                tb.AddItem("Search", ruta + "SEARCH", "303");
                tb.AddItem("Client list", ruta + "userdata", "HTMIMAGE");
                tb.AddItem("Purchase information", ruta + "CART", "", "", "", "https://www.conta.net/nsfactura/factura.aspx");
                tb.AddItem("Exit", ruta + "cancel", "1999");
            }
            return tb;

        }
        internal NSToolBar ToolBar2(int Cols)
        {
            string ruta = "";
            string[] config = GetStyle();
            if (config[14] == "2") ruta = "images/bt2/";

            var tb = new NSToolBar();
            tb.Cols = Cols;
            tb.Id = "addin";
            tb.HiddenData = "Hidden data from toolbar";
            tb.AddItem("Camera", ruta + "camera", "52");
            tb.AddItem("Cart", ruta + "cart", "54");
            tb.AddItem("Consult excel files", ruta + "excel", "571");
            tb.AddItem("Tools", ruta + "tools", "572");
            tb.AddItem("What?", ruta + "question", "58");
            tb.AddItem("New", ruta + "new", "53");
            tb.AddItem("Exit", ruta + "cancel", "999");
            return tb;
        }
        public string jscript(string Javascriptfile)
        {
            return "<script type='text/javascript' src= '" + Javascriptfile + "?ver=" + "111" + "'> </script>";
        }

        public void ShowTreeview(String value) {

            var TV = new ContaNet.Tools.NSTreeView();

            TV.Caption = "test";
            TV.AddButton("test", DefaultIcons.About,"", "TESTBUTTON", "TREEVIEWTEST2");
            TV.FontSize = 20;
            TV.UseIcons = true;
            TV.HiddenData = "this is hidden data";
            for(int X = 1; X < 5; X++){
                TV.AddNode("Top" + X, "TOP" + X);
                for(int Y = 1;Y < 5; Y++ ){ 
                    
                    TV.AddNode("SUB" + X + Y, "SUB" + X + Y, "TOP" + X);
                    for(int Z = 1 ; Z < 5;Z++){ 
                        TV.AddNode("NODE " + value + X + Y + Z,"", "SUB" + X + Y,"FUNCT" + X + Y + Z);
                    }
                }
            }
            TV.Show(Page);
        }
        private class ProgressCtrl
        {
            public void Progress(Page Page, ContaNet.Tools.NSCore core)
            {
                Thread t = new Thread(() => ProgressTest(Page, core));
                t.Start();
            }
            private void ProgressTest(Page Page, ContaNet.Tools.NSCore core)
            {
                core.StartProgress(Page);
                string[] pass;
                pass = "Pass 1,Pass 2, Pass 3, Pass 4".Split(Convert.ToChar(","));
                for (int y = 0; y <= 3; y++)
                {
                    for (int X = 1; X <= 100; X++)
                    {
                        Thread.Sleep(100);
                        core.Progress(X, 100, pass[y] + " - " + Convert.ToString(X) + "%");
                    }
                }
                core.EndProgress();
            }
        }
    }

}

