using Microsoft.EntityFrameworkCore;
using Teste.Domain;
using Teste.Repositories.UserRepo.Interfaces;

namespace Teste.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DatabaseContext _dbContext;
        public UserRepository(DatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> GetByName(string name)
        {
            return await _dbContext.User.FirstOrDefaultAsync(u => u.Name.ToLower() == name.ToLower());
        }
    }
}
