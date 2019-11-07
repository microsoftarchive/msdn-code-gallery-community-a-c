using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ShipperClient
{
    /// <summary>
    /// Interaction logic for HRD.xaml
    /// </summary>
    public partial class HRD : Window
    {
        public HRD()
        {
            InitializeComponent();
        }

        internal void AddButtons(List<Button> buttons)
        {
            double buttonWidth = 250;
            double buttonHeight = 50;

            double top = 60;
            double bottom = this.Height - top - 2*buttonHeight;            
            double left = (this.Width - buttonWidth) / 2;
            double right = left;

            foreach (Button b in buttons)
            {
                b.Width = buttonWidth;
                b.Height = buttonHeight;             
              
                b.Margin = new Thickness(left , top, right, bottom);

                top += b.Height;
                bottom -= b.Height;
               
                this.Grid.Children.Add(b);                
            }
        }
    }
}
