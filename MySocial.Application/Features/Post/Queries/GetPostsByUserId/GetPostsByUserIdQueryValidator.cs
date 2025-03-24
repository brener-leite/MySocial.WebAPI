using FluentValidation;

namespace MySocial.Application.Features.Post.Queries.GetPostsByUserId;
public class GetPostsByUserIdQueryValidator : AbstractValidator<GetPostsByUserIdQuery>
{
    public GetPostsByUserIdQueryValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .NotNull().WithMessage("UserId is required.");
    }
}
