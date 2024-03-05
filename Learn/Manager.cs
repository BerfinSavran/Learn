using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Learn
{
    class Manager
    {
        public static List<Student> student_list = new List<Student>();
        public static List<Course> course_list = new List<Course>();
        public static List<Instructor> instructor_list = new List<Instructor>();
        public static string email = "berfin";
        public static string password = "1234";

        public static void MenuManager()
        {
            Console.WriteLine("Email: ");
            string managerMail = Console.ReadLine();
            Console.WriteLine("Password: ");
            string managerPassword = Console.ReadLine();
            if(managerMail == Manager.email && managerPassword == Manager.password ) 
            {
                Console.WriteLine("Welcome...");
                PrintManMain();
        
            }
            else
            {
                Console.WriteLine("Login informations are incorrect...");
                Program.PrintOptions();
            }
        }

        public static void PrintManMain()
        {
            Console.WriteLine("1- Add Student ");
            Console.WriteLine("2- List Student ");
            Console.WriteLine("3- Delete Student ");
            Console.WriteLine("4- Add Instructor ");
            Console.WriteLine("5- List Instructor ");
            Console.WriteLine("6- Delete Instructor ");
            Console.WriteLine("7- Add Course ");
            Console.WriteLine("8- List Course ");
            Console.WriteLine("9- Delete Course ");
            Console.WriteLine("0- Main Menu ");
            ManagerMain();
        }

        public static void ManagerMain()
        {
            int option = 0;
            
            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Student.AddStudent();
                    PrintManMain();
                    break;
                case 2:
                    Student.ListStudent();
                    PrintManMain();
                    break;
                case 3:
                    Student.DeleteStudent();
                    PrintManMain();
                    break;
                case 4:
                    Instructor.AddInstructor();
                    
                    PrintManMain();
                    break;
                case 5:
                    Instructor.ListInstructor();
                    PrintManMain();
                    break;
                case 6:
                    Instructor.DeleteInstructor();
                    PrintManMain();
                    break;
                case 7:
                    Course.AddCourse();
                    PrintManMain();
                    break;
                case 8:
                    Course.ListCourse();
                    PrintManMain();
                    break;
                case 9:
                    Course.DeleteCourse();
                    PrintManMain();
                    break;
                case 0:
                    Program.PrintOptions();
                    break;
            }
        }
    }

}
