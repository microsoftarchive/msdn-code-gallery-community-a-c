# region "Namespaces" 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
//This is the namespace provides a wide variety of members that support COM interop and platform invoke services

# endregion

namespace STUDENTS_MARKS_REPORT
{
# region "Class to get student Details" 
 class CStudentDetails //class for Declarations
       
    {

        public string studentname;

        public int[] studentmarks = new int[5];

        public int totalmarks;

    }

# endregion

   # region "Class that adds record" 
    class CStudents
    {

        public List<CStudentDetails> studList = new List<CStudentDetails>();

        //This list contains the student list

        public int MaxStudents;


 #region "Function that adds record" 
        //This Function Adds the Record
        public int AddRecord(string name, int[] marks)
        {

            CStudentDetails stud = new CStudentDetails();

            stud.studentname = name;

            stud.studentmarks = marks;

            stud.totalmarks = 0;

            for (int i = 0; i < 5; i++)

                stud.totalmarks += stud.studentmarks[i];

            studList.Add(stud);

            MaxStudents = studList.Count;

            return 1;

        }
#endregion

    }



  class Program

 {

 

static public CStudents theStudents = new CStudents();



# region Method to view Records 
      //This method is to view Records as Report

static public void ViewRecords()
{



    Console.WriteLine("_______________________________________________________________");



    Console.WriteLine("SNo Student Name        ENG   MATH   PHY    CHE    BIO     Total");

    Console.WriteLine("_______________________________________________________________");



    for (int i = 0; i < theStudents.MaxStudents; i++)
    {

        Console.Write("{0, -5}", i + 1);

        Console.Write("{0, -19}", theStudents.studList[i].studentname);

        Console.Write("{0, -7}", theStudents.studList[i].studentmarks[0]);

        Console.Write("{0, -7}", theStudents.studList[i].studentmarks[1]);

        Console.Write("{0, -7}", theStudents.studList[i].studentmarks[2]);

        Console.Write("{0, -7}", theStudents.studList[i].studentmarks[3]);

        Console.Write("{0, -7}", theStudents.studList[i].studentmarks[4]);

        Console.Write("{0, -7}", theStudents.studList[i].totalmarks);

        Console.WriteLine();

    }
   
    Console.WriteLine("_______________________________________________________________");

}
#endregion

static public void InputRecords()

{   

      Console.Write("Student Name: ");

      string name;

      int[] marks = new int[5];

      name = Console.ReadLine();

 

      for(int i = 1; i <= 5; i++)

      {

            Console.Write("Sub " + i.ToString() + " Mark: ");

            marks[i-1] = Convert.ToInt32(Console.ReadLine());

      }

      theStudents.AddRecord(name, marks);

}       

 

static void Main(string[] args)

{

 

      Console.WriteLine("Student MarkList Application");

      Console.Write("Enter the Total number  of students: ");

      int numStudents = -1;

      string s = Console.ReadLine();

      numStudents = Convert.ToInt32(s);

 

      for (int i = 1; i <= numStudents; i++)

      {

            Console.WriteLine("\nEnter " + i.ToString() + " Student Information\n");

            InputRecords();

      }

      ViewRecords();

      char ch = Console.ReadKey().KeyChar;

}

}

  
}



   # endregion