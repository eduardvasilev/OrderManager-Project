using MassTransit;
using Microsoft.AspNetCore.Mvc;
using OrderManager.Services.CommandServices.Models.Order;
using System.Threading;
using System.Threading.Tasks;

namespace OrderManager.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRequestClient<CreateOrder> _requestClient;

        public OrderController(IRequestClient<CreateOrder> requestClient)
        {
            _requestClient = requestClient;
        }

        [HttpPost("create")]
        public async Task<JsonResult> Create([FromBody] CreateOrder model, CancellationToken cancellationToken)
        {
            var request = _requestClient.Create(model, cancellationToken);

            await request.GetResponse<OrderCreated>();
            return new JsonResult("Order has been created.");
        }
    }
}