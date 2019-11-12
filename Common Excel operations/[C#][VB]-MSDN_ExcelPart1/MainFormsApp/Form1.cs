using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelOperations;
using ExcelOpenXmlLibrary;
using DesktopLibrary;
using VisualBasicLibrary;
using OledbCode = ExcelOperations.OleDbWork;


namespace MainApplication
{
    /// <summary>
    /// In Form Shown event old Excel files are removed and fresh files
    /// are copied into the application folder for a fresh start.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Responsible for copying fresh copies of sample excel files
        /// to the application folder.
        /// </summary>
        private readonly FolderLibrary.CleanCopyOperations _fileOperations =
            new FolderLibrary.CleanCopyOperations();

        public Form1()
        {
            InitializeComponent();
            
            Shown += Form1_Shown;
            Closing += Form1_Closing;

        }
        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            timerForExcel.Enabled = false;
        }
        private void toolButtonOpenDebugFolder_ButtonClick(object sender, EventArgs e)
        {
            Process.Start(AppDomain.CurrentDomain.BaseDirectory);
        }
        /// <summary>
        /// Setup
        /// * Get fresh copies of Excel files.
        /// * Get sheet names from Customers.xlsx via OpenXml
        /// * Setup a timer to watch for Excel processes open.
        ///   This assumes you don't have Excel open outside this app.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Shown(object sender, EventArgs e)
        {

            timerForExcel.Enabled = true;

            /*
             * Start with a clean slate in regards to base Excel files
             */
            _fileOperations.RemoveExcelFiles();

            /*
             * These files were not copied over
             */
            _fileOperations.RemoveOtherExcelFiles(new[]
            {
                "Cust.xlsx",
                "PeopleDemo.xlsx",
                "BadPeopleDemo.xlsx",
                "Customers.xml"
            });

            /*
             * Copy files from base file folder
             */
            _fileOperations.CopyExcelFiles();

            if (_fileOperations.HasException)
            {
                MessageBox.Show($"Issues with file delete/copy{Environment.NewLine}{_fileOperations.LastExceptionMessage}");
            }

            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Customers.xlsx");

            /*
             * There is also an automated method that does the
             * same as this in ExcelBase class. This method was
             * used as it's faster than using automation.
             */
            var helper = new OpenXmlExamples();
            var sheetNames = helper.SheetNames(fileName);

            sheetNames.Insert(0,"Select sheet");
            cboCustomerSheetNames.DataSource = sheetNames;

        }
        #region Timer logic

        private bool IsExcelInMemory()
        {
            return Process.GetProcesses().Any(p => p.ProcessName.Contains("EXCEL"));
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsExcelInMemory())
            {
                toolStripStatusLabel1.Image = Properties.Resources.ExcelInMemory;
            }
            else
            {
                toolStripStatusLabel1.Image = Properties.Resources.ExcelNotInMemory;
            }

            toolStripStatusLabel1.Invalidate();
        }

        #endregion
        /// <summary>
        /// Uses excel automation to read targeted cells in a specific worksheet.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSimpleOpenReadExample_Click(object sender, EventArgs e)
        {
            txtResults.Clear();

            if (cboCustomerSheetNames.Text == "Select sheet")
            {
                MessageBox.Show("Please select a sheet name");
                return;                
            }

            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Customers.xlsx");

            /*
             * A very simply example to read cells in the dictionary
             */
            var example = new ExcelBaseExample
            {
                ReturnDictionary = new Dictionary<string, object>()
                {
                    { "A1", null },
                    { "B2", null },
                    { "B3", null },
                    { "B4", null },
                    { "C2", null },
                    { "C4", null },
                    { "C5", null }
                }
            };

            /*
             * Read the cells in the Excel file and iterate the
             * cell data to a textBox.
             */
            example.ReadCells(fileName, cboCustomerSheetNames.Text);

            if (example.HasErrors)
            {
                txtResults.Text = example.ExceptionInfo.ToString();
            }
            else
            {
                foreach (var kvp in example.ReturnDictionary)
                {
                    txtResults.AppendText($"{kvp}{Environment.NewLine}");
                }

                txtResults.SelectionStart = 1;
                txtResults.ScrollToCaret();
            }
        }
        /// <summary>
        /// Get last used row and column for a sheet using Excel automation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// This code sample also implements a delegate which reports progress
        /// to the listbox on this form. This is an alternate to running the
        /// Visual Studio debugger stepping through code looking for issues.
        /// 
        /// It does not rule out using the debugger all the time just an alternate
        /// for some operations.
        /// </remarks>
        private void cmdUsedRowsColumns_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            var example = new ExcelBaseExample();

            example.ProgressUpdated += new EventHandler<ExaminerEventArgs>(ShowProgress);

            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Demo.xlsx");
            var sheetName = "Sheet1";

            var result = example.UsedRowsColumns(fileName, "Sheet1");

            txtUsedRowsColumns.Text = $"{Path.GetFileName(fileName)}.{sheetName} {result}";

        }

        private void ShowProgress(object sender, ExaminerEventArgs e)
        {
            listBox1.Items.Add(e.StatusMessage);
        }

        /// <summary>
        /// Uses Excel automation to get sheet names, extremely slow compared to OpenXml below
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdGetSheetNamesAutomation_Click(object sender, EventArgs e)
        {
            var example = new ExcelBaseExample();
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Customers.xlsx");
            var sheetNames = example.GetWorkSheetNames(fileName);

            sheetNames.Insert(0, "Select sheet");
            cboSheetNamesAutomation.DataSource = sheetNames;

        }
        /// <summary>
        /// Uses OpenXml to read sheet names, extremely fast,
        /// the vb.net xml example is just as fast.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdGetSheetNamesXml_Click(object sender, EventArgs e)
        {
            var helper = new OpenXmlExamples();
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Customers.xlsx");
            var sheetNames = helper.SheetNames(fileName);

            if (helper.IsSuccessFul)
            {
                sheetNames.Insert(0, "Select sheet");
                cboGetSheetNamesXml.DataSource = sheetNames;
            }
            else
            {
                Dialogs.ExceptionDialog(helper.LastException);
            }

        }
        /// <summary>
        /// Retrieve sheet names using OleDb data provider
        /// which unlike automation or open xml the sheet names
        /// are a-z order rather then ordinal position.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdGetSheetNamesOleDb_Click(object sender, EventArgs e)
        {
            var helper = new OledbCode.Operations();
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Customers.xlsx");
            var sheetNames = helper.SheetNames(fileName);

            if (helper.IsSuccessFul)
            {
                sheetNames.Insert(0, "Select sheet");
                cboGetSheetNamesOleDb.DataSource = sheetNames;
            }
            else
            {
                Dialogs.ExceptionDialog(helper.LastException);
            }

        }
        /// <summary>
        /// Example using a wrapper library over OpenXml to read a specific worksheet
        /// where the data will match up to a concrete class, in this case Customer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdReadUsingWrapperLibOverOpenXml_Click(object sender, EventArgs e)
        {
            var helper = new OpenXmlExamples();
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Customers.xlsx");
            var customers = helper.ClassToExcelReaderServiceReader(fileName);

            var f = new frmCustomers(customers);
            try
            {
                f.ShowDialog();
            }
            finally
            {
                f.Dispose();
            }
        }
        /// <summary>
        /// Read in a work sheet using OleDb data provider. One must be careful when
        /// there is mixed data in a column. This demo does not have mixed data so
        /// there will be no issues unlike working with mixed data there is no one
        /// solution.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdReadCustomersOleDb_Click(object sender, EventArgs e)
        {
            var helper = new OledbCode.Operations();
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Customers.xlsx");
            var customers = helper.ReadCustomers(fileName);
            //var test = helper.ReaDataTable(fileName);

            var f = new frmCustomers(customers);
            try
            {
                f.ShowDialog();
            }
            finally
            {
                f.Dispose();
            }
        }
        /// <summary>
        /// Example to get used range via OpenXml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdUsedRangeOpenXml_Click(object sender, EventArgs e)
        {
            var helper = new OpenXmlExamples();
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Customers.xlsx");
            var sheetName = "Customers";
            var customers = helper.ClassToExcelReaderServiceReader(fileName);

            var result = helper.UsedRange(fileName, sheetName);
            txtUsedRangeOpenXml.Text = $"{Path.GetFileName(fileName)}.{sheetName} {result}";
        }
        /// <summary>
        /// No real method for this that can hold up to automation or open xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdUsedRangeOleDb_Click(object sender, EventArgs e)
        {
            Dialogs.InformationDialog("This is not possible with acceptable code.");
        }
        /// <summary>
        /// Create a new Excel file in the application folder with
        /// a hard coded file name and sheet name to keep it simple.
        /// 
        /// If you run the code, create the file, open the file via
        /// Windows Explorer then try to create we fail as the file
        /// is in use.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCreateWithOpenXml_Click(object sender, EventArgs e)
        {          
            var helper = new OpenXmlExamples();
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cust.xlsx");
            var sheetName = "Customers";

            helper.CreateNewFile(fileName, sheetName);

            if (helper.IsSuccessFul)
            {
                Dialogs.InformationDialog("Excel file created");
            }
            else
            {
                Dialogs.ExceptionDialog(helper.LastException);
            }
            
        }
        /// <summary>
        /// There is no way to create an Excel file via OleDb. If you have
        /// code to get all your work done with OleDb except for creating
        /// a new file then consider placing a blank Excel file in a folder
        /// beneath the application folder and copy it to where you need 
        /// it to work on similar to how in the demo fresh Excel files are
        /// copied from a fresh folder to the application folder.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCreateExcelFileOleDb_Click(object sender, EventArgs e)
        {
            Dialogs.InformationDialog("There are no native method for OleDb to create a new Excel file, see comments for this button");
        }
        /// <summary>
        /// Using OpenXML create a new Excel file, setup a WorkSheet
        /// and populate the WorkSheet with data read from SQL-Server
        /// using two tables joined together.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCreateAndFillWithOpenXml_Click(object sender, EventArgs e)
        {
            var ops = new DataOperations();
            var people = ops.GetPeople();
            var xmlOps = new OpenXmlExamples();
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PeopleDemo.xlsx");
            var sheetName = "People";

            xmlOps.CreateExcelDocPopulateWithPeople(fileName, sheetName, people);
            
            if (xmlOps.IsSuccessFul)
            {
                Dialogs.InformationDialog("Excel file created and populated");
            }
            else
            {
                Dialogs.ExceptionDialog(xmlOps.LastException);
            }
        }
        /// <summary>
        /// This is a classic example working with Excel with no regards to
        /// memory management. Run the code and it works yet get a tad bit complex
        /// with this code and there can be objects not released.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void cmdCrappyCreateAndPopulateAutomationButton_ClickAsync(object sender, EventArgs e)
        {
            if (Dialogs.Question("Depenent on you PC this may be very slow, do you want to continue?"))
            {
                var ops = new DataOperations();

                var people = ops.GetPeople().ToDataTable();

                var eops = new BadExportThatWorks();

                var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BadPeopleDemo.xlsx");

                await eops.CreateSheetFromDataDataAsync(people, fileName).ConfigureAwait(true);

                Dialogs.InformationDialog("Finished");
            }
        }
        /// <summary>
        /// Exports a DataGridView to Excel.
        /// 
        /// First make sure the WorkSheet does not exists, if the WorkSheet exists abort.
        /// 
        /// If the WorkSheet does not exist, display data retrieved from a SQL-Server database table in a 
        /// DataGridView that is unbound meaning adding DataGridView rows rather than setting the 
        /// DataGridView DataSoure. 
        /// 
        /// Take the DataGridView and convert to a DataTable where all DataColumn's are converted to
        /// strings.
        /// 
        /// Next control is passed to a method in ExcelOperations.OleDbWork.Operations.ExportDataTableToExcel
        /// See comments in ExportDataTableToExcel. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// There are literally thousands of recommendations out there for performing what this code
        /// does. This is unlike other versions out there for strictly working with OleDb.
        /// </remarks>
        private void cmdCopyAndPopulateOleDb_Click(object sender, EventArgs e)
        {
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PeopleOleDbImport.xlsx");
            var sheetName = "People";
            var oleOperations = new OledbCode.Operations();

            if (oleOperations.SheetNames(fileName).Contains(sheetName))
            {
                MessageBox.Show($"Sheet {sheetName} already exists");
                return;
            }

            var f = new ExportDataGridViewToExcelForm();

            try
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    var dtPeople = f.DataTable;
                    dtPeople.TableName = sheetName;
                    oleOperations.ExportDataTableToExcel(fileName,dtPeople);
                    if (oleOperations.IsSuccessFul)
                    {
                        Dialogs.InformationDialog("Export finished");
                    }
                    else
                    {
                        Dialogs.ExceptionDialog(oleOperations.LastException);
                    }
                }
            }
            finally
            {
                f.Dispose();
            }

        }
        /// <summary>
        /// Import a text file into an existing Excel file, creates a new WorkSheet and
        /// populates the WorkSheet with comma delimited data from the text file. Note that
        /// the folder in this case is our database so in the method ImportFromTextFile the
        /// connection string has DATABASE which is set the current application's executable
        /// folder.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdImportTextFileIntoWorkSheetOleDb_Click(object sender, EventArgs e)
        {

            var oleOperations = new OledbCode.Operations();
            var excelFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ImportFromTextFile.xlsx");
            var textFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sample1.txt");
            var sheetName = "Customers";
            if (oleOperations.ImportFromTextFile(excelFileName, textFileName, sheetName))
            {
                MessageBox.Show("Import done");
            }
            else
            {
                Dialogs.ExceptionDialog(oleOperations.LastException);
            }

        }
        /// <summary>
        /// Open Windows Task manager. Open once, select
        /// Process tab, close. Next time it's opened the
        /// Process tab will be selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            
            var path = Environment.GetFolderPath(Environment.Is64BitOperatingSystem
                ? Environment.SpecialFolder.SystemX86 
                : Environment.SpecialFolder.System);

            Process.Start(Path.Combine(path, "taskmgr.exe"));   
        }
        /// <summary>
        /// A very different method to create and populate a new Excel file
        /// and work sheet using xml elements.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCreateAndPopulateWithVb_Click(object sender, EventArgs e)
        {
            var dataOperations = new DataOperations();
            var dtCustomers = dataOperations.GetCustomers();
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Customers.xml");
            var vbOperations = new CreateCustomerExcelFile();
            vbOperations.Demo(dtCustomers, fileName);
            Dialogs.InformationDialog("Finished");
        }

        private void cmdSimpleOleSearch_Click(object sender, EventArgs e)
        {
            var ops = new OledbCode.Operations();
            var fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Customers.xlsx");
            var (Table, Success) = ops.ReaDataTable(fileName, "Sales Representative");
            if (Success)
            {
                if (Table.Rows.Count >0)
                {
                    MessageBox.Show("Done");
                }
                else
                {
                    MessageBox.Show("Done, nothing for search");
                }
            }
            else
            {
                MessageBox.Show($"Encountered an issue: {ops.LastExceptionMessage}");
            }
        }
    }
}
