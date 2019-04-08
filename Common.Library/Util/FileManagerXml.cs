using Common.Library.Interfaces;
using Common.Library.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Common.Library.Util
{
    public class FileManagerXml : IFileManager
    {
        public static readonly string completePath = ConfigurationManager.AppSettings["PathFileXml"];
        public static readonly String envRepositoryPath = Environment.GetEnvironmentVariable("PathFileXml", EnvironmentVariableTarget.User);
        public static readonly ILogger Log = new LogFourNetAdapter();
        public static readonly string repositorypath = !string.IsNullOrEmpty(envRepositoryPath) ? envRepositoryPath : completePath;

        public Student AddStudent(Student student)
        {
            using (StreamWriter file = new StreamWriter(repositorypath, true)) { }
            List<Student> studentList = GetAllStudents();
            studentList.Add(student);
            try
            {
                XmlSerializer xr = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("Students"));
                using (FileStream fs = File.Create(repositorypath))
                {
                    xr.Serialize(fs, studentList);
                }
            }
            #region Exceptions and Log
            catch (UnauthorizedAccessException e)
            {
                Log.Error(Common_Resources.Unauthorized
                               + e.Message + Common_Resources.ErrorLogSeparation
                               + e.Data + Common_Resources.ErrorLogSeparation
                               + e.StackTrace);
                throw new CustomException(Common_Resources.Unauthorized, e);

            }
            catch (ArgumentException e)
            {
                Log.Error(Common_Resources.ArgumentException
                               + e.Message + Common_Resources.ErrorLogSeparation
                               + e.Data + Common_Resources.ErrorLogSeparation
                               + e.StackTrace);
                throw new CustomException(Common_Resources.ArgumentException, e);

            }
            catch (DirectoryNotFoundException e)
            {
                Log.Error(Common_Resources.DirectoryNotFound
                               + e.Message + Common_Resources.ErrorLogSeparation
                               + e.Data + Common_Resources.ErrorLogSeparation
                               + e.StackTrace);
                throw new CustomException(Common_Resources.DirectoryNotFound, e);

            }
            catch (IOException e)
            {
                Log.Error(Common_Resources.IOException
                               + e.Message + Common_Resources.ErrorLogSeparation
                               + e.Data + Common_Resources.ErrorLogSeparation
                               + e.StackTrace);
                throw new CustomException(Common_Resources.IOException, e);

            }
            #endregion

            return GetStudentById(student.StudentId);
        }

        public Student DeleteStudent(int Id)
        {
            Student studentToDelete;
            try
            {
                var studentList = GetAllStudents();
                studentToDelete = GetStudentById(Id);
                studentList.Remove(studentToDelete);
                XmlSerializer xr = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("Students"));
                using (FileStream fs = File.Create(repositorypath))
                {
                    xr.Serialize(fs, studentList);
                }
            }
            #region Exceptions and Log
            catch (UnauthorizedAccessException e)
            {
                Log.Error(Common_Resources.Unauthorized
                               + e.Message + Common_Resources.ErrorLogSeparation
                               + e.Data + Common_Resources.ErrorLogSeparation
                               + e.StackTrace);
                throw new CustomException(Common_Resources.Unauthorized, e);

            }
            catch (ArgumentException e)
            {
                Log.Error(Common_Resources.ArgumentException
                               + e.Message + Common_Resources.ErrorLogSeparation
                               + e.Data + Common_Resources.ErrorLogSeparation
                               + e.StackTrace);
                throw new CustomException(Common_Resources.ArgumentException, e);

            }
            catch (DirectoryNotFoundException e)
            {
                Log.Error(Common_Resources.DirectoryNotFound
                               + e.Message + Common_Resources.ErrorLogSeparation
                               + e.Data + Common_Resources.ErrorLogSeparation
                               + e.StackTrace);
                throw new CustomException(Common_Resources.DirectoryNotFound, e);

            }
            catch (IOException e)
            {
                Log.Error(Common_Resources.IOException
                               + e.Message + Common_Resources.ErrorLogSeparation
                               + e.Data + Common_Resources.ErrorLogSeparation
                               + e.StackTrace);
                throw new CustomException(Common_Resources.IOException, e);

            }
            #endregion

            return studentToDelete;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> studentList = new List<Student>();
            try
            {
                string xmlContent = File.ReadAllText(repositorypath);
                if (string.IsNullOrEmpty(xmlContent))
                {
                    return studentList;
                }
                XmlSerializer xr = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("Students"));
                using (TextReader tr = new StringReader(xmlContent))
                {
                    studentList = (List<Student>)xr.Deserialize(tr);
                }
            }
            #region Exceptions and Log
            catch (UnauthorizedAccessException e)
            {
                Log.Error(Common_Resources.Unauthorized
                               + e.Message + Common_Resources.ErrorLogSeparation
                               + e.Data + Common_Resources.ErrorLogSeparation
                               + e.StackTrace);
                throw new CustomException(Common_Resources.Unauthorized, e);

            }
            catch (ArgumentException e)
            {
                Log.Error(Common_Resources.ArgumentException
                               + e.Message + Common_Resources.ErrorLogSeparation
                               + e.Data + Common_Resources.ErrorLogSeparation
                               + e.StackTrace);
                throw new CustomException(Common_Resources.ArgumentException, e);

            }
            catch (DirectoryNotFoundException e)
            {
                Log.Error(Common_Resources.DirectoryNotFound
                               + e.Message + Common_Resources.ErrorLogSeparation
                               + e.Data + Common_Resources.ErrorLogSeparation
                               + e.StackTrace);
                throw new CustomException(Common_Resources.DirectoryNotFound, e);

            }
            catch (IOException e)
            {
                Log.Error(Common_Resources.IOException
                               + e.Message + Common_Resources.ErrorLogSeparation
                               + e.Data + Common_Resources.ErrorLogSeparation
                               + e.StackTrace);
                throw new CustomException(Common_Resources.IOException, e);

            }
            #endregion

            return studentList.OrderBy(id => id.StudentId).ToList();
        }

        public Student GetStudentById(int Id)
        {
            Student studentById;
            try
            {
                var students = GetAllStudents();
                studentById = students.FirstOrDefault(id => id.StudentId.Equals(Id));
            }
            #region Exceptions and Log
            catch (UnauthorizedAccessException e)
            {
                Log.Error(Common_Resources.Unauthorized
                               + e.Message + Common_Resources.ErrorLogSeparation
                               + e.Data + Common_Resources.ErrorLogSeparation
                               + e.StackTrace);
                throw new CustomException(Common_Resources.Unauthorized, e);

            }
            catch (ArgumentException e)
            {
                Log.Error(Common_Resources.ArgumentException
                               + e.Message + Common_Resources.ErrorLogSeparation
                               + e.Data + Common_Resources.ErrorLogSeparation
                               + e.StackTrace);
                throw new CustomException(Common_Resources.ArgumentException, e);

            }
            catch (DirectoryNotFoundException e)
            {
                Log.Error(Common_Resources.DirectoryNotFound
                               + e.Message + Common_Resources.ErrorLogSeparation
                               + e.Data + Common_Resources.ErrorLogSeparation
                               + e.StackTrace);
                throw new CustomException(Common_Resources.DirectoryNotFound, e);

            }
            catch (IOException e)
            {
                Log.Error(Common_Resources.IOException
                               + e.Message + Common_Resources.ErrorLogSeparation
                               + e.Data + Common_Resources.ErrorLogSeparation
                               + e.StackTrace);
                throw new CustomException(Common_Resources.IOException, e);

            }
            #endregion

            return studentById;
        }

        public Student UpdateStudent(int id , Student student)
        {
            using (StreamWriter file = new StreamWriter(repositorypath, true)) { }
            var studentList = GetAllStudents();

            foreach (var students in studentList.Where(obj => obj.StudentId == id))
            {
                students.Name = !string.IsNullOrEmpty(student.Name) ? student.Name : "";
                students.Surname = !string.IsNullOrEmpty(student.Surname) ? student.Surname : "";
                students.Birthday = !string.IsNullOrEmpty(student.Birthday) ? student.Birthday : "";
            }
            try
            {
                XmlSerializer xr = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("Students"));
                using (FileStream fs = File.Create(repositorypath))
                {
                    xr.Serialize(fs, studentList);
                }
            }
            #region Exceptions and Log
            catch (UnauthorizedAccessException e)
            {
                Log.Error(Common_Resources.Unauthorized
                               + e.Message + Common_Resources.ErrorLogSeparation
                               + e.Data + Common_Resources.ErrorLogSeparation
                               + e.StackTrace);
                throw new CustomException(Common_Resources.Unauthorized, e);

            }
            catch (ArgumentException e)
            {
                Log.Error(Common_Resources.ArgumentException
                               + e.Message + Common_Resources.ErrorLogSeparation
                               + e.Data + Common_Resources.ErrorLogSeparation
                               + e.StackTrace);
                throw new CustomException(Common_Resources.ArgumentException, e);

            }
            catch (DirectoryNotFoundException e)
            {
                Log.Error(Common_Resources.DirectoryNotFound
                               + e.Message + Common_Resources.ErrorLogSeparation
                               + e.Data + Common_Resources.ErrorLogSeparation
                               + e.StackTrace);
                throw new CustomException(Common_Resources.DirectoryNotFound, e);

            }
            catch (IOException e)
            {
                Log.Error(Common_Resources.IOException
                               + e.Message + Common_Resources.ErrorLogSeparation
                               + e.Data + Common_Resources.ErrorLogSeparation
                               + e.StackTrace);
                throw new CustomException(Common_Resources.IOException, e);

            }
            #endregion

            return student;
        }
    }
}
