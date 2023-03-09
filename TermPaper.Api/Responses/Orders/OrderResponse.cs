using TermPaper.Shared.Entities;

namespace TermPaper.Api.Responses.Orders
{
    public class OrderResponse : BaseResponse
    {
        public Order? Data { get; set; }
    }
}
