using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace GridExtension
{
    public class NumericGridColumn : DataGridViewColumn
    {
        private NumberFormatInfo _numberFormat;
        private string _decimalSeparator;
        private int _decimalDigits = -1;

        public NumericGridColumn():base (new NumericGridCell()) { }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null &&
                        !value.GetType().IsAssignableFrom(typeof(NumericGridCell)))
                    throw new InvalidCastException("Debe especificar una instancia de NumericGridCell");
                base.CellTemplate = value;
            }
        }

        [Category("Appearance")]
        public string DecimalSeparator {
            get {
                if (string.IsNullOrEmpty(_decimalSeparator))
                    return CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator;
                else
                    return _decimalSeparator;
            }
            set
            {
                if (value.Length != 1)
                    throw new ArgumentException("El separador decimal debe ser un único caracter");
                _decimalSeparator = value;
            }
        }

        [Category("Appearance")]
        public int DecimalDigits {
            get
            {
                if (_decimalDigits < 0)
                    return CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalDigits;
                else
                    return _decimalDigits;
            }
            set { _decimalDigits = value; }
        }

        internal NumberFormatInfo NumberFormat
        {
            get
            {
                if (_numberFormat == null)
                    _numberFormat = new NumberFormatInfo();
                _numberFormat.NumberDecimalSeparator = DecimalSeparator;
                _numberFormat.NumberDecimalDigits = DecimalDigits;
                return _numberFormat;
            }
        }

        public override object Clone()
        {
            NumericGridColumn newColumn = (NumericGridColumn)base.Clone();
            newColumn.DecimalSeparator = DecimalSeparator;
            newColumn.DecimalDigits = DecimalDigits;
            return newColumn;
        }

    }

    public class NumericGridCell: DataGridViewTextBoxCell
    {
        public NumericGridCell() : base() { }

        private NumberFormatInfo NumberFormat
        {
            get
            {
                return ((NumericGridColumn)OwningColumn).NumberFormat;
            }
        }

        public override Type ValueType
        {
            get { return typeof(decimal?); }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                object defaultValue = base.DefaultNewRowValue;
                if (defaultValue is decimal)
                    return defaultValue;
                else
                    return null;
            }
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            Control ctl = DataGridView.EditingControl;
            ctl.KeyPress += new KeyPressEventHandler(NumericCell_KeyPress);
        }

        private void NumericCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            DataGridViewCell currentCell = ((IDataGridViewEditingControl)sender).EditingControlDataGridView.CurrentCell;
            if (!(currentCell is NumericGridCell)) return;

            DataGridViewTextBoxEditingControl ctl = (DataGridViewTextBoxEditingControl)sender;
            if (char.IsDigit(e.KeyChar))
            {
                int separatorPosition = ctl.Text.IndexOf(NumberFormat.NumberDecimalSeparator);
                if (separatorPosition >= 0 && ctl.SelectionStart>separatorPosition)
                {
                    int currentDecimals = ctl.Text.Length - separatorPosition 
                        - NumberFormat.NumberDecimalSeparator.Length - ctl.SelectionLength;
                    if (currentDecimals >= NumberFormat.NumberDecimalDigits)
                        e.Handled = true;
                }
            }
            else if (e.KeyChar.ToString().Equals(NumberFormat.NumberDecimalSeparator))
            {
                e.Handled = ctl.Text.IndexOf(NumberFormat.NumberDecimalSeparator) >= 0;                
            }
            else
            {
                e.Handled = !char.IsControl(e.KeyChar);
            }
        }

        public override DataGridViewCellStyle GetInheritedStyle(DataGridViewCellStyle inheritedCellStyle, int rowIndex, bool includeColors)
        {
            DataGridViewCellStyle style= base.GetInheritedStyle(inheritedCellStyle, rowIndex, includeColors);
            style.FormatProvider = NumberFormat;
            return style;
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (value == null)
                return null;
            else
                return ((decimal)value).ToString(cellStyle.FormatProvider);
        }

    }

}
