using Common.Library.Interfaces;
using Common.Library.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Library.Util
{
    public class FileManagerTxt : IFileManager
    {
        public static readonly string completePath = ConfigurationManager.AppSettings["PathFileTxt"];
        public static readonly String envRepositoryPath = Environment.GetEnvironmentVariable("PathFileTxt", EnvironmentVariableTarget.User);
        public static readonly ILogger Log = new LogFourNetAdapter();
        public static readonly string repositorypath = !string.IsNullOrEmpty(envRepositoryPath) ? envRepositoryPath : completePath;

        

        public Student AddStudent(Student student)
        {
            try
            {
                using (StreamWriter file = File.AppendText(repositorypath))
                {
                    file.WriteLine(student.ToString());
                    file.Close();
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

        public Student DeleteStudent(int Id)
        {
            Student studentToDelete;
            try
            {
                StringBuilder sb = new StringBuilder();
                var allStudents = GetAllStudents();
                studentToDelete = GetStudentById(Id);
                allStudents.Remove(studentToDelete);
                foreach (var lines in allStudents)
                {
                    sb.Append(lines);
                    sb.Append("\n");
                }
                File.WriteAllText(repositorypath, sb.ToString());
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

            string line = "";
            List<Student> students= new List<Student>();
            try
            {
                using (StreamReader sr = new StreamReader(repositorypath))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        students.Add(ToObject(line));
                    }
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

            return students;
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

        public Student UpdateStudent(int id, Student student)
        {
            using (StreamWriter file = new StreamWriter(repositorypath, true)) { }
            var studentList = GetAllStudents();
            StringBuilder sb = new StringBuilder();
            foreach (var students in studentList.Where(obj => obj.StudentId == id))
            {
                students.Name = !string.IsNullOrEmpty(student.Name) ? student.Name : "";
                students.Surname = !string.IsNullOrEmpty(student.Surname) ? student.Surname : "";
                students.Birthday = !string.IsNullOrEmpty(student.Birthday) ? student.Birthday : "";
            }
            foreach(var lines in studentList)
            {
                sb.Append(lines);
                sb.Append("\n");
            }
            File.WriteAllText(repositorypath, sb.ToString());
           
            return student;
        }

        private static Student ToObject(string line)
        {
            var expression = new Regex(
                string.Concat("(?<Guid>[^,]+), ", "(?<StudentId>[^,]+), ", "(?<Name>[^,]+), ",
                "(?<Surname>[^,]+), ", "(?<Birthday>[^,]+)"));
            var match = expression.Match(line);
            
            Student student = new Student
            {
                GuidStudent = new Guid(match.Groups["Guid"].ToString()),
                StudentId = int.Parse(match.Groups["StudentId"].ToString()),
                Name = match.Groups["Name"].ToString(),
                Surname = match.Groups["Surname"].ToString(),
                Birthday = match.Groups["Birthday"].ToString()
            };

            return student;
        }
    }
}
