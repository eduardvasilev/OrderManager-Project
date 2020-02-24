using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderManager.Services.CommandServices;
using OrderManager.Services.CommandServices.Models.Product;
using OrderManager.Services.ReadServices;
using OrderManager.Services.ReadServices.Models.Product;

namespace OrderManager.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Lazy<IProductCommandService> _productCommandService;
        private readonly Lazy<IProductReadService> _productReadService;

        public ProductController(Lazy<IProductCommandService> productCommandService,
            Lazy<IProductReadService> productReadService)
        {
            _productCommandService = productCommandService;
            _productReadService = productReadService;
        }
        
        [HttpPost("create")]
        public async Task Create([FromBody] CreateProductServiceModel model)
        {
            await _productCommandService.Value.CreateAsync(model);
        }

        [HttpGet]
        public IEnumerable<ProductServiceModel> Get()
        {
            return _productReadService.Value.GetAllDetails();
        }
    }
}
