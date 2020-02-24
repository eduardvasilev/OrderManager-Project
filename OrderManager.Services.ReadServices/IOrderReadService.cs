using System.Linq;
using OrderManager.Services.ReadServices.Models.Order;

namespace OrderManager.Services.ReadServices
{
    public interface IOrderReadService
    {
        IQueryable<OrderServiceModel> GetAllDetails();
    }
}