using System.Linq;
using System.Net.Http.Headers;
using OrderManager.DataAccess;
using OrderManager.DomainModel;
using OrderManager.Services.ReadServices;
using OrderManager.Services.ReadServices.Models.Product;

namespace OrderManager.Services.ReadServices.Implementation
{
    public class ProductReadService : IProductReadService
    {
        private readonly IReadRepository<Product> _repository;

        public ProductReadService(IReadRepository<Product> repository)
        {
            _repository = repository;
        }
        
        public IQueryable<ProductServiceModel> GetAll()
        {
            return _repository.GetAll().Select(product => new ProductServiceModel
            {
                Name = product.Name,
                Description = product.Description
            });
        }
    }
}