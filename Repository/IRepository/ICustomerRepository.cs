using DapperGenericRepository.IRepository;
using Repository.Models;

namespace Repository.IRepository
{
    public interface ICustomerRepository : IReadWriteRepository<Customer>
    {
    }
}
