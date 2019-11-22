using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace CustomControls
{
    public sealed partial class ProfileDesign : UserControl
    {
        public ProfileDesign()
        {
            this.InitializeComponent();
        }



        public Brush OverlayBrush
        {
            get { return (Brush)GetValue(OverlayBrushProperty); }
            set { SetValue(OverlayBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OverlayBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OverlayBrushProperty =
            DependencyProperty.Register("OverlayBrush", typeof(Brush), typeof(ProfileDesign),null  );



        public ImageSource ProfileImage
        {
            get { return (ImageSource)GetValue(ProfileImageProperty); }
            set { SetValue(ProfileImageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProfileImage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProfileImageProperty =
            DependencyProperty.Register("ProfileImage", typeof(ImageSource), typeof(ProfileDesign), null );



        public string StudentName
        {
            get { return (string)GetValue(StudentNameProperty); }
            set { SetValue(StudentNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StudentName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StudentNameProperty =
            DependencyProperty.Register("StudentName", typeof(string), typeof(ProfileDesign), null);




        public string StudentAge
        {
            get { return (string)GetValue(StudentAgeProperty); }
            set { SetValue(StudentAgeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StudentAge.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StudentAgeProperty =
            DependencyProperty.Register("StudentAge", typeof(string), typeof(ProfileDesign), null);


    }
}
