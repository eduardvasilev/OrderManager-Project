using System;
using System.Threading.Tasks;
using OrderManager.DataAccess;
using OrderManager.DomainModel;

namespace OrderManager.Services.CommandServices
{
    public class OrderItemCommandService : IOrderItemCommandService
    {
        private readonly Lazy<IWriteRepository<OrderItem>> _writeRepository;

        public OrderItemCommandService(Lazy<IWriteRepository<OrderItem>> writeRepository)
        {
            _writeRepository = writeRepository;
        }
        
        public async Task CreateAsync(Order order, Product product, long amount)
        {
            _writeRepository.Value.Create(new OrderItem
            {
                Order = order,
                OrderId = order.Id,
                Product = product,
                ProductId = product.Id,
                Amount = amount
            });

           await _writeRepository.Value.SaveChangesAsync();
        }
    }
}