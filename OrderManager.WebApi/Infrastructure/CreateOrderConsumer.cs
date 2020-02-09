using System.Threading.Tasks;
using MassTransit;
using OrderManager.Services.CommandServices;
using OrderManager.Services.CommandServices.Models.Order;

namespace OrderManager.WebApi.Infrastructure
{
    public class CreateOrderConsumer : IConsumer<CreateOrder>
    {
        private readonly IOrderCommandService _orderCommandService;

        public CreateOrderConsumer(IOrderCommandService orderCommandService)
        {
            _orderCommandService = orderCommandService;
        }

        public async Task Consume(ConsumeContext<CreateOrder> context)
        {
            await _orderCommandService.CreateAsync(context.Message);

            await context.RespondAsync<OrderCreated>(new
            {
                Value = $"Order has been created: {context.Message}"
            });
        }
    }
}