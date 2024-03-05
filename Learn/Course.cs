using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Learn
{
    class Course
    {
        public string courseName;
        public string instructorName;
        public string courseId;
        public string instructorId;
        public List<Student> student_list;

        public Course(string courseName, string instructorId)
        {
            this.courseName = courseName;
            this.instructorId = instructorId;
            this.student_list = new List<Student>();
            Guid coId = Guid.NewGuid();
            this.courseId = coId.ToString();
        }

        public static void TempCourse()
        {
            Course tempCourse = new Course("TEMP Course", "id1");
            Manager.course_list.Add(tempCourse);
            foreach (Instructor tempInst in Manager.instructor_list)
            {
                tempInst.course_list.Add(tempCourse);
            }
        }
        public static void AddCourse()
        {
            Console.WriteLine("Course Name: ");
            string cname = Console.ReadLine();
            foreach (Instructor i in Manager.instructor_list)
            {
                Console.WriteLine(i.ToString());
            }
            Console.WriteLine("Instructor Id: ");
            string insId = Console.ReadLine();

            Course crs = new Course(cname, insId);
            Manager.course_list.Add(crs);

            foreach (Instructor i in Manager.instructor_list)
            {
                if (crs.instructorId == i.instructorId)
                {
                    i.course_list.Add(crs);
                }
            }

            Console.WriteLine("Insertion is successful...");
        }

        public static void DeleteCourse()
        {
            Console.WriteLine("the ID of the course you want to delete: ");
            string cId = Console.ReadLine();
            for (int i = 0; i < Manager.course_list.Count; i++)
            {
                if (cId == Manager.course_list[i].courseId)
                {
                    Manager.course_list.RemoveAt(i);
                }
            }

            Console.WriteLine("Deletion is successful...");
        }

        public static void ListCourse()
        {
            foreach (Course c in Manager.course_list)
            {
                Console.WriteLine(c.ToString());
            }
        }
        public override string ToString()
        {
            return this.courseId + " " + this.courseName;
        }

        
    }
}
