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

            RuleFor(o => o.Deadline).Must(BeAValidDate).WithMessage("Deadline date is wrong!");
        }

        private bool BeAValidDate(string date)
        {
            return DateOnly.TryParse(date, out DateOnly result);
        }
    }
}
