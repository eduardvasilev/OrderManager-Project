using System;
using System.Threading.Tasks;
using OrderManager.DataAccess;
using OrderManager.DomainModel;
using OrderManager.Services.CommandServices.Models.Order;

namespace OrderManager.Services.CommandServices
{
    public class OrderCommandSerivce : IOrderCommandService
    {
        private readonly IWriteRepository<Order> _orderWriteRepository;
        private readonly IOrderItemCommandService _orderItemCommandService;
        private readonly IReadRepository<Product> _productReadRepository;

        public OrderCommandSerivce(IWriteRepository<Order> orderWriteRepository, 
            IOrderItemCommandService orderItemCommandService,
            IReadRepository<Product> productReadRepository)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderItemCommandService = orderItemCommandService;
            _productReadRepository = productReadRepository;
        }
        public async Task<CreateOrderResponse> CreateAsync(CreateOrderServiceModel serviceModel)
        {
            Order order = new Order
            {
                AdditionalData = serviceModel.AdditionalData,
                StatusId = (long)OrderStatus.New,
                CreationDate = DateTime.UtcNow,
                OrderDate = serviceModel.OrderDate ?? DateTime.UtcNow
            };

            _orderWriteRepository.Create(order);

            foreach (var orderProduct in serviceModel.Products)
            {
                Product product = await _productReadRepository.GetByIdAsync(orderProduct.ProductId);
                if (product == null)
                {
                    throw new Exception("Product not found.");
                }

                await _orderItemCommandService.CreateAsync(order, product, orderProduct.Amount);
            }

            return new CreateOrderResponse
            {
                OrderId = order.Id
            };
        }
    }
}