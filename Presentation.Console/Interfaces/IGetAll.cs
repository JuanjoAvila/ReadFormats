using Infrastructure.Repository.Interfaces;


namespace Presentation.Console.Interfaces
{
    public interface IGetAll
    {
        void GetAllStudents(IRepository repository);
    }
}
