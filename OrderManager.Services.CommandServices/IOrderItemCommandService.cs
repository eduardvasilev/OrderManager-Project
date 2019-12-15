using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManager.DomainModel;

namespace OrderManager.Services.CommandServices
{
    public interface IOrderItemCommandService
    {
        Task CreateAsync(Order order, Product product, long amount);
    }
}