using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
namespace APIPro
{
   
    public class Win32Api
    {
        public struct POINTAPI
        {
            public long x;
            public long y;
        }
        /*Public Declare Function WindowFromPoint Lib "user32" Alias "WindowFromPoint" (ByVal xPoint As Long, ByVal yPoint As Long) As Long
        Public Declare Function GetCursorPos Lib "user32" Alias "GetCursorPos" (lpPoint As POINTAPI) As Long
        Public Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hwnd As Long, ByVal lpString As String, ByVal cch As Long) As Long
        Public Declare Function GetParent Lib "user32" Alias "GetParent" (ByVal hwnd As Long) As Long
        Public Declare Function GetClassName Lib "user32" Alias "GetClassNameA" (ByVal hwnd As Long, ByVal lpClassName As String, ByVal nMaxCount As Long) As Long
        Public Declare Function ChildWindowFromPoint Lib "user32" Alias "ChildWindowFromPoint" (ByVal hWndParent As Long, ByVal pt As POINTAPI) As Long*/

        [DllImport("User32.dll")]
        public static extern long WindowFromPoint(long x, long y);

        [DllImport("User32.dll")]
        public static extern long GetCursorPos(ref POINTAPI p);

        [DllImport("User32.dll")]
        public static extern long GetWindowTextA(long hwnd, ref string lpString, long cch);

        [DllImport("User32.dll")]
        public static extern long GetParent(long hwnd);

        [DllImport("User32.dll")]
        public static extern long ChildWindowFromPoint(long hWndParent, long x, long y);

        [DllImport("User32.dll")]
        public static extern long GetclassNameA(long hwnd, string lpClassName, long nMaxCount);
    }
}
