using System;
using System.Linq;
using OrderManager.DataAccess;
using OrderManager.DomainModel;
using OrderManager.Services.ReadServices.Models.Order;

namespace OrderManager.Services.ReadServices.Implementation
{
    public class OrderItemReadService : IOrderItemReadService
    {
        private readonly Lazy<IReadRepository<OrderItem>> _readRepository;

        public OrderItemReadService(Lazy<IReadRepository<OrderItem>> readRepository)
        {
            _readRepository = readRepository;
        }
        public IQueryable<OrderItemServiceModel> GetAllDetail(long orderId)
        {
            return _readRepository.Value.GetAll().Where(item => item.OrderId == orderId)
                .Select(item => new OrderItemServiceModel
                {
                    Title = item.Product.Name,
                    Amount = item.Amount
                });
        }
    }
}