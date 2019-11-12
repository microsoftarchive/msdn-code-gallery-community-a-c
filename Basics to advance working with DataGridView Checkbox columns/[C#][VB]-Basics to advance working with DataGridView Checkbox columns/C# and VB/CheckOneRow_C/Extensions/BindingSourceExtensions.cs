using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Windows.Forms;

static class BindingSourceExtensions
{
    public static string CurrentRow(this BindingSource sender, string Column)
    {
        return ((DataRowView)sender.Current).Row[Column].ToString();
    }
}
