using System.Linq;
using System.Threading.Tasks;
using OrderManager.DataAccess;
using OrderManager.DomainModel;
using OrderManager.Services.CommandServices.Models.Product;

namespace OrderManager.Services.CommandServices
{
    public class ProductCommandService : IProductCommandService
    {
        private readonly IWriteRepository<Product> _writeRepository;

        public ProductCommandService(IWriteRepository<Product> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task CreateAsync(CreateProductServiceModel serviceModel)
        {
            _writeRepository.Create(new Product
            {
                Name = serviceModel.Name,
                Description = serviceModel.Description,
                Price = serviceModel.Price
            });

            await _writeRepository.SaveChangesAsync();
        }
    }
}