using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlsToPdf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UIElement UiElement = null;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = StudentViewModel.SharedViewModel();
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var controls = Utilities.GetLogicalChildren<UIElement>(this).ToList();
            CbxUIElements.ItemsSource = controls.Select(x => x.GetValue(NameProperty));
        }

        private void CbxUIElements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems.Count > 0)
            {
                var previousControl = this.FindName(e.RemovedItems[0].ToString()) as DependencyObject;
                var previousAdornerLayer = AdornerLayer.GetAdornerLayer(previousControl as UIElement);
                if (previousAdornerLayer != null)
                {
                    var adorners = previousAdornerLayer.GetAdorners(previousControl as UIElement);
                    foreach (var adorner in adorners)
                    {
                        previousAdornerLayer.Remove(adorner);
                    }
                }
            }
            var control = this.FindName(CbxUIElements.SelectedItem.ToString()) as DependencyObject;
            UiElement = control as UIElement;
            var adornerLayer = AdornerLayer.GetAdornerLayer(control as UIElement);
            if (adornerLayer != null)
            {
                adornerLayer.Add(new SimpleAdorner(control as UIElement));
                adornerLayer.IsHitTestVisible = false;
            }
        }

        private void BtnCapture_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Png files (*.png)|*.png|Bmp Files (*.bmp)|*.bmp";
            var result = saveFileDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (saveFileDialog.DefaultExt == ".bmp")
                {
                    ImageCapturer.SaveToBmp((UiElement as FrameworkElement), saveFileDialog.FileName);
                }
                else
                {
                    ImageCapturer.SaveToPng((UiElement as FrameworkElement), saveFileDialog.FileName);
                }
            }
        }
    }

    #region Adorners

    public class SimpleAdorner : Adorner
    {
        public SimpleAdorner(UIElement adornedElement)
            : base(adornedElement)
        {
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            Rect adornedElementRect = new Rect(this.AdornedElement.DesiredSize);
            SolidColorBrush renderBrush = new SolidColorBrush(Colors.Transparent);
            renderBrush.Opacity = 0.2;
            Pen renderPen = new Pen(new SolidColorBrush(Colors.Navy), 2);
            drawingContext.DrawRectangle(renderBrush, renderPen, adornedElementRect);
        }
    }

    #endregion

    #region Capture Utilities

    public static class ImageCapturer
    {
        public static void SaveToBmp(FrameworkElement visual, string fileName)
        {
            var bitmapEncoder = new BmpBitmapEncoder();
            SaveUsingEncoder(visual, fileName, bitmapEncoder);
        }

        public static void SaveToPng(FrameworkElement visual, string fileName)
        {
            var pngBitmapEncoder = new PngBitmapEncoder();
            SaveUsingEncoder(visual, fileName, pngBitmapEncoder);
        }

        private static void SaveUsingEncoder(FrameworkElement visual, string fileName, BitmapEncoder encoder)
        {
            var renderTargetBitmap = new RenderTargetBitmap((int)visual.ActualWidth, (int)visual.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            renderTargetBitmap.Render(visual);
            var bitmapFrame = BitmapFrame.Create(renderTargetBitmap);
            encoder.Frames.Add(bitmapFrame);
            using (var fileStream = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                encoder.Save(fileStream);
            }
        }
    }

    #endregion

    #region Logical Tree Extensions

    public static class Utilities
    {
        public static IEnumerable<DependencyObject> GetLogicalChildren<T>(DependencyObject depObj)
        {
            if (depObj != null)
            {
                foreach (object obj in LogicalTreeHelper.GetChildren(depObj))
                {
                    var dependencyObject = obj as DependencyObject;

                    if (dependencyObject != null && dependencyObject is T)
                    {
                        yield return dependencyObject;
                    }

                    foreach (var childOfChild in GetLogicalChildren<T>(dependencyObject))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        public static T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            if (parent == null)
                return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                T childType = child as T;
                if (childType == null)
                {
                    foundChild = FindChild<T>(child, childName);
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }
    }

    #endregion

    #region ViewModel

    public class StudentViewModel : INotifyPropertyChanged
    {
        public static StudentViewModel _studentViewModel;

        private List<Student> students;
        public List<Student> Students
        {
            get { return students; }
            set
            {
                students = value;
                OnPropertyChanged("Students");
            }
        }

        private Student selectedStudent;
        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                OnPropertyChanged("SelectedStudent");
            }
        }

        private StudentViewModel()
        {
            Students = new List<Student>();
            Students.Add(new Student { Name = "John", Id = 1, Gender = "Male" });
            Students.Add(new Student { Name = "Willam", Id = 2, Gender = "Male" });
            Students.Add(new Student { Name = "Sara", Id = 3, Gender = "Female" });
            Students.Add(new Student { Name = "Matthew", Id = 4, Gender = "Male" });
            Students.Add(new Student { Name = "Cinderlla", Id = 5, Gender = "Female" });
            Students.Add(new Student { Name = "Gaurav", Id = 6, Gender = "Male" });
            Students.Add(new Student { Name = "Nancy", Id = 7, Gender = "Female" });
            OnPropertyChanged("Students");
        }

        public static StudentViewModel SharedViewModel()
        {
            return _studentViewModel ?? (_studentViewModel = new StudentViewModel());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null) this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    #endregion

    #region Model

    public class Student : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string name;
        private int id;
        private string gender;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if (handler != null) this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    #endregion

}
