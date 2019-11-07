using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridExtension
{
    public class DateTimeGridColumn: DataGridViewColumn
    {

        public DateTimeGridColumn() : base(new DateTimeCell()) { }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null &&
                        !value.GetType().IsAssignableFrom(typeof(DateTimeCell)))
                    throw new InvalidCastException("Debe especificar una instancia de DateTimeCell");
                base.CellTemplate = value;
            }
        }
    }

    public class DateTimeCell: DataGridViewTextBoxCell
    {

        public DateTimeCell() : base() { }

        public override Type EditType {
            get { return typeof(DateTimeEditingControl); } 
        }

        public override Type ValueType
        {
            get { return typeof(DateTime); }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                object defaultValue = base.DefaultNewRowValue;
                if (defaultValue is DateTime)
                    return defaultValue;
                else
                    return DateTime.Now;
            }
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            DateTimeEditingControl ctl = DataGridView.EditingControl as DateTimeEditingControl;
            try
            {
                if (this.Value == null)
                    ctl.Value = (DateTime)this.DefaultNewRowValue;
                else
                    ctl.Value = (DateTime)this.Value;

            }
            catch (Exception)
            {
                ctl.Value = (DateTime)this.DefaultNewRowValue;
            }

            if (dataGridViewCellStyle.Format.Length == 1)
            {
                string[] patterns = DateTimeFormatInfo.CurrentInfo.GetAllDateTimePatterns(dataGridViewCellStyle.Format.ToCharArray()[0]);
                if (patterns.Length > 0)
                    ctl.CustomFormat = patterns[0].ToString();
                else
                    ctl.CustomFormat = dataGridViewCellStyle.Format;
            }
            else
                ctl.CustomFormat = dataGridViewCellStyle.Format;
        }
    }

    class DateTimeEditingControl : DateTimePicker, IDataGridViewEditingControl
    {

        private DataGridView grid;
        private bool valueChanged;

        public DateTimeEditingControl()
        {
            this.Format = DateTimePickerFormat.Custom;
        }

        protected override void OnValueChanged(EventArgs eventargs)
        {
            base.OnValueChanged(eventargs);
            SendToGridValueChanged();
        }

        private void SendToGridValueChanged()
        {
            valueChanged = true;
            if (grid != null)
                grid.NotifyCurrentCellDirty(true);
        }

        #region Miembros de IDataGridViewEditingControl

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
            this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

        public DataGridView EditingControlDataGridView
        {
            get { return grid; }
            set { grid = value; }
        }

        public object EditingControlFormattedValue
        {
            get
            {
                return this.Value.ToString(this.CustomFormat);
            }
            set
            {
                try { this.Value = DateTime.Parse((string)value); }
                catch { this.Value = DateTime.Now; }
                SendToGridValueChanged();
            }
        }

        public int EditingControlRowIndex { get; set; }

        public bool EditingControlValueChanged
        {
            get { return valueChanged; }
            set { valueChanged = value; }
        }

        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        public Cursor EditingPanelCursor
        {
            get { return base.Cursor; }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
        }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }

        #endregion

    }

}
