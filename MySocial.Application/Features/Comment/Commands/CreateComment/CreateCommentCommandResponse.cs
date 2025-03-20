namespace MySocial.Application.Features.Comment.Commands.CreateComment;
public record CreateCommentCommandResponse(
    Guid Id,
    Guid PostId,
    string Content
);
