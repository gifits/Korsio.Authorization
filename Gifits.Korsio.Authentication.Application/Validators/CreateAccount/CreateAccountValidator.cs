using FluentValidation;
using Gifits.Korsio.Authorization.Application.Contracts.UserRepository;
using Gifits.Korsio.Authorization.Application.Dto.Athentication.RegisterUser;

namespace Gifits.Korsio.Authorization.Application.Validators.CreateAccount
{
    public class CreateAccountValidator : AbstractValidator<RegisterUserRequest>
    {
        public CreateAccountValidator(IUserRepository userRepository) 
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Wrong email format.")
                .MustAsync(async (email, cancellation) =>
                    !await userRepository.UserEmailExists(email))
                .WithMessage("There is already a user with that email.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required.");
        }
    }
}
