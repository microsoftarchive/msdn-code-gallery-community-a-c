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
using System.Collections.Generic;
using Visifire.Dashboards.ProductAndSales.BusinessObjects;
using System.Linq;

namespace Visifire.Dashboards.ProductAndSales.Models
{   
    /// <summary>
    /// Generates random data
    /// </summary>
    public static class SampleDataStore
    {
        #region Public Methods

        /// <summary>
        /// Get Random data for orders
        /// </summary>
        /// <returns>List<Order>Orders</returns>
        public static List<ProductAndSales.BusinessObjects.Order> GetSampleOrders()
        {   
            List<Order> orders = new List<Order>();

            orders.AddRange(GenerateRandomOders(PRODUCT_A, SINGLE_USER, new DateTime(2010, 1, 1), new DateTime(2010, 12, 30), 23));
            orders.AddRange(GenerateRandomOders(PRODUCT_A, TEAMLICENSE_USER, new DateTime(2010, 1, 1), new DateTime(2010, 12, 30), 23));
            orders.AddRange(GenerateRandomOders(PRODUCT_A, UNLIMITED_USERS, new DateTime(2010, 1, 1), new DateTime(2010, 12, 30), 23));

            orders.AddRange(GenerateRandomOders(PRODUCT_A, SINGLE_USER, new DateTime(2010, 1, 1), new DateTime(2010, 12, 30), 23));
            orders.AddRange(GenerateRandomOders(PRODUCT_A, TEAMLICENSE_USER, new DateTime(2010, 1, 1), new DateTime(2010, 12, 30), 23));
            orders.AddRange(GenerateRandomOders(PRODUCT_A, TEAMLICENSE_USER, new DateTime(2010, 1, 1), new DateTime(2010, 12, 30), 23));

            orders.AddRange(GenerateRandomOders(PRODUCT_A, TEAMLICENSE_USER, new DateTime(2010, 1, 1), new DateTime(2010, 12, 30), 23));
            orders.AddRange(GenerateRandomOders(PRODUCT_A, UNLIMITED_USERS, new DateTime(2010, 1, 1), new DateTime(2010, 12, 30), 23));
            orders.AddRange(GenerateRandomOders(PRODUCT_A, UNLIMITED_USERS, new DateTime(2010, 1, 1), new DateTime(2010, 12, 30), 23));

            orders.AddRange(GenerateRandomOders(PRODUCT_B, SINGLE_USER, new DateTime(2010, 1, 1), new DateTime(2010, 12, 30), 23));
            orders.AddRange(GenerateRandomOders(PRODUCT_B, TEAMLICENSE_USER, new DateTime(2010, 1, 1), new DateTime(2010, 12, 30), 23));
            orders.AddRange(GenerateRandomOders(PRODUCT_B, UNLIMITED_USERS, new DateTime(2010, 1, 1), new DateTime(2010, 12, 30), 23));

            orders.AddRange(GenerateRandomOders(PRODUCT_B, SINGLE_USER, new DateTime(2010, 1, 1), new DateTime(2010, 12, 30), 23));
            orders.AddRange(GenerateRandomOders(PRODUCT_B, TEAMLICENSE_USER, new DateTime(2010, 1, 1), new DateTime(2010, 12, 30), 23));
            orders.AddRange(GenerateRandomOders(PRODUCT_B, TEAMLICENSE_USER, new DateTime(2010, 1, 1), new DateTime(2010, 12, 30), 23));
            
            orders.AddRange(GenerateRandomOders(PRODUCT_C, SINGLE_USER, new DateTime(2010, 1, 1), new DateTime(2010, 12, 30), 23));
            orders.AddRange(GenerateRandomOders(PRODUCT_C, TEAMLICENSE_USER, new DateTime(2010, 1, 1), new DateTime(2010, 5, 30), 23));
            orders.AddRange(GenerateRandomOders(PRODUCT_C, TEAMLICENSE_USER, new DateTime(2010, 5, 1), new DateTime(2010, 12, 30), 23));
            orders.AddRange(GenerateRandomOders(PRODUCT_C, UNLIMITED_USERS, new DateTime(2010, 3, 1), new DateTime(2010, 12, 30), 23));

            return orders;
        }

