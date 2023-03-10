using TermPaper.Api.Requests;
using TermPaper.Api.Responses;

namespace TermPaper.Api.Services.ChatService
{
    public interface IChatService
    {
        Task<BaseResponse> SendMessage(SendMessageToChatRequest request);
    }
}
