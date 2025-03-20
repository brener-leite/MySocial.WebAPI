namespace MySocial.Application.Features.Comment.Commands.CreateComment;
public record CreateCommentCommandRequest(
    Guid PostId,
    Guid UserId,
    string Content
);
