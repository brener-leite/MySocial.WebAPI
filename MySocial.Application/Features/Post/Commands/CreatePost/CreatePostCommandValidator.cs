using FluentValidation;

namespace MySocial.Application.Features.Post.Commands.CreatePost;
public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User id is required");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Post content is required")
            .MaximumLength(140).WithMessage("Post content must be up to 140 characters long");
    }
}