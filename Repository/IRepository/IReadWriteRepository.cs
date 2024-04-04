using System.Linq.Expressions;

namespace DapperGenericRepository.IRepository
{
    public interface IReadWriteRepository<T> : IReadOnlyRepository<T>
        where T : class
    {
        bool Delete(T model);
        int Insert(T model);
        void SoftDelete(T model);
        bool Update(T model);
    }
}
