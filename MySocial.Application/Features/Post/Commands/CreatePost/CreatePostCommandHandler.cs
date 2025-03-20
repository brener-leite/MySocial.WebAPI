using MediatR;
using MySocial.Domain.Interfaces;
using PostEntity = MySocial.Domain.Entities.Post;

namespace MySocial.Application.Features.Post.Commands.CreatePost;
public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
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

    public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
            throw new Exception("Usuário não encontrado");

        var post = new PostEntity(request.UserId, request.Content);
        await _postRepository.AddAsync(post);
        return post.Id;
    }
}