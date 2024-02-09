using JustChat.Application.Interfaces;

namespace JustChat.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public async Task<TEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
