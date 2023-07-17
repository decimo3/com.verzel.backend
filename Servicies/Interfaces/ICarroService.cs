using Teste.Domain;

namespace Teste.Servicies.Interfaces
{
    public interface ICarroService
    {
        Task<Carro> GetById(int id);
        Task<IList<Carro>> GetAll();
        Task<Carro> Post(Carro carro);
        Task<Carro> Put(Carro carro);
        Task Delete(int id);
    }
}
