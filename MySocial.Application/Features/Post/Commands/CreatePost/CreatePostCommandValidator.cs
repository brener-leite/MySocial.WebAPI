using FluentValidation;

namespace MySocial.Application.Features.Post.Commands.CreatePost;
public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId é obrigatório");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Conteúdo do post é obrigatório")
            .MaximumLength(140).WithMessage("Conteúdo deve ter até 140 caracteres");
    }
}