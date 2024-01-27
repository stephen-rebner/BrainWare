using BrainWare.Dal;
using Microsoft.Extensions.DependencyInjection;

namespace Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
        }
    }
}