using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderManager.Services.CommandServices;
using OrderManager.Services.CommandServices.Models.Order;

namespace OrderManager.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderCommandService _orderCommandService;

        public OrderController(IOrderCommandService orderCommandService)
        {
            _orderCommandService = orderCommandService;
        }
        
        [HttpPost("create")]
        public async Task Create([FromBody] CreateOrderServiceModel model)
        {
            await _orderCommandService.CreateAsync(model);
        }
    }
}