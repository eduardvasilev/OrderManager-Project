using OrderManager.DomainModel;
using System.Threading.Tasks;

namespace OrderManager.Services.CommandServices
{
    public interface IOrderItemCommandService
    {
        Task CreateAsync(Order order, Product product, long amount);
    }
}