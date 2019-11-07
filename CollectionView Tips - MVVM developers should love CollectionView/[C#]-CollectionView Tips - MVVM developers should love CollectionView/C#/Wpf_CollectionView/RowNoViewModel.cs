using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Support;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Xml.Linq;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
namespace Wpf_CollectionView
{
    class RowNoViewModel : NotifyUIBase
    {

        public CollectionView PeopleView { get; set; }
        public RelayCommand<string> InsertPerson { get; set; }

        public ObservableCollection<PersonVM> People { get; set; }
        public RowNoViewModel()
        {
            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                GetData();
            }
            InsertPerson = new RelayCommand<string>(ExecuteInsertPerson);
            Messenger.Default.Register<RefreshView>(this, (action) => RefreshView());
        }

        private void ExecuteInsertPerson(string obj)
        {
            People.Add(new PersonVM
            {
                CV = PeopleView,
                ThePerson = new Person
                    {
                        BirthDate = DateTime.Parse("1990-01-01"),
                        FirstName = "Aalbert",
                        Gender = "M",
                        HireDate = DateTime.Parse("2000-01-01"),
                        JobTitle = "Ant Eater",
                        LastName = "Aardvark",
                        LoginId = "aaa",
                        MiddleName = " ",
                        OrganizationLevel = 1,
                    }
            });

        }
        private object RefreshView()
        {
            PeopleView.Refresh();
            RaisePropertyChanged("PeopleView");
            return null;
        }
        private void GetData()
        {
            List<PersonVM> ppl = new List<PersonVM>();
            var xml = XDocument.Load(@"Data\People.xml");
            var pp = xml.Descendants("People");

            foreach (XElement p in pp)
            {
                ppl.Add(new PersonVM { ThePerson = new Person
                {
                    BirthDate = DateTime.Parse(p.Element("BirthDate").Value),
                    FirstName = p.Element("FirstName").Value.ToString() ?? string.Empty,
                    Gender = p.Element("Gender").Value.ToString() ?? string.Empty,
                    HireDate = DateTime.Parse(p.Element("HireDate").Value),
                    JobTitle = p.Element("JobTitle").Value.ToString() ?? string.Empty,
                    LastName = p.Element("LastName").Value.ToString() ?? string.Empty,
                    LoginId = p.Element("LoginId").Value.ToString() ?? string.Empty,
                    MiddleName = p.Element("MiddleName") == null ? string.Empty : p.Element("MiddleName").Value.ToString(),
                    OrganizationLevel = int.Parse(p.Element("OrganizationLevel").Value),
                }});

            }

            People = new ObservableCollection<PersonVM>(
                         ppl.OrderBy(x => x.ThePerson.OrganizationLevel)
                         .ThenBy(x => x.ThePerson.LastName).ThenBy(x => x.ThePerson.FirstName).Select(x => x).ToList());

            PeopleView = (CollectionView)new CollectionViewSource { Source = People }.View;
            ppl.ForEach(p =>p.CV = PeopleView);
            CVHolder.CV = PeopleView;
            RaisePropertyChanged("PeopleView");

            People.CollectionChanged += People_CollectionChanged;
        }

        void People_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RefreshView();
        }
    }
}
