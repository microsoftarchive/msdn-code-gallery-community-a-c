using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace TipCalculator
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor

        int tipPercentage;

        int splitAmong;

        double toTip;

        double total, baseTab;

        double mySplit;

        public MainPage()
        {
            InitializeComponent();

            tipPercentage = 15;

            slider1.Value = tipPercentage;

            txtTipP.Text = tipPercentage.ToString() + "%";

            splitAmong = 1;

            txtHowMany.Text = splitAmong.ToString();

        }

        private void doCalcs()
        {

            try
            {

                baseTab = double.Parse(txtTab.Text);

                toTip = tipPercentage / 100.0 * baseTab;

                txtTip.Text = toTip.ToString("$###,##0.00");

                total = baseTab + toTip;

                txtTotal.Text = total.ToString("$###,##0.00");

                mySplit = total / splitAmong;

                txtSplit.Text = mySplit.ToString("$###,##0.00");

            }

            catch { }

        }

        private void Calculate(object sender, GestureEventArgs e)
        {

            doCalcs();

        }

        private void TipPer(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            try
            {

                tipPercentage = (Int16)slider1.Value;

                txtTipP.Text = tipPercentage.ToString() + "%";

                doCalcs();

            }

            catch { }

        }

        private void DownSplit_Tap(object sender, GestureEventArgs e)
        {

            if (splitAmong > 1)

                splitAmong = splitAmong - 1;

            txtHowMany.Text = splitAmong.ToString();

            doCalcs();

        }

        private void UpSplit_Tap(object sender, GestureEventArgs e)
        {

            splitAmong = splitAmong + 1;

            txtHowMany.Text = splitAmong.ToString();
            doCalcs();






        }

        private void image2_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
    }
}