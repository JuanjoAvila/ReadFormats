using Common.Library.Model;

namespace Infrastructure.Repository.Interfaces
{
    public interface IGetById
    {
        Student GetById(int Id);
    }
}