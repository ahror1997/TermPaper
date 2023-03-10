using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TermPaper.Api.Requests;
using TermPaper.Api.Responses;
using TermPaper.Api.Services.ChatService;

namespace TermPaper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuestionAnswerController : ControllerBase
    {
        private readonly IChatService chatService;

        public QuestionAnswerController(IChatService chatService)
        {
            this.chatService = chatService;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse>> SendMessage(SendMessageToChatRequest request)
        {
            var response = await chatService.SendMessage(request);
            return Ok(response);
        }
    }
}
