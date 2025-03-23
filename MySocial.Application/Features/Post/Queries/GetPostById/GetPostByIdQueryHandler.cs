using MediatR;
using MySocial.Application.DTOs;
using MySocial.Domain.Exceptions;
using MySocial.Domain.Interfaces;

namespace MySocial.Application.Features.Post.Queries.GetPostById;
public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, GetPostByIdQueryResponse>
{
    private readonly IPostRepository _postRepository;

    public GetPostByIdQueryHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<GetPostByIdQueryResponse> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(request.PostId) ?? throw new NotFoundException($"Post {request.PostId} not found");

        var dto = PostDto.FromEntity(post);

        return new GetPostByIdQueryResponse(
            dto.Id,
            dto.Content,
            dto.CreatedAt,
            dto.AuthorName,
            dto.CommentsCount
        );
    }
}
