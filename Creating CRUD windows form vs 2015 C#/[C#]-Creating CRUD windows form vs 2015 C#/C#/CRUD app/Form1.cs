using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace CRUD_app
{
    public partial class Form1 : Form
    {
        employeeDataContext ed;
        string imagename;
        public Form1()
        {
            InitializeComponent();
            ed = new employeeDataContext();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            employeetab empTable = new employeetab(); // calling the employee class in the employee.designer.cs file

           
            var empid = from data in ed.employeetabs 
                              where data.empid == textBox1.Text.ToString()
                              select data; 

            if (!empid.Any())
            {

                if (imagename != "")
                {

                    FileStream fs;

                    fs = new FileStream(@imagename, FileMode.Open, FileAccess.Read);

                    //a byte array to read the image

                    byte[] picbyte = new byte[fs.Length];

                    fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));

                    fs.Close();

               


                    empTable.empid = textBox1.Text; 
                empTable.empname = textBox2.Text.ToString(); 
                empTable.empdep = textBox3.Text.ToString();
                empTable.empimage = picbyte;


                ed.employeetabs.InsertOnSubmit(empTable); 

               
                ed.SubmitChanges();  
                MessageBox.Show("Record Inserted Successfully");
                }

            }
            else MessageBox.Show("Record allready existing");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string empid = textBox1.Text.ToString();
            //Here "ed" is the  employeeDataContext
            employeetab emp = ed.employeetabs.Single(e1 => e1.empid == empid); //To Retrieve one single record from the database for the given empid.

            if (emp != null)
            {
                ed.employeetabs.DeleteOnSubmit(emp);
                ed.SubmitChanges();
                MessageBox.Show("Record Deleted");
            }
        }

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string empid = textBox1.Text;

            var empresult = from data in ed.employeetabs  // Ling Query to retrive data from table
                            where data.empid == empid
                            select data;
            if(empresult.Any()) { 


            // Data Binding
            foreach (var emp in empresult)
            {

                    MemoryStream stream = new MemoryStream();
              

                    textBox2.Text = emp.empname.ToString(); // Retriving column data and binding to the textbox
                    textBox3.Text = emp.empdep.ToString(); // Retriving column data and binding to the textbox
                    if(emp.empimage != null) { 
                    byte[] image = (byte[])emp.empimage.ToArray();

                    stream.Write(image, 0, image.Length);
                      //Bitmap bitmap = new Bitmap(stream);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                        pictureBox1.Image = Image.FromStream(stream);
                        ;

                    }
                     
                }

            }
            else {

                textBox2.Text = ""; textBox3.Text = "";
                pictureBox1.Image = null;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string empid = textBox1.Text;
            employeetab emp = ed.employeetabs.Single(e1 => e1.empid == empid); //To Retrieve one single record from the database for the given empid.

            emp.empid = textBox1.Text; // Mapping the data to the column in the table
            emp.empname = textBox2.Text.ToString(); // Mapping the data to the column in the table
            emp.empdep = textBox3.Text.ToString(); // Mapping the data to the column in the table
                                                   //emp.EMP_LOCATION = txtEmpLocation.Text.ToString(); // Mapping the data to the column in the table  

            if (imagename != "")
            {
                FileStream fs;


                fs = new FileStream(@imagename, FileMode.Open, FileAccess.Read);
              

                //a byte array to read the image

                byte[] picbyte = new byte[fs.Length];

                fs.Read(picbyte, 0, System.Convert.ToInt32(fs.Length));

                fs.Close();

                emp.empimage = picbyte;


                ed.SubmitChanges();
               
                imagename = "";

            }
            MessageBox.Show("Record Updated");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                FileDialog fldlg = new OpenFileDialog();

                //specify your own initial directory

                fldlg.InitialDirectory = @"C:\";

                //this will allow only those file extensions to be added

                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";

                if (fldlg.ShowDialog() == DialogResult.OK)
                {

                    imagename = fldlg.FileName;

                    //Bitmap newimg = new Bitmap(imagename);

                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                    pictureBox1.Image = Image.FromFile(imagename);

                }

                fldlg = null;

            }

            catch (System.ArgumentException ae)
            {

                imagename = " ";

                MessageBox.Show(ae.Message.ToString());

            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void cmdClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }
    }
}
