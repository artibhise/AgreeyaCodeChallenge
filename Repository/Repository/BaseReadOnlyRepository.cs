using DapperGenericRepository.IRepository;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace DapperGenericRepository.Repository
{
    public abstract class BaseReadOnlyRepository<T> : IReadOnlyRepository<T>
       where T : class
    {
        // To detect redundant calls
        private bool _disposed = false;
        private readonly Agreeya_CodeContext _dbContext;
        public BaseReadOnlyRepository(Agreeya_CodeContext context)
        {
            _dbContext = context;
        }
        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }

        public T? GetById(object Id)
        {
            return _dbContext.Set<T>().Find(Id);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // Dispose managed state (managed objects).                
                _dbContext.Dispose();
            }

            _disposed = true;
        }
    }
}
