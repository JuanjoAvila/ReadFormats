using Infrastructure.Repository.Interfaces;

namespace Presentation.Console.Interfaces
{
    public interface IUpdate
    {
        void UpdateStudent(IRepository repository);
    }
}