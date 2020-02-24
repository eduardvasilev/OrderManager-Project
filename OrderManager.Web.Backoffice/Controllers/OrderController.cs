using System;
using Microsoft.AspNetCore.Mvc;
using OrderManager.Services.ReadServices;
using OrderManager.Services.ReadServices.Models.Order;
using System.Collections.Generic;
using System.Linq;

namespace OrderManager.Web.Backoffice.Controllers
{
    public class OrderController : Controller
    {
        private readonly Lazy<IOrderReadService> _orderReadService;
        private readonly Lazy<IOrderItemReadService> _orderItemReadService;

        public OrderController(Lazy<IOrderReadService> orderReadService,
            Lazy<IOrderItemReadService> orderItemReadService)
        {
            _orderReadService = orderReadService;
            _orderItemReadService = orderItemReadService;
        }
        public JsonResult Index()
        {
            List<OrderServiceModel> orderServiceModels = _orderReadService.Value.GetAllDetails().ToList();
            return Json(orderServiceModels);
        }

        [Route("order/items")]
        public JsonResult GetOrderItems(long orderId)
        {
            OrderItemServiceModel[] orderItemServiceModels = _orderItemReadService.Value.GetAllDetail(orderId).ToArray();

            return Json(orderItemServiceModels);
        }
    }
}