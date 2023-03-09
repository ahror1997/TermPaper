using Microsoft.AspNetCore.Identity;
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

        public OrderService(UserManager<User> userManager, DataContext dataContext)
        {
            this.userManager = userManager;
            this.dataContext = dataContext;
        }

        public async Task<OrderResponse> CreateOrder(CreateOrderRequest request)
        {
            Order order = new Order()
            {
                Title = request.Title,
                Description = request.Description,
                Status = OrderStatus.New,
                //User = userManager.GetUserAsync(),
                Deadline = request.Deadline
            };

            dataContext.Orders.Add(order);
            await dataContext.SaveChangesAsync();

            return new OrderResponse()
            {
                Success = true,
                Data = order
            };
        }
    }
}
