using System.Linq.Expressions;

namespace DapperGenericRepository.IRepository
{
    public interface IReadOnlyRepository<T> : IDisposable
        where T : class
    {       
        IEnumerable<T> GetAll();
        T? GetById(object Id);
    }
}
