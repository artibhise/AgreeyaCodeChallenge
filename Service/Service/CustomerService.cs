using Repository.IRepository;
using Repository.Models;
using Service.IService;
using Shared.Helpers;

namespace Service.Service
{
    internal class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public bool DeleteCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public Customer? GetById(int id)
        {
            return _customerRepository.GetById(id);
        }

        public Customer SaveCustomer(Customer customer)
        {
            encryptPersonalData(customer);
            _customerRepository.Insert(customer);
            return customer;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            encryptPersonalData(customer);
            _customerRepository.Update(customer);
            return customer;
        }
        private void encryptPersonalData(Customer customer)
        {
            customer.Password = SHA1Crypto.Encrypt(customer.Password);
            customer.Email = SHA1Crypto.Encrypt(customer.Email);
        }
    }
}
