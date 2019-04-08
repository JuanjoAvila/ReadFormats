using Common.Library.Model;
using System.Collections.Generic;

namespace Infrastructure.Repository.Interfaces
{
    public interface IGetAll
    {
        List<Student> GetAll();
    }
}