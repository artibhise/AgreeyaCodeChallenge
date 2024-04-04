using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.IRepository;
using Repository.Models;
using Repository.Repository;

namespace Repository
{
    public class IoC
    {
        public static void Setup(IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
