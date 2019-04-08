using Common.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Console
{
    public static class PrintInConsole
    {
        public static void PrintStudentAdded(Student student)
        {
            System.Console.WriteLine(Console_Resources.PrintAddStudent);
            System.Console.WriteLine(student.ToString());
            System.Console.WriteLine(Console_Resources.Enter);
        }
        public static void PrintStudentSearch(Student student)
        {
            System.Console.WriteLine(Console_Resources.PrintFoundStudent);
            System.Console.WriteLine(student.ToString());
            System.Console.WriteLine(Console_Resources.Enter);
        }

        public static void PrintAllStudents(List<Student> students)
        {
            System.Console.WriteLine(Console_Resources.PrintAllStudents);
            foreach (var student in students)
                System.Console.WriteLine(student);
            System.Console.WriteLine(Console_Resources.Enter);
        }

        public static void PrintStudentModified(Student student)
        {
            System.Console.WriteLine(Console_Resources.PrintStudentModified);
            System.Console.WriteLine(student.ToString());
            System.Console.WriteLine(Console_Resources.Enter);
        }

        public static void PrintStudentDelete(Student student)
        {
            System.Console.WriteLine(Console_Resources.PrintDeleteStudent);
            System.Console.WriteLine(student.ToString());
            System.Console.WriteLine(Console_Resources.Enter);
        }

    }
}
