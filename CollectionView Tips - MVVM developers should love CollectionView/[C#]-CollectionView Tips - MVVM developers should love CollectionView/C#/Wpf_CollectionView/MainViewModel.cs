using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows;
using System.Diagnostics;
using System.Windows.Data;
using System.ComponentModel;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Command;
using Support;
using System.Media;
using System.Reflection;
using System.Xml.Linq;
using System.Windows.Media.Animation;

namespace Wpf_CollectionView
{
    public class MainViewModel : NotifyUIBase
    {

        public CollectionView LevelsPeopleView { get; set; }
        private Person currentLevel;
        public Person CurrentLevel
        {
            get { return currentLevel; }
            set 
            {
                currentLevel = value;
                CurrentPerson = value;
                RaisePropertyChanged();
            }

        }
        private Person CurrentPerson
        {
            get { return PeopleView.CurrentItem as Person; }
            set 
            { 
                PeopleView.MoveCurrentTo(value);
                RaisePropertyChanged();
            
            }
        }
        public ObservableCollection<Person> People { get; set; }
        public CollectionView PeopleView {get; set;}
        public MainViewModel()
        {
            List<Person> ppl = new List<Person>();
            var xml = XDocument.Load(@"Data\People.xml");
            var pp = xml.Descendants("People");

            foreach (XElement p in pp)
            {
                ppl.Add(new Person
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
                });

            }

            People = new ObservableCollection<Person>(
                         ppl.OrderBy(x=>x.OrganizationLevel)
                         .ThenBy(x=>x.LastName).ThenBy(x=>x.FirstName).Select(x=>x).ToList());

            PeopleView = (CollectionView)new CollectionViewSource { Source = People }.View;
            LevelsPeopleView = (CollectionView)new CollectionViewSource { Source = People }.View;
            LevelsPeopleView.Filter = FirstOfLevel_Filter;

            Person _person = ppl[121];
            // An alternative would be to bind a property to SelectedItem and set that.
            CurrentPerson = _person;  

            RaisePropertyChanged("PeopleView");
            RaisePropertyChanged("LevelsPeopleView");

            Person cp = CurrentPerson;


        }
        private int LastLevel = -1;
        private bool FirstOfLevel_Filter(object item)
        {
            Person p = item as Person;
            if (p != null)
            {
                if (p.OrganizationLevel == LastLevel)
                {
                   return false;
                }
                LastLevel = p.OrganizationLevel;
                return true;
            }
            return false;
        }

    }

}
