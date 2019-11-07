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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Visifire.Dashboards.ProductAndSales.Models;

namespace Visifire.Dashboards.ProductAndSales.ViewModels
{
    public class MainPageViewModel : Visifire.Dashboards.Commons.ModelBase
    {
        #region Public Methods

        public MainPageViewModel()
        {
            _orders = Models.SampleDataStore.GetSampleOrders();
            _salesConversions = SampleDataStore.GetSampleSalesConversions(_orders);
            SelectedProduct = SampleDataStore.PRODUCT_A;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Selected Month On click of pie
        /// </summary>
        public Int32 SelectedMonth
        {
            get
            {
                return DrpMonthSelectedIndex + 1;
            }
        }

        /// <summary>
        /// Dropdown month selector’s selected index
        /// </summary>
        public Int32 DrpMonthSelectedIndex
        {
            get
            {
                return _drpMonthSelectedIndex;
            }
            set
            {
                _drpMonthSelectedIndex = value;
                NotifyPropertyChanged("DrpMonthSelectedIndex");
                OnSelectedMonthChanged(SelectedMonth);
            }
        }

        /// <summary>
        /// Conversion ratio chart ColorSet
        /// </summary>
        public String ConversionRatioChartColorSet
        {
            get
            {
                return _conversionRatioChartColorSet;
            }
            set
            {
                _conversionRatioChartColorSet = value;
                NotifyPropertyChanged("ConversionRatioChartColorSet");
            }
        }

        /// <summary>
        /// Title of the Gauge which show revenue in percentage
        /// </summary>
        public String GaugeTitle
        {
            get
            {
                return String.Format(@"Annual Revenue of {0}", SelectedProduct);
            }
            set
            {
                NotifyPropertyChanged("GaugeTitle");
            }
        }

        /// <summary>
        /// Title of the conversion ratio chart
        /// </summary>
        public String ConversionRatioChartTitle
        {
            get
            {
                return String.Format(@"{0} Sales Conversion Ratio", SelectedProduct);
            }
            set
            {
                NotifyPropertyChanged("ConversionRatioChartTitle");
            }
        }

        /// <summary>
        /// Title of the chart shows types of licenses sold
        /// </summary>
        public String LicensesSoldChartTitle
        {
            get
            {
                return String.Format(@"{0} Licenses Sold", SelectedProduct);
            }
            set
            {
                NotifyPropertyChanged("LicensesSoldChartTitle");
            }
        }

        /// <summary>
        /// Title of the chart which shows number licences sold vs number of upgrades
        /// </summary>
        public String ChartUpgradeOrNewTitle
        {
            get
            {
                return String.Format(@"{0} | New Licenses vs. Upgrades", SelectedProduct);
            }
            set
            {
                NotifyPropertyChanged("ChartUpgradeOrNewTitle");
            }
        }

        /// <summary>
        /// Number of licenses sold without support / licenses
        /// </summary>
        public IEnumerable LicensesSoldWithoutSupport
        {
            get
            {
                var licensesSoldWithoutSupport = (from record in _orders
                                                  where record.Product == SelectedProduct && !record.WithSupport && record.Date.Month == SelectedMonth
                                                  group record by record.LicenseType into groupedOrders
                                                  select new KeyValuePair<String, Double>(
                                                      groupedOrders.First().LicenseType,
                                                      groupedOrders.Count())).ToList();

                return licensesSoldWithoutSupport;
            }
            set
            {
                NotifyPropertyChanged("LicensesSoldWithoutSupport");
            }
        }


        /// <summary>
        /// Number of licenses sold with support / licenses
        /// </summary>
        public IEnumerable LicensesSoldWithSupport
        {
            get
            {
                var licensesSoldWithSupport = (from record in _orders
                                               where record.Product == SelectedProduct && record.WithSupport && record.Date.Month == SelectedMonth
                                               group record by record.LicenseType into groupedOrders
                                               select new KeyValuePair<String, Double>(
                                                   groupedOrders.First().LicenseType,
                                                   groupedOrders.Count()));

                return licensesSoldWithSupport;
            }
            set
            {
                NotifyPropertyChanged("LicensesSoldWithSupport");
            }
        }

        /// <summary>
        /// Number of new licenses sold day wise
        /// </summary>
        public IEnumerable NewLicensesSold
        {
            get
            {
                var newLicensesSold = (from record in _orders
                                       where record.Product == SelectedProduct && record.NewLicense && record.Date.Month == SelectedMonth
                                       orderby record.Date
                                       group record by record.Date into groupedOrders
                                       select new KeyValuePair<DateTime, Double>(groupedOrders.First().Date, groupedOrders.Count())).ToList();

                return newLicensesSold;
            }
            set
            {
                NotifyPropertyChanged("NewLicensesSold");
            }
        }

        /// <summary>
        /// Number of upgrade sold day wise
        /// </summary>
        public IEnumerable OldLicensesUpgraded
        {
            get
            {
                var oldLicensesUpgraded = (from record in _orders
                                           where record.Product == SelectedProduct && !record.NewLicense && record.Date.Month == SelectedMonth
                                           orderby record.Date
                                           group record by record.Date into groupedOrders
                                           select new KeyValuePair<DateTime, Double>(
                                               groupedOrders.First().Date,
                                               groupedOrders.Count())).ToList();

                return oldLicensesUpgraded;
            }
            set
            {
                NotifyPropertyChanged("OldLicensesUpgraded");
            }
        }

        /// <summary>
        /// Conversion ratio
        /// </summary>
        public IEnumerable ConversionRatio
        {
            get
            {
                if (SelectedProduct == null)
                    return null;

                var conversionRatioOfAProduct = (from record in _salesConversions
                                                 where record.Product == SelectedProduct
                                                 where record.Date.Month == SelectedMonth
                                                 group record by record.Product into groupedSalesConversions
                                                 select new
                                                 {
                                                     Downloads = groupedSalesConversions.Sum(a => a.Downloads),
                                                     ValidLeads = groupedSalesConversions.Sum(a => a.ValidLeads),
                                                     LeadsReached = groupedSalesConversions.Sum(a => a.LeadsReached),
                                                     QualifiedLeads = groupedSalesConversions.Sum(a => a.QualifiedLeads),
                                                     Conversion = groupedSalesConversions.Sum(a => a.Conversion)
                                                 }
                                          ).First();

                List<KeyValuePair<String, Double>> _conversionRatio = new List<KeyValuePair<string, double>>();

                _conversionRatio.Add(new KeyValuePair<String, Double>("      Leads with\nphone number", conversionRatioOfAProduct.Downloads));
                _conversionRatio.Add(new KeyValuePair<String, Double>("Leads with valid\nphone number", conversionRatioOfAProduct.ValidLeads));
                _conversionRatio.Add(new KeyValuePair<String, Double>("Leads reached", conversionRatioOfAProduct.LeadsReached));
                _conversionRatio.Add(new KeyValuePair<String, Double>("Qualified leads", conversionRatioOfAProduct.QualifiedLeads));
                _conversionRatio.Add(new KeyValuePair<String, Double>("Conversion", conversionRatioOfAProduct.Conversion));

                return _conversionRatio;
            }
            set
            {
                NotifyPropertyChanged("ConversionRatio");
            }
        }


        /// <summary>
        /// Product wise monthly revenue
        /// </summary>
        public IEnumerable ProductWiseRevenue
        {
            get
            {
                var productWiseRevenue = (from order in _orders
                                          where order.Date.Month == SelectedMonth
                                          group order by order.Product into groupedOrder
                                          select new ProductWiseRevenueInfo()
                                          {
                                              Product = groupedOrder.First().Product,
                                              Amount = groupedOrder.Sum(a => a.Amount),
                                              Exploded = false
                                          }).ToList();

                if (_isFirstTimeLoadOfProductWiseRevenue)
                {
                    productWiseRevenue[0].Exploded = true;
                    _isFirstTimeLoadOfProductWiseRevenue = false;
                }
                else
                {
                    var product = (from prod in productWiseRevenue where prod.Product == SelectedProduct select prod).First();
                    product.Exploded = true;
                }

                return productWiseRevenue;
            }
            set
            {
                NotifyPropertyChanged("ProductWiseRevenue");
            }
        }

        /// <summary>
        /// Revenue in percentage of the select product
        /// </summary>
        public Double RevenueInPercentageOfSelectProduct
        {
            get
            {
                return (RevenueOfSelectProduct / TotalRevenueOfAllProduct) * 100;
            }
            set
            {
                NotifyPropertyChanged("RevenueInPercentageOfSelectProduct");
            }
        }

        /// <summary>
        /// Revenue of select product
        /// </summary>
        public Double RevenueOfSelectProduct
        {
            get
            {
                var _revenueOfSelectProduct = (from order in _orders
                                               where order.Product == SelectedProduct && order.Date.Year == 2010
                                               select order.Amount).Sum();

                return _revenueOfSelectProduct;
            }
            set
            {
                NotifyPropertyChanged("RevenueOfSelectProduct");
            }
        }

        /// <summary>
        /// Total revenue of all product
        /// </summary>
        public Double TotalRevenueOfAllProduct
        {
            get
            {
                var _totalRevenueOfAllProduct = (from order in _orders
                                                 where order.Date.Year == 2010
                                                 select order.Amount).Sum();

                Interval4RevenueScale = _totalRevenueOfAllProduct / 15;
                return _totalRevenueOfAllProduct;
            }
            set
            {
                NotifyPropertyChanged("TotalRevenueOfSelectProduct");
            }
        }

        /// <summary>
        /// Max revenue scale
        /// </summary>
        public Double MaxRevenueScale
        {
            get
            {
                return 20000000;
            }
            set
            {
                NotifyPropertyChanged("MaxRevenueScale");
            }
        }

        /// <summary>
        /// Interval of Revenue Scale (Linear Gauge)
        /// </summary>
        public Double Interval4RevenueScale
        {
            get
            {
                return _interval4RevenueScale;
            }
            set
            {
                _interval4RevenueScale = value;
                NotifyPropertyChanged("Interval4RevenueScale");
            }
        }

        /// <summary>
        /// The selected product
        /// </summary>
        public String SelectedProduct
        {
            get
            {
                return (String)_selectedProduct;
            }
            set
            {
                _selectedProduct = value;
                NotifyPropertyChanged("SelectedProduct");
                OnSelectedProductChanged(_selectedProduct);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// On change of month selected
        /// </summary>
        /// <param name="selectedMonth">Selected Month</param>
        private void OnSelectedMonthChanged(Int32 selectedMonth)
        {
            NotifyPropertyChanged("ProductWiseRevenue");
            OnSelectedProductChanged(SelectedProduct);
        }

        /// <summary>
        /// On change of selected product
        /// </summary>
        /// <param name="productName">Name of the product</param>
        private void OnSelectedProductChanged(String productName)
        {
            NotifyPropertyChanged("ConversionRatio");
            NotifyPropertyChanged("ConversionRatioChartTitle");
            NotifyPropertyChanged("LicensesSoldChartTitle");
            NotifyPropertyChanged("ChartUpgradeOrNewTitle");
            NotifyPropertyChanged("GaugeTitle");

            if (productName ==  ProductAndSales.Models.SampleDataStore.PRODUCT_A)
                ConversionRatioChartColorSet = "VisiBlue";
            else if (productName == ProductAndSales.Models.SampleDataStore.PRODUCT_B)
                ConversionRatioChartColorSet = "VisiOrange";
            else if (productName == ProductAndSales.Models.SampleDataStore.PRODUCT_C)
                ConversionRatioChartColorSet = "VisiRed";
            
            NotifyPropertyChanged("LicensesSoldWithSupport");
            NotifyPropertyChanged("LicensesSoldWithoutSupport");

            NotifyPropertyChanged("OldLicensesUpgraded");
            NotifyPropertyChanged("NewLicensesSold");

            NotifyPropertyChanged("TotalRevenueYearly");
            NotifyPropertyChanged("RevenueInPercentageOfSelectProduct");
            NotifyPropertyChanged("RevenueOfSelectProduct");
            NotifyPropertyChanged("TotalRevenueOfSelectProduct");
        }

        #endregion

        #region Data

        List<ProductAndSales.BusinessObjects.Order> _orders = new List<BusinessObjects.Order>();
        List<ProductAndSales.BusinessObjects.SalesConversion> _salesConversions = new List<BusinessObjects.SalesConversion>();

        DateTime _fromDate;
        String _selectedProduct;
        String _conversionRatioChartColorSet ="VisiBlue";
        Int32 _drpMonthSelectedIndex = 0;
        Boolean _isFirstTimeLoadOfProductWiseRevenue = true;
        Double _interval4RevenueScale = Double.NaN;
        
        #endregion
    }
}
