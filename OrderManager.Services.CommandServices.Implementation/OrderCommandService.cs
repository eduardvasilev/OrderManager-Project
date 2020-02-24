using System;
using System.Threading.Tasks;
using OrderManager.DataAccess;
using OrderManager.DomainModel;
using OrderManager.Services.CommandServices.Models.Order;

namespace OrderManager.Services.CommandServices
{
    public class OrderCommandService : IOrderCommandService
    {
        private readonly IWriteRepository<Order> _orderWriteRepository;
        private readonly IOrderItemCommandService _orderItemCommandService;
        private readonly IReadRepository<Product> _productReadRepository;

        public OrderCommandService(IWriteRepository<Order> orderWriteRepository, 
            IOrderItemCommandService orderItemCommandService,
            IReadRepository<Product> productReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderItemCommandService = orderItemCommandService;
            _productReadRepository = productReadRepository;
        }

        public async Task<OrderCreated> CreateAsync(CreateOrder command)
        {
            Order order = new Order
            {
                AdditionalData = command.AdditionalData,
                StatusId = (long)OrderStatus.New,
                CreationDate = DateTime.UtcNow,
                OrderDate = command.OrderDate ?? DateTime.UtcNow
            };

            _orderWriteRepository.Create(order);

            foreach (var orderProduct in command.Products)
            {
                Product product = await _productReadRepository.GetByIdAsync(orderProduct.ProductId);
                if (product == null)
                {
                    throw new Exception("Product not found.");
                }

                await _orderItemCommandService.CreateAsync(order, product, orderProduct.Amount);
            }

            return new OrderCreated
            {
                OrderId = order.Id
            };
        }
    }
}