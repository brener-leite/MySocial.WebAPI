namespace MySocial.Application.Features.Post.Commands.CreatePost;
public record CreatePostCommandResponse(
    Guid Id,
    string Content,
    Guid UserId
);
