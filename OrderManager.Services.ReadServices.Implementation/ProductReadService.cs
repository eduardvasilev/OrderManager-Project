using OrderManager.DataAccess;
using OrderManager.DomainModel;
using OrderManager.Services.ReadServices.Models.Product;
using System.Linq;

namespace OrderManager.Services.ReadServices.Implementation
{
    public class ProductReadService : IProductReadService
    {
        private readonly IReadRepository<Product> _readRepository;

        public ProductReadService(IReadRepository<Product> readRepository)
        {
            _readRepository = readRepository;
        }
        
        public IQueryable<ProductServiceModel> GetAll()
        {
            return _readRepository.GetAll().Select(product => new ProductServiceModel
            {
                Id = product.Id,
                Price = product.Price,
                Name = product.Name,
                Description = product.Description
            });
        }
    }
}