using System.Threading.Tasks;
using OrderManager.DataAccess;
using OrderManager.DomainModel;

namespace OrderManager.Services.CommandServices
{
    public class OrderItemCommandService : IOrderItemCommandService
    {
        private readonly IWriteRepository<OrderItem> _repository;

        public OrderItemCommandService(IWriteRepository<OrderItem> repository)
        {
            _repository = repository;
        }
        
        public async Task CreateAsync(Order order, Product product, long amount)
        {
            _repository.Create(new OrderItem
            {
                Order = order,
                OrderId = order.Id,
                Product = product,
                ProductId = product.Id,
                Amount = amount
            });

           await _repository.SaveChangesAsync();
        }
    }
}