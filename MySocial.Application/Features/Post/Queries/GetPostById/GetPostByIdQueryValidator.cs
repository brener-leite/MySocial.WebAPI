using FluentValidation;

namespace MySocial.Application.Features.Post.Queries.GetPostById;
public class GetPostByIdQueryValidator : AbstractValidator<GetPostByIdQuery>
{
    public GetPostByIdQueryValidator()
    {
        RuleFor(x => x.PostId).NotEmpty();
    }
}