        /// <summary>
        /// Get sample data for sales conversions
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public static List<ProductAndSales.BusinessObjects.SalesConversion> GetSampleSalesConversions(List<Order> orders)
        {
            List<SalesConversion> salesConversions = new List<SalesConversion>();

            List<SalesConversion> sc1 = GenerateRandomConversionRation(orders, PRODUCT_A, new DateTime(2010, 1, 1), new DateTime(2010, 12, 30));
            salesConversions.AddRange(sc1);

            List<SalesConversion> sc2 = GenerateRandomConversionRation(orders, PRODUCT_B, new DateTime(2010, 1, 1), new DateTime(2010, 12, 30));
            salesConversions.AddRange(sc2);

            List<SalesConversion> sc3 = GenerateRandomConversionRation(orders, PRODUCT_C, new DateTime(2010, 1, 1), new DateTime(2010, 12, 30));
            salesConversions.AddRange(sc3);

            return salesConversions;
        }

        #endregion

        #region Private Methods

        private static List<SalesConversion> GenerateRandomConversionRation(List<Order> orders, String productName, DateTime fromDate, DateTime toDate)
        {
            
            List<SalesConversion> salesConversions = new List<SalesConversion>();
            Double randVal;

            Int32 sold = 0;
            Random rand = new Random(DateTime.Now.Millisecond);

            while (fromDate < toDate)
            {
                sold = (from x in orders where x.Product == productName && x.Date.Month == fromDate.Month select x).Count();

                randVal = rand.NextDouble();
                Int32 p1 = (Int32)(sold * (1 + randVal < 1.4 ? 1.6 : 1.9));

                randVal = rand.NextDouble();
                Int32 p2 = (Int32)(p1 * (1 + randVal < 1.4 ? 1.6 : 1.9));

                randVal = rand.NextDouble();
                Int32 p3 = (Int32)(p2 * (1 + randVal < 1.4 ? 1.6 : 1.9));

                randVal = rand.NextDouble();
                Int32 p4 = (Int32)(p3 * (1 + randVal < 1.4 ? 1.6 : 1.9));

                salesConversions.Add(new SalesConversion(fromDate, productName, p4, p3, p2, p1, sold));

                fromDate = fromDate.AddMonths(1);
            }
            
            return salesConversions;
        }

        private static List<Order> GenerateRandomOders(String productName,String license, DateTime fromDate, DateTime toDate, Int32 totalTargetSold)
        {   
            Random rand = new Random(DateTime.Now.Millisecond);
            List<Order> orders = new List<Order>();
            Int32 count = 1;

            try
            {   
                while (fromDate <= toDate)
                {   
                    Int32 luckyNumber = rand.Next(10, 100* count);

                    Int32 numberOfLicenseSoldToday = (Int32)(luckyNumber * 0.123 * rand.NextDouble() * rand.NextDouble());
                    Int32 index = numberOfLicenseSoldToday;

                    while (index >= 0)
                    {
                        Int32 rand1 = rand.Next(1, 300);

                        Boolean isWithSupport = !(rand.Next(1, 5) == 2 || rand.Next(1, 5) == 5);
                        Boolean isNewLicense = rand.Next(index, index + 5) == 3;
                        Double revenue = (license == UNLIMITED_USERS) ? 1999 : (license == TEAMLICENSE_USER) ? 999 : 499;

                        orders.Add(new Order(fromDate, productName, license, isWithSupport, isNewLicense, revenue));

                        index--;
                    }

                    fromDate = fromDate.AddDays(1);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return orders;
        }

        #endregion

        #region Data

        static String SINGLE_USER = "Single User";
        static String TEAMLICENSE_USER = "Team License\n(5 Users)";
        static String UNLIMITED_USERS = "Unlimited Users";

        public static String PRODUCT_A = "ProductA";
        public static String PRODUCT_B = "ProductB";
        public static String PRODUCT_C = "ProductC";

        #endregion
    }
}