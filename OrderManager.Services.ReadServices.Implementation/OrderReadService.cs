using System.Linq;
using OrderManager.DataAccess;
using OrderManager.DomainModel;
using OrderManager.Services.ReadServices.Models.Order;

namespace OrderManager.Services.ReadServices.Implementation
{
    public class OrderReadService : IOrderReadService
    {
        private readonly IReadRepository<Order> _orderReadRepository;

        public OrderReadService(IReadRepository<Order> orderReadRepository)
        {
            _orderReadRepository = orderReadRepository;
        }

        public IQueryable<OrderServiceModel> GetAllDetails()
        {
            return _orderReadRepository.GetAll().Select(order => new OrderServiceModel
            {
                Id = order.Id,
                AdditionalData = order.AdditionalData,
                CreationDate = order.CreationDate,
                StatusId = order.StatusId
            });
        }
    }
}