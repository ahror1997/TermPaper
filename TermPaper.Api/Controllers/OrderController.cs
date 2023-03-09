using Microsoft.AspNetCore.Mvc;
using TermPaper.Api.Requests;
using TermPaper.Api.Responses.Orders;
using TermPaper.Api.Services.OrderService;

namespace TermPaper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderResponse>> CreateOrder(CreateOrderRequest request)
        {
            var response = await orderService.CreateOrder(request);
            return Ok(response);
        }
    }
}
