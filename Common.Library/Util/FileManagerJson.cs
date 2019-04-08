using Common.Library.Interfaces;
using Common.Library.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace Common.Library.Util
{
    public class FileManagerJson : IFileManager
    {
        public static readonly string completePath = ConfigurationManager.AppSettings["PathFileJson"];
        public static readonly String envRepositoryPath = Environment.GetEnvironmentVariable("PathFileJson", EnvironmentVariableTarget.User);
        public static readonly ILogger Log = new LogFourNetAdapter();
        public static readonly string repositorypath = !string.IsNullOrEmpty(envRepositoryPath) ? envRepositoryPath : completePath;

      
        public Student AddStudent(Student student)
        {
            using (StreamWriter file = new StreamWriter(repositorypath, true)) { }

            try
                {
                    var json = File.ReadAllText(repositorypath);
                    var students = JsonConvert.DeserializeObject<List<Student>>(json);
                    if (students == null)
                        students = new List<Student>();
                    students.Add(student);
                    var studentJson = JsonConvert.SerializeObject(students, Formatting.Indented);
                    File.WriteAllText(repositorypath, studentJson);
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
                var allStudents = GetAllStudents();
                studentToDelete = GetStudentById(Id);
                allStudents.Remove(studentToDelete);
                var students = JsonConvert.SerializeObject(allStudents, Formatting.Indented);
                File.WriteAllText(repositorypath, students);
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
            List<Student> students;
            try
            {
                string fileJson = File.ReadAllText(repositorypath);
                students = JsonConvert.DeserializeObject<List<Student>>(fileJson);
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

            return students.OrderBy(id => id.StudentId).ToList();
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
            var json = File.ReadAllText(repositorypath);
            var studentEntity = JsonConvert.DeserializeObject<List<Student>>(json);
            if (studentEntity == null)
                studentEntity = new List<Student>();

            foreach (var students in studentEntity.Where(obj => obj.StudentId == id))
            {
                students.Name = !string.IsNullOrEmpty(student.Name) ? student.Name : "";
                students.Surname = !string.IsNullOrEmpty(student.Surname) ? student.Surname : "";
                students.Birthday = !string.IsNullOrEmpty(student.Birthday) ? student.Birthday : "";
            }
            var studentJson = JsonConvert.SerializeObject(studentEntity, Formatting.Indented);
            File.WriteAllText(repositorypath, studentJson);

            return student;
        }
    }
}
