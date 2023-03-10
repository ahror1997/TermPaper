using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TermPaper.Api.Data;
using TermPaper.Api.Requests;
using TermPaper.Api.Responses.Orders;
using TermPaper.Shared.Entities;
using TermPaper.Shared.Enums;

namespace TermPaper.Api.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly UserManager<User> userManager;
        private readonly DataContext dataContext;
        private readonly IHttpContextAccessor httpContextAccessor;

        public OrderService(UserManager<User> userManager, DataContext dataContext, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.dataContext = dataContext;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<OrderResponse> CreateOrder(CreateOrderRequest request)
        {
            Order order = new Order()
            {
                Title = request.Title,
                Description = request.Description,
                Status = OrderStatus.New,
                User = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User),
                Deadline = DateOnly.Parse(request.Deadline),
                CreatedAt = DateTime.UtcNow,
            };

            dataContext.Orders.Add(order);
            await dataContext.SaveChangesAsync();

            return new OrderResponse()
            {
                Success = true,
                Data = order
            };
        }

        public async Task<OrderResponse> UpdateOrder(UpdateOrderRequest request, int orderId)
        {
            var order = await dataContext.Orders.SingleOrDefaultAsync(o => o.Id == orderId);
            if (order is null)
            {
                return new OrderResponse() { Message = "Order not found!" };
            }

            order.Status = (OrderStatus)request.Status;
            order.UpdatedAt = DateTime.UtcNow;
            await dataContext.SaveChangesAsync();

            return new OrderResponse() { Data = order, Message = "Order successfully updated!", Success = true };
        }
    }
}
