namespace MySocial.Application.Features.Post.Commands.CreatePost;
public record CreatePostCommandResponse(
    string AuthorName,
    string Content
);
