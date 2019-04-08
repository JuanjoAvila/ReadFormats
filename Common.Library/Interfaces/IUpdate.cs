using Common.Library.Model;

namespace Common.Library.Interfaces
{
    public interface IUpdate
    {
        Student UpdateStudent(int id, Student student);
    }
}