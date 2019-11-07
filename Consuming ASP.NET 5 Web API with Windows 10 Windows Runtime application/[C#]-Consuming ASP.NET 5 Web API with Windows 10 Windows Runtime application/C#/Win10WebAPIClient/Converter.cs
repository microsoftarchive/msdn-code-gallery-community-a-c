using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Win10WebAPIClient
{
    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string val = "";
            switch (Boolean.Parse(value.ToString()))
            {
                case true:
                    val = "Male";
                    break;
                case false:
                    val = "Female";
                    break;
                default:
                    break;
            }
            return val;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return ((value as string) == "Male" ? true : false);
        }
    }
}