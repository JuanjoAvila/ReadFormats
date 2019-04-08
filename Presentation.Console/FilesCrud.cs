using Common.Library.Model;
using Common.Library.Util;
using Infrastructure.Repository.Interfaces;
using Infrastructure.Repository.Repositories;
using Presentation.Console.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation.Console
{
    public class FilesCrud : ICrud
    {
        
        public void AddStudent(IRepository repository)
        {
            try
            {
                Student student = new Student();
                ObtainStudent(student);
                repository.Add(student);
                PrintInConsole.PrintStudentAdded(student);
                MenusController.MenuCrud(repository);
            }
            catch(CustomException e)
            {
                System.Console.WriteLine(Console_Resources.ErrorControl, e);
            }
        }

        private static void ObtainStudent(Student student)
        {
            ObtainIdOfStudent(student);
            ObtainData(student);
        }

        private static void ObtainData(Student student)
        {
            //Obtain the Student Name
            System.Console.WriteLine(Console_Resources.StudentName);
            student.Name = System.Console.ReadLine();
            System.Console.WriteLine(Console_Resources.Enter);
            //Obtain the Student Surname
            System.Console.WriteLine(Console_Resources.StudentSurname);
            student.Surname = System.Console.ReadLine();
            System.Console.WriteLine(Console_Resources.Enter);
            //Obtain the Student Birthday
            System.Console.WriteLine(Console_Resources.StudentBirthday);
            student.Birthday = System.Console.ReadLine();
            System.Console.WriteLine(Console_Resources.Enter);
        }

        public void GetAllStudents(IRepository repository)
        {
            try
            { 
                var students = repository.GetAll();
                PrintInConsole.PrintAllStudents(students);
                MenusController.MenuCrud(repository);
            }
            catch (CustomException e)
            {
                System.Console.WriteLine(Console_Resources.ErrorControl, e);
            }
        }

        public void GetStudentById(IRepository repository)
        {
            try
            {
                //Obtain the Id of the Student
                Student student = new Student();
                var id = ObtainIdOfStudent(student);

                //Search if exisits and print the Student found
                PrintInConsole.PrintStudentSearch(repository.GetById(id));

                //Return to menu
                MenusController.MenuCrud(repository);
            }
            catch (CustomException e)
            {
                System.Console.WriteLine(Console_Resources.ErrorControl, e);
            }

        }

        private static int ObtainIdOfStudent(Student student)
        {
            System.Console.WriteLine(Console_Resources.StudentId);
            student.StudentId = Convert.ToInt32(System.Console.ReadLine());
            return student.StudentId;
        }

        public void UpdateStudent(IRepository repository)
        {
            //Obtain all the Students to choose what Student Modify
            Student student = new Student();           
            var students = repository.GetAll();
            PrintInConsole.PrintAllStudents(students);

            //Obtain the Id of the student to choose what Student Modify
            System.Console.WriteLine(Console_Resources.IntroduceTheStudentToModify);
            var studentIntroduced = Convert.ToInt32(System.Console.ReadLine());

            //Obtain the student chose modified.
            ObtainData(student);

            //Update the student
            repository.UpdateStudent(studentIntroduced, student);

            //Print the Student Modified
            PrintInConsole.PrintStudentModified(student);

            //Return to menu
            MenusController.MenuCrud(repository);
        }

        public void DeleteStudent(IRepository repository)
        {
            //Obtain the Id of the Student
            Student student = new Student();
            var id = ObtainIdOfStudent(student);

            //Search if exisits and print the Student found
            var studentToDelete = repository.GetById(id);
            PrintInConsole.PrintStudentDelete(studentToDelete);
            ConditionToDeleteTheStudent(repository, studentToDelete);

        }

        private void ConditionToDeleteTheStudent(IRepository repository, Student student)
        {
            var userChoice = System.Console.ReadLine();
            if (userChoice.Equals("y"))
            {
                repository.DeleteStudent(student.StudentId);
                System.Console.WriteLine(Console_Resources.DeletedStudent);
                MenusController.MenuCrud(repository);
            }
            else if (userChoice.Equals("n"))
            {
                MenusController.MenuCrud(repository);
            }
            else
            {
                System.Console.WriteLine(Console_Resources.InvalidOption);
                ConditionToDeleteTheStudent(repository, student);
            }
        }
    }
}
