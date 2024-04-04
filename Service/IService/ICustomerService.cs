using Repository.Models;

namespace Service.IService
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer? GetById(int id);
        Customer SaveCustomer(Customer customer);
        bool DeleteCustomer(Customer customer);
        Customer UpdateCustomer(Customer customer);
    }
}
