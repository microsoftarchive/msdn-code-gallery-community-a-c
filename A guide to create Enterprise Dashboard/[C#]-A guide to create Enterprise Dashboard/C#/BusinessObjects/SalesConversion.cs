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
using System.ComponentModel;

namespace Visifire.Dashboards.ProductAndSales.BusinessObjects
{
    public class SalesConversion : Visifire.Dashboards.Commons.ModelBase
    {
        #region Public Methods

        /// <summary>
        /// Visifire.Dashboards.Commons.ModelBase.SalesConversion
        /// </summary>
        /// <param name="date">Date</param>
        /// <param name="product">Product</param>
        /// <param name="downloads">Number of Downloads</param>
        /// <param name="validLeads">Number of valid leads</param>
        /// <param name="leadsReached">Leads reched</param>
        /// <param name="qualifiedLeads">Number of qualified leads</param>
        /// <param name="conversion">Number of users bought</param>
        public SalesConversion(DateTime date, String product, Int32 downloads, Int32 validLeads,
            Int32 leadsReached, Int32 qualifiedLeads, Int32 conversion)
        {
            Date = date;
            Product = product;
            Downloads = downloads;
            ValidLeads = validLeads;
            LeadsReached = leadsReached;
            QualifiedLeads = qualifiedLeads;
            Conversion = conversion;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Bumber of users bought
        /// </summary>
        public Int32 Conversion
        {
            get
            {
                return _conversion;
            }
            set
            {
                _conversion = value;
                NotifyPropertyChanged("Conversion");
            }
        }

        /// <summary>
        /// Number of qualified leads
        /// </summary>
        public Int32 QualifiedLeads
        {
            get
            {
                return _qualifiedLeads;
            }
            set
            {
                _qualifiedLeads = value;
                NotifyPropertyChanged("QualifiedLeads");
            }
        }

        /// <summary>
        /// Number of leads reched
        /// </summary>
        public Int32 LeadsReached
        {
            get
            {
                return _leadsReached;
            }
            set
            {
                _leadsReached = value;
                NotifyPropertyChanged("LeadsReached");
            }
        }

        /// <summary>
        /// Number of valid leads
        /// </summary>
        public Int32 ValidLeads
        {
            get
            {
                return _validLeads;
            }
            set
            {
                _validLeads = value;
                NotifyPropertyChanged("Leads");
            }
        }

        /// <summary>
        /// Number of downloads
        /// </summary>
        public Int32 Downloads
        {
            get
            {
                return _downloads;
            }
            set
            {
                _downloads = value;
                NotifyPropertyChanged("Downloads");
            }
        }

        /// <summary>
        /// Product ID
        /// </summary>
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

        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                NotifyPropertyChanged("Date");
            }
        }

        #endregion

        #region Data

        Int32 _conversion;
        Int32 _qualifiedLeads;
        Int32 _leadsReached;
        Int32 _validLeads;
        Int32 _downloads;
        String _product;
        DateTime _date;

        #endregion
    }
}