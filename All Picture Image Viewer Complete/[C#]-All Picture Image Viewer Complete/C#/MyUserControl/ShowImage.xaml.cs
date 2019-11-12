using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyUserControl
{
    /// <summary>
    /// Interaction logic for ShowImage.xaml
    /// </summary>
    public partial class ShowImage : UserControl
    {
        public ShowImage()
        {
            InitializeComponent();
            
        }

        private ImgWrapper image = new ImgWrapper();
        private Img img = new Img();         
        private void canvasMain_Drop(object sender, DragEventArgs e)
        {
            var data = e.Data;
            string[] files = (string[])data.GetData(DataFormats.FileDrop);

            if (files.GetLength(0) == 1)
            {
                lblDrop.Content = "";
                try
                {
                    image = img.Load(files[0]);
                    ImageBrush br = new ImageBrush(image.BitmapImage);
                    if (chkUniformToFill != null)
                    {
                        if (chkUniformToFill.IsChecked == true)
                        {
                            br.Stretch = Stretch.UniformToFill;
                        }
                        else
                        {
                            br.Stretch = Stretch.Fill;
                        }

                        canvasMain.Background = (Brush)br;
                    }

                }
                catch
                {
                    lblDrop.Content = "IT IS NOT AN IMAGE";
                }
            } else
            {
                lblDrop.Content = "PLESE DROP ONLY ONE FILE";
            }

        }

        private void chkUniformToFill_Click(object sender, RoutedEventArgs e)
        {
            if (image.BitmapImage == null)
            { }
            else
            {
                ImageBrush br = new ImageBrush(image.BitmapImage);
                if (chkUniformToFill.IsChecked == true)
                {
                    br.Stretch = Stretch.UniformToFill;
                }
                else
                {
                    br.Stretch = Stretch.Fill;
                }
                canvasMain.Background = (Brush)br;
            }
        }
    }
}
