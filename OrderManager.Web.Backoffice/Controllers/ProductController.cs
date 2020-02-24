using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderManager.Services.CommandServices;
using OrderManager.Services.CommandServices.Models.Product;
using OrderManager.Services.ReadServices;
using OrderManager.Services.ReadServices.Models.Product;

namespace OrderManager.Web.Backoffice.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductCommandService _productCommandService;
        private readonly IProductReadService _productReadService;

        public ProductController(
            IProductCommandService productCommandService,
            IProductReadService productReadService)
        {
            _productCommandService = productCommandService;
            _productReadService = productReadService;
        }

        public JsonResult Index()
        {
            List<ProductServiceModel> productServiceModels = _productReadService.GetAllDetails().ToList();
            return Json(productServiceModels);
        }

        [HttpPost]
        public JsonResult Create([FromBody]ProductServiceModel model)
        {
            _productCommandService.CreateAsync(new CreateProductServiceModel
            {
                Description = model.Description,
                Name = model.Name,
                Price = model.Price
            });

            return Json(true);
        }
    }
}