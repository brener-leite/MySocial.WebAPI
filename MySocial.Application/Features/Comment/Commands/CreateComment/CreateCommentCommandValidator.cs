using FluentValidation;

namespace MySocial.Application.Features.Comment.Commands.CreateComment;
public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(x => x.PostId)
            .NotEmpty().WithMessage("PostId é obrigatório");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId é obrigatório");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Conteúdo do comentário é obrigatório")
            .MaximumLength(200).WithMessage("Comentário deve ter até 200 caracteres");
    }
}

