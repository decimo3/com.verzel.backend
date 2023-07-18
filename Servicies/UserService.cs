using Teste.Domain;
using Teste.Repositories.UserRepo.Interfaces;
using Teste.Servicies.Interfaces; // Assuming this namespace contains IUserService

namespace Teste.Servicies
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Delete(int id)
        {
            await _userRepository.Delete(id);
        }

        public async Task<IList<User>> GetAll()
        {
            var UserList = await _userRepository.GetAll();
            return UserList.ToList();
        }

        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<User> GetByName(string name)
        {
            return await _userRepository.GetByName(name);
        }

        public async Task<User> Post(User User)
        {
            return await _userRepository.Post(User);
        }

        public async Task<User> Put(User User)
        {
            return await _userRepository.Put(User);
        }

        public async Task<bool> Register(User user)
        {
            var result = await _userRepository.GetByName(user.Name);

            if (result != null)
            {
                return false;
            }

            await this.Post(user);

            return true;
        }
    }
}
