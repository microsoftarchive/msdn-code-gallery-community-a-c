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
using System.Collections;

namespace Wpf_CollectionView
{
    class DynamicFilteringViewModel : NotifyUIBase
    {
        private string genderChosen;
        public string GenderChosen
        {
            get { return genderChosen; }
            set
            {
                genderChosen = value;
                RaisePropertyChanged();
            }
        }

        private string letterChosen;
        public string LetterChosen
        {
            get { return letterChosen; }
            set
            {
                letterChosen = value;
                RaisePropertyChanged();
            }
        }
        private int yearsChosen;
        public int YearsChosen
        {
            get { return yearsChosen; }
            set
            {
                yearsChosen = value;
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
        public ListCollectionView PeopleView { get; set; }
        public RelayCommand ApplyFilter { get; set; }
        public DynamicFilteringViewModel()
        {
            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                GetData();
            }
            ApplyFilter = new RelayCommand(ExecuteApplyFilter);
        }

        private void ExecuteApplyFilter()
        {
            DateTime _zeroDay = new DateTime(1, 1, 1);
            DateTime _now = DateTime.Now;

            criteria.Clear();

            if (yearsChosen > 0)
            {
                criteria.Add(new Predicate<Person>(x => yearsChosen < (
                    (_zeroDay + (_now - x.BirthDate)).Year - 1)
                                                                    ));
            }

            if (letterChosen != "Any")
            {
                criteria.Add(new Predicate<Person>(x => x.LastName.StartsWith(letterChosen)));
            }
            if (genderChosen != "Any")
            {
                criteria.Add(new Predicate<Person>(x => x.Gender.Equals(genderChosen.Substring(0, 1))));
            }

            PeopleView.Filter = dynamic_Filter;
            RaisePropertyChanged("PeopleView");
            // Bring the current person back into view in case it moved
            if (CurrentPerson != null)
            {
                Person current = CurrentPerson;
                PeopleView.MoveCurrentToFirst();
                PeopleView.MoveCurrentTo(current);
            }
        }
        private void GetData()
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

            People = new ObservableCollection<Person>(ppl.Select(x => x).ToList());

            // Prove observablecollection has no thread affinity
            // Task.Factory.StartNew(() => { People.Add(new Person()); });

            PeopleView = (ListCollectionView)CollectionViewSource.GetDefaultView(People);

            PeopleView.CustomSort = new PersonComparer();
         //   PeopleView.SortDescriptions.Clear();
            //PeopleView.SortDescriptions.Add(new SortDescription("OrganizationLevel", ListSortDirection.Ascending));
            //PeopleView.SortDescriptions.Add(new SortDescription("LastName", ListSortDirection.Ascending));
            //PeopleView.SortDescriptions.Add(new SortDescription("FirstName", ListSortDirection.Ascending));
            RaisePropertyChanged("PeopleView");
        }

        private List<Predicate<Person>> criteria = new List<Predicate<Person>>();

        private bool dynamic_Filter(object item)
        {
            Person p = item as Person;
            bool isIn = true;
            if (criteria.Count() == 0)
                return isIn;
            isIn = criteria.TrueForAll(x => x(p));

            return isIn;
        }


    }
    public class PersonComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Person p1 = x as Person;
            Person p2 = y as Person;
            int result = p1.OrganizationLevel.CompareTo(p2.OrganizationLevel);
            if (result == 0)
            {
                result = p1.LastName.CompareTo(p2.LastName);
            }
            if (result == 0)
            {
                result = p1.FirstName.CompareTo(p2.FirstName);
            }
            return result;
        }
    }
}