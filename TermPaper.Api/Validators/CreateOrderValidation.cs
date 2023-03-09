using FluentValidation;
using TermPaper.Api.Requests;

namespace TermPaper.Api.Validators
{
    public class CreateOrderValidation : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderValidation()
        {
            RuleFor(o => o.Title).NotEmpty().NotNull();

            RuleFor(o => o.Description).NotEmpty().NotNull();

            RuleFor(o => o.Deadline).NotEmpty().NotNull();
        }
    }
}
