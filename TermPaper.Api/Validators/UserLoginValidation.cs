using FluentValidation;
using TermPaper.Api.Requests;

namespace TermPaper.Api.Validators
{
    public class UserLoginValidation : AbstractValidator<LoginRequest>
    {
        public UserLoginValidation()
        {
            RuleFor(u => u.UserName).NotEmpty()
                                    .NotNull();

            RuleFor(u => u.Password).NotEmpty()
                                    .NotNull();
        }
    }
}
