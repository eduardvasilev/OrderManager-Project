using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManager.DataAccess.Ef;
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
        }
    }
}
