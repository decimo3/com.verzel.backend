using Teste.Domain;
using Teste.Repositories.CarroRepo.Interfaces;

namespace Teste.Repositories
{
    public class CarroRepository : Repository<Carro>, ICarroRepository
    {
        public CarroRepository(DatabaseContext dbContext) : base(dbContext) { }
    }
}
