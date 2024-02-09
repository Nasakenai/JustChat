using JustChat.Application.Interfaces;
using JustChat.Infrastructure.Persistence;
using JustChat.Infrastructure.Repository;

namespace JustChat.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            if (_repositories.Keys.Contains(typeof(T)))
            {
                return _repositories[typeof(T)] as IRepository<T>;
            }

            var repository = Activator.CreateInstance(typeof(Repository<T>).MakeGenericType(typeof(T)), _context) as IRepository<T>;
            _repositories.Add(typeof(T), repository);
            return repository;
        }
    }
}
