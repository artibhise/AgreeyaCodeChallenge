using Microsoft.Extensions.DependencyInjection;
using Service.IService;
using Service.Service;

namespace Service
{
    public class IoC
    {
        public static void Setup(IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
        }
    }
}
