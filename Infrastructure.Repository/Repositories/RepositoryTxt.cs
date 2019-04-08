using Common.Library.Interfaces;
using Common.Library.Model;
using Common.Library.Util;
using Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryTxt : IRepository
    {
        private readonly IFileManager FileManager;
        private readonly ILogger Log;
        public RepositoryTxt()
        {
            FileManager = new FileManagerTxt();
            Log = new LogFourNetAdapter();
        }
        public Student Add(Student student)
        {
            try
            {
                FileManager.AddStudent(student);
            }
            catch (CustomException e)
            {
                Log.Error(e.Message);
                Log.Error(e.StackTrace);
                throw;
            }
            return student;
        }

        public Student DeleteStudent(int Id)
        {
            try
            {
                FileManager.DeleteStudent(Id);
            }
            catch (CustomException e)
            {
                Log.Error(e.Message);
                Log.Error(e.StackTrace);
                throw;
            }
            return GetById(Id); 
        }

        public List<Student> GetAll()
        {
            List<Student> students;
            try
            {
                students = FileManager.GetAllStudents();
            }
            catch (CustomException e)
            {
                Log.Error(e.Message);
                Log.Error(e.StackTrace);
                throw;
            }
            return students;
        }

        public Student GetById(int Id)
        {
            Student student;
            try
            {
                student = FileManager.GetStudentById(Id);
            }
            catch (CustomException e)
            {
                Log.Error(e.Message);
                Log.Error(e.StackTrace);
                throw;
            }
            return student;
        }

        public Student UpdateStudent(int id , Student student)
        {
            try
            {
                student = FileManager.UpdateStudent(id, student);
            }

            catch (CustomException e)
            {
                Log.Error(e.Message);
                Log.Error(e.StackTrace);
                throw;
            }
            return student;
        }
    }
}
