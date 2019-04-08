using Infrastructure.Repository.Interfaces;

namespace Presentation.Console.Interfaces
{
    public interface IDelete
    {
        void DeleteStudent(IRepository repository);
    }
}