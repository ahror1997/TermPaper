using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TermPaper.Api.Requests;
using TermPaper.Api.Responses.Orders;
using TermPaper.Api.Services.OrderService;

namespace TermPaper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpPut]
        [Route("{orderId}")]
        public async Task<ActionResult<OrderResponse>> UpdateOrder(UpdateOrderRequest request, int orderId)
        {
            var response = await orderService.UpdateOrder(request, orderId);
            return Ok(response);
        }
    }
}
