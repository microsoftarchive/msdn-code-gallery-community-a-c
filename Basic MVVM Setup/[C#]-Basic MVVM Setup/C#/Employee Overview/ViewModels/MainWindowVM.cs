using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Employee_Overview.Classes;
using System.Collections.ObjectModel;

namespace Employee_Overview.ViewModels
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public MainWindowVM()
        {
            Employees = GetEmployeeList();
        }

        ObservableCollection<Employee> GetEmployeeList()
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>();

            employees.Add(new Employee { MemberID = 1, Name = "John Hancock", Department = "IT", Phone = "31234743", Email = @"John.Hancock@Company.com", Salary = "3450.44" });
            employees.Add(new Employee { MemberID = 2, Name = "Jane Hayes", Department = "Sales", Phone = "31234744", Email = @"Jane.Hayes@Company.com", Salary = "3700" });
            employees.Add(new Employee { MemberID = 3, Name = "Larry Jones", Department = "Marketing", Phone = "31234745", Email = @"Larry.Jones@Company.com", Salary = "3000" });
            employees.Add(new Employee { MemberID = 4, Name = "Patricia Palce", Department = "Secretary", Phone = "31234746", Email = @"Patricia.Palce@Company.com", Salary = "2900" });
            employees.Add(new Employee { MemberID = 5, Name = "Jean L. Trickard", Department = "Director", Phone = "31234747", Email = @"Jean.L.Tricard@Company.com", Salary = "5400" });

            //In case a class needs to be instantiated, this would be a better approach for adding an entry.
            Employee employee = new Employee() 
            {
                MemberID = 6,
                Name = "Jane Doe",
                Department = "Banking",
                Phone = "31234748",
                Email = "Jane.Doe@Company.Com",
                Salary = "3350"
            };
            employees.Add(employee);

            return employees;
        }

        private ObservableCollection<Employee> _employees;
        public ObservableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                RaiseChange("Employees");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaiseChange(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
