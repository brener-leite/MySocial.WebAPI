using MediatR;

namespace MySocial.Application.Features.Post.Commands.CreatePost;
public record CreatePostCommand(
    Guid UserId,
    string Content
) : IRequest<Guid>;