using Microsoft.AspNetCore.Mvc;
using OrderManager.Services.ReadServices;
using OrderManager.Services.ReadServices.Models.Order;
using System.Collections.Generic;
using System.Linq;

namespace OrderManager.Web.Backoffice.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderReadService _orderReadService;

        public OrderController(IOrderReadService orderReadService)
        {
            _orderReadService = orderReadService;
        }
        public JsonResult Index()
        {
            List<OrderServiceModel> orderServiceModels = _orderReadService.GetAllDetails().ToList();
            return Json(orderServiceModels);
        }
    }
}