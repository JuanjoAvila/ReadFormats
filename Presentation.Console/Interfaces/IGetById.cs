using Infrastructure.Repository.Interfaces;


namespace Presentation.Console.Interfaces
{
    public interface IGetById
    {
        void GetStudentById(IRepository repository);
    }
}
