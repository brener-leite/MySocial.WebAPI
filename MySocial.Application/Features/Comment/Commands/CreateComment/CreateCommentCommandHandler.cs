using MediatR;
using MySocial.Domain.Interfaces;
using CommentEntity = MySocial.Domain.Entities.Comment;

namespace MySocial.Application.Features.Comment.Commands.CreateComment;
public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Guid>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IPostRepository _postRepository;
    private readonly IUserRepository _userRepository;

    public CreateCommentCommandHandler(
        ICommentRepository commentRepository,
        IPostRepository postRepository,
        IUserRepository userRepository)
    {
        _commentRepository = commentRepository;
        _postRepository = postRepository;
        _userRepository = userRepository;
    }

    public async Task<Guid> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(request.PostId);
        if (post == null)
            throw new Exception("Post não encontrado");

        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user == null)
            throw new Exception("Usuário não encontrado");

        var comment = new CommentEntity(request.PostId, request.UserId, request.Content);
        await _commentRepository.AddAsync(comment);
        return comment.Id;
    }
}
