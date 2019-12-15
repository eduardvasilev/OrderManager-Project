using System;
using System.Threading.Tasks;
using OrderManager.DataAccess;
using OrderManager.DomainModel;
using OrderManager.Services.CommandServices.Models.Order;

namespace OrderManager.Services.CommandServices
{
    public class OrderCommandSerivce : IOrderCommandService
    {
        private readonly IWriteRepository<Order> _orderRepository;
        private readonly IOrderItemCommandService _orderItemCommandService;
        private readonly IReadRepository<Product> _productRepository;

        public OrderCommandSerivce(IWriteRepository<Order> orderRepository, 
            IOrderItemCommandService orderItemCommandService,
            IReadRepository<Product> productRepository)
        {
            _orderRepository = orderRepository;
            _orderItemCommandService = orderItemCommandService;
            _productRepository = productRepository;
        }
        public async Task<CreateOrderResponse> CreateAsync(CreateOrderServiceModel serviceModel)
        {
            var order = new Order
            {
                AdditionalData = serviceModel.AdditionalData,
                StatusId = (long)OrderStatus.New,
                CreationDate = DateTime.UtcNow,
                OrderDate = serviceModel.OrderDate
            };
            _orderRepository.Create(order);

            await _orderRepository.SaveChangesAsync();
            
            foreach (var orderProduct in serviceModel.Products)
            {
                Product product = await _productRepository.GetByIdAsync(orderProduct.ProductId);
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