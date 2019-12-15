using System.Linq;
using System.Threading.Tasks;
using OrderManager.Services.CommandServices.Models.Product;

namespace OrderManager.Services.CommandServices
{
    public interface IProductCommandService
    {
        Task CreateAsync(CreateProductServiceModel serviceModel);
    }
}