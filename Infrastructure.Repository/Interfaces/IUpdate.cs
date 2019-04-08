using Common.Library.Model;

namespace Infrastructure.Repository.Interfaces
{
    public interface IUpdate
    {
        Student UpdateStudent(int id, Student student);

    }
}