using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderManager.Services.CommandServices;
using OrderManager.Services.CommandServices.Models.Product;
using OrderManager.Services.ReadServices;
using OrderManager.Services.ReadServices.Models.Product;

namespace OrderManager.WebApi.Backoffice.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductCommandService _productCommandService;
        private readonly IProductReadService _productReadService;

        public ProductController(IProductCommandService productCommandService,
            IProductReadService productReadService)
        {
            _productCommandService = productCommandService;
            _productReadService = productReadService;
        }
        
        [HttpPost("create")]
        public async Task Create([FromBody] CreateProductServiceModel model)
        {
            await _productCommandService.CreateAsync(model);
        }

        [HttpGet]
//      [EnableQuery]
        public IEnumerable<ProductServiceModel> Get()
        {
            return _productReadService.GetAll();
        }
    }
}
