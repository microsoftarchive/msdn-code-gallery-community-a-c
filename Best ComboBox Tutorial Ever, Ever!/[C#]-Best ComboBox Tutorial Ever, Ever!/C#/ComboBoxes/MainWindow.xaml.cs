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
using System.ComponentModel;
using ComboBoxes.Model;
using System.Collections.ObjectModel;

namespace ComboBoxes
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        #region ComboBox List<String> Example

        public List<string> MyStringOptions { get; set; }

        string _SelectedOption1;
        public string SelectedOption1
        {
            get
            {
                return _SelectedOption1;
            }
            set
            {
                if (_SelectedOption1 != value)
                {
                    _SelectedOption1 = value;
                    RaisePropertyChanged("SelectedOption1");
                }
            }
        } 

        #endregion

        #region ComboBox List<Class> Example

        public List<MyClass> MyClassOptions { get; set; }

        MyClass _SelectedClass;
        public MyClass SelectedClass
        {
            get
            {
                return _SelectedClass;
            }
            set
            {
                if (_SelectedClass != value)
                {
                    _SelectedClass = value;
                    RaisePropertyChanged("SelectedClass");
                }
            }
        }

        int _SelectedAge;
        public int SelectedAge
        {
            get
            {
                return _SelectedAge;
            }
            set
            {
                if (_SelectedAge != value)
                {
                    _SelectedAge = value;
                    RaisePropertyChanged("SelectedAge");
                }
            }
        }


        #endregion

        #region DataGrid List<String> Example

        public ObservableCollection<MyCar> MyCars { get; set; }
        public List<string> PartIds { get; set; } 

        #endregion

        #region DataGrid List<Class> Example

        public List<CarPart> CarParts { get; set; }

        #endregion

        #region Static Xaml Array

        string _SelectedAnimal;
        public string SelectedAnimal
        {
            get
            {
                return _SelectedAnimal;
            }
            set
            {
                if (_SelectedAnimal != value)
                {
                    _SelectedAnimal = value;
                    RaisePropertyChanged("SelectedAnimal");
                }
            }
        }


        #endregion

        //DataGrid List<Class> - DataGridTemplateColumn/DataGridComboBoxColumn - List<String>

        public MainWindow()
        {
            InitializeComponent();

            //Combo List<String>
            MyStringOptions = new List<string> { "Option1", "Option2", "Option3"};

            //Combo List<Class>
            MyClassOptions = new List<MyClass> 
            { 
                new MyClass { Name = "Fred", Age=42 },
                new MyClass { Name = "Jane", Age=21 },
                new MyClass { Name = "Adam", Age=64 },
            };

            //DataGrid List<Class> - DataGridTemplateColumn/DataGridComboBoxColumn - List<String>
            MyCars = new ObservableCollection<MyCar>
            {
                new MyCar { Model="Fiesta", Registration="ABC 1DEF", PartId="HGR34" },
                new MyCar { Model="Capri", Registration="HGR H56L" },
            };
            PartIds = new List<string> { "123DF", "HGR34", "76FGR" };

            //DataGrid List<Class> - DataGridTemplateColumn/DataGridComboBoxColumn - List<Class>
            CarParts = new List<CarPart>
            {
                new CarPart { PartID = "123DF", PartName="Gear" },
                new CarPart { PartID = "HGR34", PartName="Wheel" },
                new CarPart { PartID = "76FGR", PartName="Brake Pad" },
            };

            DataContext = this;
        }

        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
