using GreenPipes;
using MassTransit;
using MassTransit.AspNetCoreIntegration;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderManager.Services.CommandServices.Models.Order;
using OrderManager.Web.Common;
using OrderManager.WebApi.Infrastructure;
using System;

namespace OrderManager.WebApi
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
            //services.AddOData();
            //            services.AddMvc(options => options.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<CreateOrderConsumer>();

            IBusControl CreateBus(IServiceProvider serviceProvider)
            {
                return Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host("localhost");

                    cfg.ReceiveEndpoint("create-order", ep =>
                    {
                        ep.PrefetchCount = 16;
                        ep.UseMessageRetry(r => r.Interval(2, 100));

                        ep.ConfigureConsumer<CreateOrderConsumer>(serviceProvider);
                    });
                });
            }

            void ConfigureMassTransit(IServiceCollectionConfigurator configurator)
            {
                configurator.AddConsumer<CreateOrderConsumer>();
            }

            services.AddMassTransit(CreateBus, ConfigureMassTransit);

            services.AddScoped(provider => provider.GetRequiredService<IBus>().CreateRequestClient<CreateOrder>());

            ServiceManager.RegisterServices(services, Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
