using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Learn
{
    class Instructor
    {
        public string instructorName;
        public string instructorId;
        public List<Course> course_list;
        public string password;
        public static Instructor logedin_instructor;

        public Instructor(string instructorName, string password)
        {
            this.instructorName = instructorName;
            this.password = password;
            this.course_list = new List<Course>();
            Guid insId = Guid.NewGuid();
            this.instructorId = insId.ToString();

        }
        public Instructor(string instructorName, string password,string instructorId) {

            this.instructorName = instructorName;
            this.password = password;
            this.course_list = new List<Course>();
            
            this.instructorId = instructorId;
        }

        public static void PrintInsMain()
        {
            Console.WriteLine("1- Courses");
            Console.WriteLine("2- Give note");
            Console.WriteLine("0- Instructor Menu");

        }

        public static Instructor MenuInstructor()
        {
            Console.WriteLine("Instructor Id: ");
            string insId = Console.ReadLine();
            Console.WriteLine("Password: ");
            string insPassword = Console.ReadLine();
            bool found = false;
            for (int i = 0; i < Manager.instructor_list.Count; i++)
            {
                if (Manager.instructor_list[i].instructorId == insId && Manager.instructor_list[i].password == insPassword)
                {
                    found = true;
                    logedin_instructor = Manager.instructor_list[i];
                    break;
                }
            }
            if (found)
            {
                Console.WriteLine("Login is successful..");

                OptionInstMenu(logedin_instructor);
            }
            else
            {
                Console.WriteLine("Login is unsuccessful..");
                MenuInstructor();
            }
            return logedin_instructor;
        }

        public static void OptionInstMenu(Instructor user)
        {
            PrintInsMain();
            int option = 0;
            option = int.Parse(Console.ReadLine());


            switch (option)
            {
                case 1:
                    foreach (Course c in user.course_list)
                    {
                        Console.WriteLine(c.ToString());
                    }
                    OptionInstMenu(user);
                    break;
                case 2:
                    GiveNote();
                    
                    OptionInstMenu(user);
                    break;
                case 0:
                    Program.PrintOptions();
                    break;
            }
        }
        public static void GiveNote()
        {
            foreach(Course c in logedin_instructor.course_list)
            {
                Console.WriteLine(c.ToString());
            }
            Console.WriteLine("Course Id: ");
            string course = Console.ReadLine();
            Course crs = null;
            foreach (Course c in logedin_instructor.course_list)
            {
                if (course == c.courseId)
                {
                    crs = c;
                }
            }
            foreach(Student s in crs.student_list)
            {
                Console.WriteLine(s.ToString());
            }
            Console.WriteLine("Student Id: ");
            string student = Console.ReadLine();
            Student std = null;
            foreach (Student s in crs.student_list)
            {
                if(student == s.studentId)
                {
                    std = s;
                }
            }
            Console.WriteLine("Note: ");
            float note = float.Parse(Console.ReadLine());
            std.note_dict[course] = note;
            Console.WriteLine("Operation success..");
            OptionInstMenu(logedin_instructor);
        }
        public static void CreateIns()
        {
            Instructor ins1 = new Instructor("Ayhan Aydın", "1234");
            Manager.instructor_list.Add(ins1);
            Instructor ins2 = new Instructor("Yılmaz Ar", "4321");
            Manager.instructor_list.Add (ins2);
            Instructor ins3 = new Instructor("Şahin Emrah", "0258");
            Manager.instructor_list.Add(ins3);
            Instructor ins4 = new Instructor("İman Askerbeyli", "7896");
            Manager.instructor_list.Add(ins4);
            Instructor ins5 = new Instructor("Dora Yönden","12345","id1");
            Manager.instructor_list.Add(ins5);
        }

        public static void AddInstructor()
        {
            Console.WriteLine("Instructor name: ");
            string iname = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();

            Instructor inst = new Instructor(iname, password);
            Manager.instructor_list.Add(inst);

            Console.WriteLine("Insertion is successful...");

            
        }

        public static void DeleteInstructor()
        {
            Console.WriteLine("the ID of the instructor you want to delete: ");
            string iId = Console.ReadLine();
            for (int i = 0; i < Manager.student_list.Count; i++)
            {
                if (iId == Manager.instructor_list[i].instructorId)
                {
                    Manager.instructor_list.RemoveAt(i);
                }
            }

            Console.WriteLine("Deletion is successful...");
        }

        public static void ListInstructor()
        {
            foreach (Instructor i in Manager.instructor_list)
            {
                Console.WriteLine(i.ToString());
            }
        }

        public override string ToString()
        {
            return this.instructorId + " " + this.instructorName;
        }
    }

    
}
