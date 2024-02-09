namespace JustChat.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        IRepository<T> GetRepository<T>() where T : class;
    }
}
