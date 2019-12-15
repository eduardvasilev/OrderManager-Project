using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OrderManager.DataAccess;
using OrderManager.DataAccess.Ef;
using OrderManager.Services.CommandServices;
using OrderManager.Services.ReadServices;
using OrderManager.Services.ReadServices.Implementation;

namespace OrderManager.WebApi.Client
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
//            services.AddOData();
//            services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
              
            services.AddDbContext<EfContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            
            services.AddTransient(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddTransient(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped<IProductCommandService, ProductCommandService>();
            services.AddScoped<IProductReadService, ProductReadService>();
            services.AddScoped<IOrderCommandService, OrderCommandSerivce>();
            services.AddScoped<IOrderItemCommandService, OrderItemCommandService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}