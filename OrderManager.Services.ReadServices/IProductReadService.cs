using System.Linq;
using OrderManager.Services.ReadServices.Models.Product;

namespace OrderManager.Services.ReadServices
{
    public interface IProductReadService
    {
        IQueryable<ProductServiceModel> GetAllDetails();
    }
}