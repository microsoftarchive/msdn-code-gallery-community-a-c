using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mm.CustomDatePicker.WpfApplication
{
    public class ViewModel : INotifyPropertyChanged
    {
        private DateTime? _date;
        public DateTime? Date
        {
            get { return _date; }
            set { _date = value; NotifyPropertyChanged(); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
