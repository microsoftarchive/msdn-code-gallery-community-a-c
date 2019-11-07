using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Student_form : Form
    {
        public Student_form()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
        }



        private void Back_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            f.Show();
            this.Hide();
        }


        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.Image = Properties.Resources.button3_hover;
            Message_show.Text = "In Department form you can add a new Department, delete an existing record and update an existing record";
            icon_show.Image = Properties.Resources.Building_Clip_Art1;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Image = Properties.Resources.button3_normal;
            Message_show.Text = "";
            icon_show.Image = null;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.Image = Properties.Resources.button4_hover;
            icon_show.Image = Properties.Resources.registration1;
            Message_show.Text = "In Registration form you can register Students, delete an existing record and update an existing record";
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.Image = Properties.Resources.button4_normal;
            icon_show.Image = null;
            Message_show.Text = "";
        }

        private void Button1_MouseHover(object sender, EventArgs e)
        {
            Button1.Image = Properties.Resources.button1_hover;
            icon_show.Image = Properties.Resources.std;
            Message_show.Text = "In Student form you can add a new record, delete an existing record and update an existing record";
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            Button1.Image = Properties.Resources.button1_normal;
            Message_show.Text = "";
            icon_show.Image = null;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.Image = Properties.Resources.button2_hover;
            icon_show.Image = Properties.Resources.sir;
            Message_show.Text = "In Faculty form you can add a new faculty member, delete an existing record and update an existing record";
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Image = Properties.Resources.button2_normal;
            Message_show.Text = "";
            icon_show.Image = null;
        }

        private void button6_MouseHover(object sender, EventArgs e)
        {
            button6.Image = Properties.Resources.button6_hover;
            icon_show.Image = Properties.Resources.books;
            Message_show.Text = "In Course form you can add a new course which is being offered, delete an existing record and update an existing record";
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.Image = Properties.Resources.button6_normal;
            icon_show.Image = null;
            Message_show.Text = "";
        }
        public bool CheckForm(string  arr)
        {
            bool flag = false;
            Form[] array = this.MdiChildren;
            foreach (Form temp in array)
            {
                if (temp.GetType().ToString() == "WindowsFormsApplication1."+ arr)
                {
                    flag = true;
                }
            }
            return flag;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (!CheckForm("student_data"))
            {
                student_data std = new student_data();
                std.MdiParent = this;
                std.Show();
                std.Location = new System.Drawing.Point(137, 0);
            }
            else
            {
                MessageBox.Show("Already");
            }
        }

        private void Student_form_Load(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!CheckForm("Faculty"))
            {
                faculty fac = new faculty();
                fac.MdiParent = this;
                fac.Show();
                fac.Location = new System.Drawing.Point(137, 0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!CheckForm("department"))
            {
                department dp = new department();
                dp.MdiParent = this;
                dp.Show();
                dp.Location = new System.Drawing.Point(137, 0);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!CheckForm("register"))
            {
                register rg = new register();
                rg.MdiParent = this;
                rg.Show();
                rg.Location = new System.Drawing.Point(137, 0);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!CheckForm("course"))
            {
                course c = new course();
                c.MdiParent = this;
                c.Show();
                c.Location = new System.Drawing.Point(137, 0);
            }
        }
    }
}
