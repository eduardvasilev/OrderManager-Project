using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManager.DataAccess;
using OrderManager.DataAccess.Ef;
using OrderManager.Services.CommandServices;
using OrderManager.Services.ReadServices;
using OrderManager.Services.ReadServices.Implementation;
using Serilog;

namespace OrderManager.Web.Common
{
    public static class ServiceManager
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EfContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddLogging(builder => builder.AddSerilog());
            services.AddTransient(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddTransient(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped<IOrderCommandService, OrderCommandService>();
            services.AddScoped<IOrderItemCommandService, OrderItemCommandService>();
            services.AddScoped<IProductCommandService, ProductCommandService>();
            services.AddScoped<IProductReadService, ProductReadService>();
            services.AddScoped<IOrderReadService, OrderReadService>();
        }
    }
}
