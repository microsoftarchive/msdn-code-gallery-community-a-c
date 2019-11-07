using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using IWshRuntimeLibrary;

namespace Creating_Shortcuts_Demo
{
    public partial class Form1 : Form
    {
        //Get the Assembly Name of the application
        string appname = Assembly.GetExecutingAssembly().FullName.Remove(Assembly.GetExecutingAssembly().FullName.IndexOf(","));

        private string DesktopPathName;
        private string StartupPathName;
 
        //Used to stop the CheckBoxes CheckedChanged events from calling the CreateShortcut sub when the form is
        //loading and setting the Checkboxes states to true if the shortcuts exist.
        private bool Loading = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Adds the applications AssemblyName to the Desktops path and adds the .lnk extension used for shortcuts
            DesktopPathName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), appname + ".lnk");
            //Adds the applications AssemblyName to the Startup folder path and adds the .lnk extension used for shortcuts
            StartupPathName = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), appname + ".lnk");
            //Sets the Desktop checkbox checked state to true if the desktop shortcut exists
            CheckBox1.Checked = System.IO.File.Exists(DesktopPathName);
            //Sets the Startup Folder checkbox checked state to true if the Startup folder shortcut exists
            CheckBox2.Checked = System.IO.File.Exists(StartupPathName);
            //The checkboxes checked states have been set so set Loading to false to allow the CreateShortcut sub to be called now
            Loading = false;
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                if (CheckBox1.Checked)
                {
                    CreateShortcut(DesktopPathName, true); //Create a shortcut on the desktop
                }
                else
                {
                    CreateShortcut(DesktopPathName, false); //Remove the shortcut from the desktop
                }
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!Loading)
            {
                if (CheckBox2.Checked)
                {
                    CreateShortcut(StartupPathName, true); //Create a shortcut in the startup folder
                }
                else
                {
                    CreateShortcut(StartupPathName, false); //Remove the shortcut in the startup folder
                }
            }
        }

        /// <summary>Creates or removes a shortcut for this application at the specified pathname.</summary>
        /// <param name="shortcutPathName">The path where the shortcut is to be created or removed from including the (.lnk) extension.</param>
        /// <param name="create">True to create a shortcut or False to remove the shortcut.</param>
        private void CreateShortcut(string shortcutPathName, bool create)
        {
            if (create)
            {
                try
                {
                    string shortcutTarget = System.IO.Path.Combine(Application.StartupPath, appname + ".exe");
                    WshShell myShell = new WshShell();
                    WshShortcut myShortcut = (WshShortcut)myShell.CreateShortcut(shortcutPathName);
                    myShortcut.TargetPath = shortcutTarget; //The exe file this shortcut executes when double clicked
                    myShortcut.IconLocation = shortcutTarget + ",0"; //Sets the icon of the shortcut to the exe`s icon
                    myShortcut.WorkingDirectory = Application.StartupPath; //The working directory for the exe
                    myShortcut.Arguments = ""; //The arguments used when executing the exe
                    myShortcut.Save(); //Creates the shortcut
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    if (System.IO.File.Exists(shortcutPathName))
                        System.IO.File.Delete(shortcutPathName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
