using System.Linq;
using System.Threading.Tasks;
using OrderManager.DataAccess;
using OrderManager.DomainModel;
using OrderManager.Services.CommandServices.Models.Product;

namespace OrderManager.Services.CommandServices
{
    public class ProductCommandService : IProductCommandService
    {
        private readonly IWriteRepository<Product> _repository;

        public ProductCommandService(IWriteRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(CreateProductServiceModel serviceModel)
        {
            _repository.Create(new Product
            {
                Name = serviceModel.Name,
                Description = serviceModel.Description,
                Price = serviceModel.Price
            });

            await _repository.SaveChangesAsync();
        }
    }
}