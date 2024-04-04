using DapperGenericRepository.IRepository;
using Repository.Models;

namespace DapperGenericRepository.Repository
{
    internal class BaseReadWriteRepository<T> : BaseReadOnlyRepository<T>, IReadWriteRepository<T>
      where T : class
    {
        // To detect redundant calls
        private bool _disposed = false;
        private readonly Agreeya_CodeContext _dbContext;
        public BaseReadWriteRepository(Agreeya_CodeContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        protected override void Dispose(bool disposing)
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
            base.Dispose(disposing);
        }

        public bool Delete(T model)
        {
            _dbContext.Set<T>().Remove(model);
            return _dbContext.SaveChanges() > 0;
        }

        public int Insert(T model)
        {
            _dbContext.Set<T>().Add(model);
            return _dbContext.SaveChanges();
        }

        public void SoftDelete(T model)
        {
            _dbContext.Set<T>().Update(model);
            _dbContext.SaveChanges();
        }

        public bool Update(T model)
        {
            _dbContext.Set<T>().Update(model);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
