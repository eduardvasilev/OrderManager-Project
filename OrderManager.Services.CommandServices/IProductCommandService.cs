using OrderManager.Services.CommandServices.Models.Product;
using System.Threading.Tasks;

namespace OrderManager.Services.CommandServices
{
    public interface IProductCommandService
    {
        Task CreateAsync(CreateProductServiceModel serviceModel);
    }
}