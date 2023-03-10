using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TermPaper.Api.Data;
using TermPaper.Api.Requests;
using TermPaper.Api.Responses;
using TermPaper.Shared.Entities;

namespace TermPaper.Api.Services.ChatService
{
    public class ChatService : IChatService
    {
        private readonly DataContext dataContext;
        private readonly UserManager<User> userManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ChatService(DataContext dataContext, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this.dataContext = dataContext;
            this.userManager = userManager;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<BaseResponse> SendMessage(SendMessageToChatRequest request)
        {
            var order = await dataContext.Orders.SingleOrDefaultAsync(o => o.Id == request.OrderId);
            if (order is null)
            {
                return new BaseResponse() { Message = "Order not found!" };
            }

            QuestionAnswer questionAnswer = new QuestionAnswer()
            {
                OrderId = request.OrderId,
                Message = request.Message,
                User = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User)
            };

            dataContext.QuestionAnswers.Add(questionAnswer);
            await dataContext.SaveChangesAsync();

            return new BaseResponse() { Success = true, Message = "Message sent" };
        }
    }
}
