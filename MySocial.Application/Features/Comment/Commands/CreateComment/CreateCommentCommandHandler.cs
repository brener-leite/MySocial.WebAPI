using MediatR;
using MySocial.Domain.Exceptions;
using MySocial.Domain.Interfaces;
using CommentEntity = MySocial.Domain.Entities.Comment;

namespace MySocial.Application.Features.Comment.Commands.CreateComment;
public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CreateCommentCommandResponse>
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

    public async Task<CreateCommentCommandResponse> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId) ?? throw new NotFoundException("User not found");
        var post = await _postRepository.GetByIdAsync(request.PostId) ?? throw new NotFoundException("Post not found");

        var comment = new CommentEntity(request.Content, user, post);
        await _commentRepository.AddAsync(comment);

        return new CreateCommentCommandResponse(user.Name, post.Content);
    }
}
