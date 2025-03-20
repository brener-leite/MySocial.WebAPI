using MediatR;

namespace MySocial.Application.Features.Comment.Commands.CreateComment;
public record CreateCommentCommand(
    Guid PostId,
    Guid UserId,
    string Content
) : IRequest<Guid>;
