using OrderManager.DataAccess;
using OrderManager.DomainModel;
using OrderManager.Services.CommandServices.Models.Product;
using System;
using System.Threading.Tasks;

namespace OrderManager.Services.CommandServices
{
    public class ProductCommandService : IProductCommandService
    {
        private readonly Lazy<IWriteRepository<Product>> _writeRepository;

        public ProductCommandService(Lazy<IWriteRepository<Product>> writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task CreateAsync(CreateProductServiceModel serviceModel)
        {
            _writeRepository.Value.Create(new Product
            {
                Name = serviceModel.Name,
                Description = serviceModel.Description,
                Price = serviceModel.Price
            });

            await _writeRepository.Value.SaveChangesAsync();
        }
    }
}