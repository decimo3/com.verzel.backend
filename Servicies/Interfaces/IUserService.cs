using Teste.Domain;

namespace Teste.Servicies.Interfaces
{
    public interface IUserService
    {
        Task<bool> Register(User user);
        Task<User> GetById(int id);
        Task<User> GetByName(string name);
        Task<IList<User>> GetAll();
        Task<User> Post(User user);
        Task<User> Put(User user);
        Task Delete(int id);
    }
}
