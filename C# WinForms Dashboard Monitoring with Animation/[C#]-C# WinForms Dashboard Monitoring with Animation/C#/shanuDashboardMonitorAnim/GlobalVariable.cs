using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shanuDashboardMonitorAnim
{
    public class GlobalVariable
    {
        /// <summary>Index to Display all forms one by one</summary> 
        public static int[] frmDisplayIndex = new int[6] { 1, 2, 3, 4, 5, 6 };

        /// <summary>Timer Interval to display each Forms</summary>
        public static int[] interval = new int[6] { 4000, 5000, 6000, 5000, 6000, 7000 };

        /// <summary>Maximum number of Forms to be displayed</summary>
        public static int formDisplayCount = 6;
    }
}
