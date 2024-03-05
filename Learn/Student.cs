using Microsoft.SqlServer.Server;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn
{
    class Student
    {
        public string firstName;
        public string lastName;
        public string studentId;
        public List<Course> course_list;
        public Dictionary<string, float> note_dict;
        public float overallNote = 0;
        public string password;
        public static Student logedin_student;

        public Student(string firstName, string lastName, string password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.password = password;
            this.course_list = new List<Course>();
            this.note_dict = new Dictionary<string, float>();
            Guid stId = Guid.NewGuid();
            this.studentId = stId.ToString();
        }

        public Student(string firstName, string lastName, string password, string studentId) 
        { 
            this.firstName=firstName;
            this.lastName=lastName;
            this.password = password;
            this.course_list = new List<Course>();
            this.note_dict = new Dictionary<string, float>();
            this.studentId = studentId;
        }
        public static void CreateStd()
        {
            Student std1 = new Student("Berfin", "Savran", "1234");
            Manager.student_list.Add(std1);
            Student std2 = new Student("Sarp", "Yönden", "4321");
            Manager.student_list.Add(std2);
            Student std3 = new Student("Afra", "Bağcı", "0258");
            Manager.student_list.Add(std3);
            Student std4 = new Student("Seden", "Büdüş", "7896");
            Manager.student_list.Add(std4);
            Student std5 = new Student("Berfin", "Savran", "12345", "id1");
            Manager.student_list.Add(std5);
        }

        public static void PrintStuMain()
        {
            Console.WriteLine(OverallNote());
            Console.WriteLine("1- Courses");
            Console.WriteLine("2- My notes");
            Console.WriteLine("3- Select Course");
            Console.WriteLine("0- Student Menu");
        }

        public static float OverallNote()
        {
            float total = 0;
            int count = 0;
            foreach (float note in logedin_student.note_dict.Values)
            {
                total += note;
                count++;
            }
            return total / count;
        }

        public static void OptionStuMenu(Student user)
        {
            PrintStuMain();
            int option = 0;
            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    foreach (Course c in user.course_list)
                    {
                        Console.WriteLine(c.ToString());
                    }
                    
                    OptionStuMenu(user);
                    break;
                case 2:

                    foreach (string key in logedin_student.note_dict.Keys)
                    {
                        string result = key + ":" + logedin_student.note_dict[key];
                        Console.WriteLine(result);
                    }
                    OptionStuMenu(user);
                    break;
                case 3:
                    SelectCourse();
                    break;
                case 0:
                    Program.PrintOptions();
                    break;
            }
        }

        public static Student MenuStudent()
        {
            Console.WriteLine("Student Id: ");
            string student_id = Console.ReadLine();
            Console.WriteLine("Password: ");
            string student_password = Console.ReadLine();
            bool found = false;
            foreach (Student s in Manager.student_list)
            {
                if(s.studentId == student_id && s.password == student_password)
                {
                    found = true;
                    logedin_student = s;
                    
                }
            }
            if (found)
            {
                Console.WriteLine("Login is successful..");
                OptionStuMenu(logedin_student);
            }
            else Console.WriteLine("Login is unsuccessful..");
            return logedin_student;
        }

        public static void SelectCourse()
        {
            foreach (Course c in Manager.course_list)
            {
                Console.WriteLine(c.ToString());
            }
            Console.WriteLine("Course Id: ");
            string course_id = Console.ReadLine();
            Course course = null;
            foreach (Course c in Manager.course_list)
            {
                if (c.courseId == course_id)
                {
                    course = c;
                }
            }
            course.student_list.Add(logedin_student);
            logedin_student.course_list.Add(course);
            logedin_student.note_dict[course_id] = 0;
            Console.WriteLine("Operation is success..");
            OptionStuMenu(logedin_student);
        }

        public static void AddStudent()
        {
            Console.WriteLine("First name:");
            string fname = Console.ReadLine();
            Console.WriteLine("Last name:");
            string lname = Console.ReadLine();
            Console.WriteLine("Password:");
            string password = Console.ReadLine();

            Student stdn = new Student(fname, lname, password);
            Manager.student_list.Add(stdn);

            Console.WriteLine("Insertion is successful...");
        }

        public static void DeleteStudent() 
        {
            Console.WriteLine("the ID of the student you want to delete: ");
            string sId = Console.ReadLine();
            for (int i = 0; i < Manager.student_list.Count; i++)
            {
                if (sId == Manager.student_list[i].studentId)
                {
                    Manager.student_list.RemoveAt(i);
                }
            }

            Console.WriteLine("Deletion is successful...");
        }

        public static void ListStudent()
        {
            foreach (Student s in Manager.student_list)
            {
                Console.WriteLine(s.ToString());
            }
        }

        public override string ToString()
        {
            return this.studentId + " " + this.firstName + " " + this.lastName;
        }
    }
}
