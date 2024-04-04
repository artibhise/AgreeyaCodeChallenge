using DapperGenericRepository.Repository;
using Repository.IRepository;
using Repository.Models;

namespace Repository.Repository
{
    internal class CustomerRepository : BaseReadWriteRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(Agreeya_CodeContext dbContext) : base(dbContext)
        {
        }
    }
}
