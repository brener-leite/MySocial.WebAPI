namespace MySocial.Application.Features.Post.Commands.CreatePost;
public record CreatePostCommandRequest(
    string Content,
    Guid UserId
);
