using Teste.Domain;
using Teste.Repositories.CarroRepo.Interfaces;
using Teste.Servicies.Interfaces; // Assuming this namespace contains ICarroService

namespace Teste.Servicies
{
    public class CarroService : ICarroService
    {
        private readonly ICarrosRepository _carroRepository;

        public CarroService(ICarrosRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        public async Task Delete(int id)
        {
            await _carroRepository.Delete(id);
        }

        public async Task<IList<Carro>> GetAll()
        {
            var carroList = await _carroRepository.GetAll();
            return carroList.OrderByDescending(c => c.Valor).ToList();
        }

        public async Task<Carro> GetById(int id)
        {
            return await _carroRepository.GetById(id);
        }

        public async Task<Carro> Post(Carro carro)
        {
            return await _carroRepository.Post(carro);
        }

        public async Task<Carro> Put(Carro carro)
        {
            return await _carroRepository.Put(carro);
        }
    }
}
