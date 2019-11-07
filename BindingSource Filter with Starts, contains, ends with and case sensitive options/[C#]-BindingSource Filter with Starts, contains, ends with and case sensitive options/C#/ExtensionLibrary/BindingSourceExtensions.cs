using System.Data;
using System.Windows.Forms;

namespace ExtensionLibrary
{
    public static class BindingSourceExtensions
    {
        public enum FilterCondition 
        {
            StartsWith,
            Contains,
            EndsWith
        }
        /// <summary>
        /// Cast DataSource to a DataTable
        /// </summary>
        /// <param name="pSender"></param>
        /// <returns></returns>
        public static DataTable DataTable(this BindingSource pSender)
        {
            return (DataTable)pSender.DataSource;
        }
        /// <summary>
        /// Access the DataView of the DataTable
        /// </summary>
        /// <param name="pSender"></param>
        /// <returns></returns>
        public static DataView DataView(this BindingSource pSender)
        {
            return ((DataTable)pSender.DataSource).DefaultView;
        }
        /// <summary>
        /// Provides filter for starts-with, contains or ends-with
        /// </summary>
        /// <param name="pSender"></param>
        /// <param name="pField">Field to apply filter on</param>
        /// <param name="pValue">Value for filter</param>
        /// <param name="pCondition">Type of filter</param>
        /// <param name="pCaseSensitive">Filter should be case or case in-sensitive</param>
        public static void RowFilter(this BindingSource pSender, string pField, string pValue, FilterCondition pCondition, bool pCaseSensitive = false)
        {
            switch (pCondition)
            {
                case FilterCondition.StartsWith:
                    pSender.RowFilterStartsWith(pField, pValue.EscapeApostrophe(), pCaseSensitive);
                    break;
                case FilterCondition.Contains:
                    pSender.RowFilterContains(pField, pValue.EscapeApostrophe(), pCaseSensitive);
                    break;
                case FilterCondition.EndsWith:
                    pSender.RowFilterEndsWith(pField, pValue.EscapeApostrophe(), pCaseSensitive);
                    break;
            }
        }
        public static void RowFilter(this BindingSource pSender, string pField, string pValue, bool pCaseSensitive = false)
        {
            pSender.DataTable().CaseSensitive = pCaseSensitive;
            pSender.DataView().RowFilter = $"{pField} = '{pValue.EscapeApostrophe()}'";
        }
        public static DataView RowFilterNewView(this BindingSource pSender, string pField, string pValue, bool pCaseSensitive = false)
        {
            pSender.DataTable().CaseSensitive = pCaseSensitive;
            pSender.DataView().RowFilter = $"{pField} = '{pValue.EscapeApostrophe()}'";

            DataView view = new DataView(pSender.DataTable())
            {
                RowFilter = $"{pField} = '{pValue.EscapeApostrophe()}'"
            };

            return view;

        }
        public static void RowFilterTwoConditions(this BindingSource pSender, string pField1, string pValue1, string pField2, string pValue2, bool pCaseSensitive = false)
        {
            pSender.DataTable().CaseSensitive = pCaseSensitive;
            pSender.DataView().RowFilter = $"{pField1} = '{pValue1.EscapeApostrophe()}' AND {pField2} = '{pValue2.EscapeApostrophe()}'";
        }
        /// <summary>
        /// Apply a filter for Like containts
        /// </summary>
        /// <param name="pSender"></param>
        /// <param name="pField">Field to apply filter on</param>
        /// <param name="pValue">Value for filter</param>
        /// <param name="pCaseSensitive">Filter should be case or case in-sensitive</param>
        public static void RowFilterContains(this BindingSource pSender, string pField, string pValue, bool pCaseSensitive = false)
        {
            pSender.DataTable().CaseSensitive = pCaseSensitive;
            pSender.DataView().RowFilter = $"{pField} LIKE '%{pValue.EscapeApostrophe()}%'";
        }
        /// <summary>
        /// Apply a filter for Like starts with
        /// </summary>
        /// <param name="pSender"></param>
        /// <param name="pField">Field to apply filter on</param>
        /// <param name="pValue">Value for filter</param>
        /// <param name="pCaseSensitive">Filter should be case or case in-sensitive</param>
        public static void RowFilterStartsWith(this BindingSource pSender, string pField, string pValue, bool pCaseSensitive = false)
        {
            pSender.DataTable().CaseSensitive = pCaseSensitive;
            pSender.DataView().RowFilter = $"{pField} LIKE '{pValue.EscapeApostrophe()}%'";
        }
        public static void RowFilterEndsWith(this BindingSource pSender, string pField, string pValue, bool pCaseSensitive = false)
        {
            pSender.DataTable().CaseSensitive = pCaseSensitive;
            pSender.DataView().RowFilter = $"{pField} LIKE '%{pValue.EscapeApostrophe()}'";
        }
        /// <summary>
        /// This exension is a free form method for filtering. The usage would be
        /// to provide a user interface to put together the condition.  See unit
        /// test FreeForm_CaseSensitive_OnBoth_Conditions_LastField_NotExact
        /// </summary>
        /// <param name="pSender"></param>
        /// <param name="pFilter"></param>
        /// <param name="pCaseSensitive"></param>
        public static void RowFilterFreeForm(this BindingSource pSender, string pFilter, bool pCaseSensitive = false)
        {
            pSender.DataTable().CaseSensitive = pCaseSensitive;
            pSender.DataView().RowFilter = pFilter;
        }
        /// <summary>
        /// Clear DataView RowFilter
        /// </summary>
        /// <param name="pSender"></param>
        public static void RowFilterClear(this BindingSource pSender)
        {
            pSender.DataView().RowFilter = "";
        }
        /// <summary>
        /// Determine if DataSource is set
        /// </summary>
        /// <param name="pSender"></param>
        /// <returns></returns>
        public static bool HasData(this BindingSource pSender)
        {
            return pSender.DataSource != null;
        }
        /// <summary>
        /// Method base of the function
        /// </summary>
        /// <param name="pSender"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this TextBox pSender)
        {
            return string.IsNullOrWhiteSpace(pSender.Text);
        }
    }
}
