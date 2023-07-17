using Microsoft.EntityFrameworkCore;
using Teste.Domain;

namespace Teste.Repositories
{
    public class Repository<T> where T : Entity
    {
        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> Post(T obj)
        {
            try
            {
                _dbContext.Set<T>().Add(obj);
                await _dbContext.SaveChangesAsync();
                return obj;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public async Task<T> Put(T obj)
        {
            try
            {
                var entity = await _dbContext.Set<T>().FindAsync(obj.Id);
                if (entity == null) return null;
                _dbContext.Entry(entity).CurrentValues.SetValues(obj);
                await _dbContext.SaveChangesAsync();
                return obj;
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var entity = await _dbContext.Set<T>().FindAsync(id);
                if (entity == null) return;
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
