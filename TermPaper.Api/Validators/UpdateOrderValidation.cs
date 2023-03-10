using FluentValidation;
using TermPaper.Api.Requests;
using TermPaper.Shared.Enums;

namespace TermPaper.Api.Validators
{
    public class UpdateOrderValidation : AbstractValidator<UpdateOrderRequest>
    {
        public UpdateOrderValidation()
        {
            RuleFor(o => o.Status).NotNull().Must(BeValidOrderStatus).WithMessage("Status is wrong!");
        }

        private bool BeValidOrderStatus(int status)
        {
            return status < Enum.GetNames(typeof(OrderStatus)).Length;
        }
    }
}
