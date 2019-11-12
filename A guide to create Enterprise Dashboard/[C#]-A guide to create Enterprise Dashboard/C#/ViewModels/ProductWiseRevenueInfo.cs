using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Visifire.Dashboards.ProductAndSales.ViewModels
{
    public class ProductWiseRevenueInfo : Visifire.Dashboards.Commons.ModelBase
    {
        public Double Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                NotifyPropertyChanged("Amount");
            }
        }

        public Boolean Exploded
        {   
            get
            {
                return _exploded;
            }
            set
            {
                _exploded = value;
                NotifyPropertyChanged("Exploded");
            }
        }

        public String Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
                NotifyPropertyChanged("Product");
            }
        }

        Double _amount;
        Boolean _exploded;
        String _product;       
    }
}
