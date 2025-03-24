using FluentValidation;

namespace MySocial.Application.Features.User.Commands.CreateUser;
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("User name is required")
            .MaximumLength(100).WithMessage("User name must be up to 100 characters long");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("User email is required")
            .EmailAddress().WithMessage("Email format invalid");
    }
}
