using System.Threading.Tasks;
using OrderManager.DataAccess;
using OrderManager.DomainModel;

namespace OrderManager.Services.CommandServices
{
    public class OrderItemCommandService : IOrderItemCommandService
    {
        private readonly IWriteRepository<OrderItem> _writeRepository;

        public OrderItemCommandService(IWriteRepository<OrderItem> writeRepository)
        {
            _writeRepository = writeRepository;
        }
        
        public async Task CreateAsync(Order order, Product product, long amount)
        {
            _writeRepository.Create(new OrderItem
            {
                Order = order,
                OrderId = order.Id,
                Product = product,
                ProductId = product.Id,
                Amount = amount
            });

           await _writeRepository.SaveChangesAsync();
        }
    }
}