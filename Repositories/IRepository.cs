using Teste.Domain;

namespace Teste.Repositories
{
    public interface IRepository <T> where T : Entity
    {
        Task<T> GetById(int id);
        Task<IList<T>> GetAll();
        Task<T> Post(T obj);
        Task<T> Put(T obj);
        Task Delete(int id);
    }
}
