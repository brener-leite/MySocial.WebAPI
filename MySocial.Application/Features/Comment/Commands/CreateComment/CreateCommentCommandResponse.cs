namespace MySocial.Application.Features.Comment.Commands.CreateComment;
public record CreateCommentCommandResponse(
    string AuthorName,
    string Content
);
