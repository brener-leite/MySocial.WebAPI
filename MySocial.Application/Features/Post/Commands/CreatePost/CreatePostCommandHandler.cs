using MediatR;
using MySocial.Domain.Exceptions;
using MySocial.Domain.Interfaces;
using PostEntity = MySocial.Domain.Entities.Post;

namespace MySocial.Application.Features.Post.Commands.CreatePost;
public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatePostCommandResponse>
{
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;

    public CreatePostCommandHandler(
        IPostRepository postRepository,
        IUserRepository userRepository)
    {
        _postRepository = postRepository;
        _userRepository = userRepository;
    }

    public async Task<CreatePostCommandResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId) ?? throw new NotFoundException("User not found");
        var post = new PostEntity(request.Content, user);
        await _postRepository.AddAsync(post);

        return new CreatePostCommandResponse(user.Name, post.Content);
    }
}