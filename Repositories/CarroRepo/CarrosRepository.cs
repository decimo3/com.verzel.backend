using Teste.Domain;
using Teste.Repositories.CarroRepo.Interfaces;

namespace Teste.Repositories
{
    public class CarrosRepository : Repository<Carro>, ICarrosRepository
    {
        public CarrosRepository(DatabaseContext dbContext) : base(dbContext) { }
    }
}
