using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn
{
    internal class Program
    {
        private Instructor userInstructor;
        public static void PrintOptions()
        {
            Console.WriteLine("1- Manager Giriş ");
            Console.WriteLine("2- Student Giriş ");
            Console.WriteLine("3- Instructor Giriş ");
            Console.WriteLine("4- Exit ");
            int option = 0;
            option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1: 
                    Manager.MenuManager();
                    break;
                case 2:
                    Student.MenuStudent();
                    break;
                case 3:
                    Instructor.MenuInstructor();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    PrintOptions();
                    break;
            }
        }
        
        static void Main(string[] args)
        {
            Student.CreateStd();
            Instructor.CreateIns();
            Course.TempCourse();
            PrintOptions();
            
            Console.ReadKey();
      
            
        }
    }
}
