using FluentValidation;
using TermPaper.Api.Requests;

namespace TermPaper.Api.Validators
{
    public class SendMessageToChatValidation : AbstractValidator<SendMessageToChatRequest>
    {
        public SendMessageToChatValidation()
        {
            RuleFor(m => m.OrderId).NotEmpty().NotNull();

            RuleFor(m => m.Message).NotEmpty().NotNull();
        }
    }
}
