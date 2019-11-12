using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace APIPro
{
    public partial class frmAPIPro : Form
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public POINT(System.Drawing.Point pt) : this(pt.X, pt.Y) { }

            public static implicit operator System.Drawing.Point(POINT p)
            {
                return new System.Drawing.Point(p.X, p.Y);
            }

            public static implicit operator POINT(System.Drawing.Point p)
            {
                return new POINT(p.X, p.Y);
            }
        }
        /*Public Declare Function WindowFromPoint Lib "user32" Alias "WindowFromPoint" (ByVal xPoint As Long, ByVal yPoint As Long) As Long
        Public Declare Function GetCursorPos Lib "user32" Alias "GetCursorPos" (lpPoint As POINTAPI) As Long
        Public Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hwnd As Long, ByVal lpString As String, ByVal cch As Long) As Long
        Public Declare Function GetParent Lib "user32" Alias "GetParent" (ByVal hwnd As Long) As Long
        Public Declare Function GetClassName Lib "user32" Alias "GetClassNameA" (ByVal hwnd As Long, ByVal lpClassName As String, ByVal nMaxCount As Long) As Long
        Public Declare Function ChildWindowFromPoint Lib "user32" Alias "ChildWindowFromPoint" (ByVal hWndParent As Long, ByVal pt As POINTAPI) As Long*/

        [DllImport("User32.dll")]
        static extern IntPtr WindowFromPoint(POINT p);

        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(ref POINT p);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern long GetWindowText(IntPtr hwnd, StringBuilder lpString, long cch);

        [DllImport("User32.dll")]
        static extern IntPtr GetParent(IntPtr hwnd);

        [DllImport("User32.dll")]
        static extern IntPtr ChildWindowFromPoint(IntPtr hWndParent, POINT p);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern long GetClassName(IntPtr hwnd, StringBuilder lpClassName, long nMaxCount);
        
        POINT p;

        public frmAPIPro()
        {
            InitializeComponent();
        }

        private void frmAPIPro_Load(object sender, EventArgs e)
        {
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            tmrCursorPos.Enabled = true;
            tmrCursorPos.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            tmrCursorPos.Stop();
            tmrCursorPos.Enabled = false;
        }

        private void tmrCursorPos_Tick(object sender, EventArgs e)
        {
            bool retVal = GetCursorPos(ref p);
            if (retVal)
            {
                lblXPos.Text = "Mouse X : " + Convert.ToString(p.X);
                lblYPos.Text = "Mouse Y : " + Convert.ToString(p.Y);
                IntPtr hwnd = WindowFromPoint(p);
                lblHWnd.Text = "Window Handle : " + hwnd.ToInt64();
                if (hwnd.ToInt64() > 0)
                {
                    rtbCaption.Text =  GetCaptionOfWindow(hwnd);
                    rtbClassName.Text = GetClassNameOfWindow(hwnd);

                    //For Parent
                    IntPtr hWndParent = GetParent(hwnd);
                    if (hWndParent.ToInt64() > 0)
                    {
                        rtbWinParent.Text = GetCaptionOfWindow(hWndParent);
                    }
                }
                //this.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss.fff");
            }
        }


        string GetCaptionOfWindow(IntPtr hwnd)
        {
            string caption = "";
            StringBuilder windowText  = null;
            try
            {
                int max_length = GetWindowTextLength(hwnd);
                windowText = new StringBuilder("", max_length + 5);
                GetWindowText(hwnd, windowText, max_length + 2);

                if (!String.IsNullOrEmpty(windowText.ToString()) && !String.IsNullOrWhiteSpace(windowText.ToString()))
                    caption = windowText.ToString();
            }
            catch (Exception ex)
            {
                caption = ex.Message;
            }
            finally
            {
                windowText = null;
            }
            return caption;
        }

        string GetClassNameOfWindow(IntPtr hwnd)
        {
            string className = "";
            StringBuilder classText = null;
            try
            {
                int cls_max_length = 1000;
                classText = new StringBuilder("", cls_max_length + 5);
                GetClassName(hwnd, classText, cls_max_length + 2);

                if (!String.IsNullOrEmpty(classText.ToString()) && !String.IsNullOrWhiteSpace(classText.ToString()))
                    className = classText.ToString();
            }
            catch (Exception ex)
            {
                className = ex.Message;
            }
            finally
            {
                classText = null;
            }
            return className;
        }
    }
}
