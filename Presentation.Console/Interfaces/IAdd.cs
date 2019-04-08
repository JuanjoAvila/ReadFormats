using Infrastructure.Repository.Interfaces;

namespace Presentation.Console.Interfaces
{
    public interface IAdd
    {
        void AddStudent(IRepository repository);
    }
}