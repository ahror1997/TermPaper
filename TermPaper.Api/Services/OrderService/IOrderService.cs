using TermPaper.Api.Requests;
using TermPaper.Api.Responses.Orders;

namespace TermPaper.Api.Services.OrderService
{
    public interface IOrderService
    {
        Task<OrderResponse> CreateOrder(CreateOrderRequest request);
    }
}
