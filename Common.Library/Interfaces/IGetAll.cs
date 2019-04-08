using Common.Library.Model;
using System.Collections.Generic;

namespace Common.Library.Interfaces
{
    public interface IGetAll
    {
        List<Student> GetAllStudents();
    }
}