using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFwebApi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HttpClient client = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
            List<string> genderList = new List<string>();
            genderList.Add("Male");
            genderList.Add("Female");
            cbxGender.ItemsSource = genderList;

            client.BaseAddress = new Uri("http://localhost:60792");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            this.Loaded += MainWindow_Loaded;
        }

        async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            HttpResponseMessage response = await client.GetAsync("/api/student");
            response.EnsureSuccessStatusCode(); // Throw on error code.
            var students = await response.Content.ReadAsAsync<IEnumerable<Student>>();
            studentsListView.ItemsSource = students;
        }

        private async void btnGetStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync("/api/student/" + txtID.Text);
                response.EnsureSuccessStatusCode(); // Throw on error code.
                var students = await response.Content.ReadAsAsync<Student>();
                studentDetailsPanel.Visibility = Visibility.Visible;
                studentDetailsPanel.DataContext = students;
            }
            catch(Exception)
            {
                MessageBox.Show("Student not Found");
            }
        }

        private async void btnNewStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var student = new Student()
                {
                    name = txtStudentName.Text,
                    id = int.Parse(txtStudentID.Text),
                    gender = cbxGender.SelectedItem.ToString(),
                    age = int.Parse(txtAge.Text)
                };
                var response = await client.PostAsJsonAsync("/api/student/", student);
                response.EnsureSuccessStatusCode(); // Throw on error code.
                MessageBox.Show("Student Added Successfully", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
                studentsListView.ItemsSource = await GetAllStudents();
                studentsListView.ScrollIntoView(studentsListView.ItemContainerGenerator.Items[studentsListView.Items.Count - 1]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Student not Added, May be due to Duplicate ID");
            }
        }

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var student = new Student()
                {
                    name = txtStudentName.Text,
                    id = int.Parse(txtStudentID.Text),
                    gender = cbxGender.SelectedItem.ToString(),
                    age = int.Parse(txtAge.Text)
                };
                var response = await client.PutAsJsonAsync("/api/student/", student);
                response.EnsureSuccessStatusCode(); // Throw on error code.
                MessageBox.Show("Student Added Successfully", "Result", MessageBoxButton.OK, MessageBoxImage.Information);
                studentsListView.ItemsSource = await GetAllStudents();
                studentsListView.ScrollIntoView(studentsListView.ItemContainerGenerator.Items[studentsListView.Items.Count - 1]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnDeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HttpResponseMessage response = await client.DeleteAsync("/api/student/" + txtID.Text);
                response.EnsureSuccessStatusCode(); // Throw on error code.
                MessageBox.Show("Student Successfully Deleted");
                studentsListView.ItemsSource = await GetAllStudents();
                studentsListView.ScrollIntoView(studentsListView.ItemContainerGenerator.Items[studentsListView.Items.Count - 1]);
            }
            catch (Exception)
            {
                MessageBox.Show("Student Deletion Unsuccessful");
            }
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            HttpResponseMessage response = await client.GetAsync("/api/student");
            response.EnsureSuccessStatusCode(); // Throw on error code.
            var students = await response.Content.ReadAsAsync<IEnumerable<Student>>();
            return students;
        }
    }

    public class Student
    {
        public string name { get; set; }
        public int id { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
    }
}
