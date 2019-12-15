using System.Threading.Tasks;
using OrderManager.Services.CommandServices.Models.Order;

namespace OrderManager.Services.CommandServices
{
    public interface IOrderCommandService
    {
        Task<CreateOrderResponse> CreateAsync(CreateOrderServiceModel serviceModel);
    }
}