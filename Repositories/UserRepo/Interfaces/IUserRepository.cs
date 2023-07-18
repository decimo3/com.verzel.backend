using Teste.Domain;

namespace Teste.Repositories.UserRepo.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByName(string name);
    }
}
