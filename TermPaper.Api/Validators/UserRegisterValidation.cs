using FluentValidation;
using TermPaper.Api.Requests;

namespace TermPaper.Api.Validators
{
    public class UserRegisterValidation : AbstractValidator<UserRegisterRequest>
    {
        public UserRegisterValidation()
        {
            RuleFor(u => u.UserName).NotEmpty()
                                    .NotNull();

            RuleFor(u => u.Password).NotEmpty()
                                    .NotNull();

            RuleFor(u => u.PasswordConfirm).NotNull()
                                           .NotEmpty()
                                           .Equal(u => u.Password);

            RuleFor(u => u.FirstName).NotNull()
                                     .NotEmpty()
                                     .MaximumLength(50);

            RuleFor(u => u.LastName).NotNull()
                                    .NotEmpty()
                                    .MaximumLength(50);

            RuleFor(u => u.Email).NotNull()
                                 .NotEmpty()
                                 .EmailAddress();

            RuleFor(u => u.PhoneNumber).NotNull()
                                       .NotEmpty();
        }
    }
}
