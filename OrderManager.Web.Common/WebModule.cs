using Autofac;
using OrderManager.DataAccess;
using OrderManager.DataAccess.Ef;
using OrderManager.Services.CommandServices;
using OrderManager.Services.ReadServices;
using OrderManager.Services.ReadServices.Implementation;

namespace OrderManager.Web.Common
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<EfContext>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(WriteRepository<>)).As(typeof(IWriteRepository<>)).InstancePerDependency();
            builder.RegisterGeneric(typeof(ReadRepository<>)).As(typeof(IReadRepository<>)).InstancePerDependency();
            builder.RegisterType<OrderCommandService>().As<IOrderCommandService>().InstancePerLifetimeScope();
            builder.RegisterType<OrderItemCommandService>().As<IOrderItemCommandService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductCommandService>().As<IProductCommandService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductReadService>().As<IProductReadService>().InstancePerLifetimeScope();
            builder.RegisterType<OrderReadService>().As<IOrderReadService>().InstancePerLifetimeScope();
        }
    }
}