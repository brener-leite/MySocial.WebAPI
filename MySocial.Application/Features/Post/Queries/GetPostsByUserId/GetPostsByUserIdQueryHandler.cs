using MediatR;
using MySocial.Application.DTOs;
using MySocial.Domain.Interfaces;

namespace MySocial.Application.Features.Post.Queries.GetPostsByUserId;
public class GetPostsByUserIdQueryHandler : IRequestHandler<GetPostsByUserIdQuery, IEnumerable<GetPostsByUserIdQueryResponse>>
{
    private readonly IPostRepository _postRepository;
    public GetPostsByUserIdQueryHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<IEnumerable<GetPostsByUserIdQueryResponse>> Handle(GetPostsByUserIdQuery request, CancellationToken cancellationToken)
    {
        var posts = await _postRepository.GetByUserIdAsync(request.UserId);
        return posts.Select(PostDto.FromEntity)
            .Select(d => new GetPostsByUserIdQueryResponse(
                d.Id,
                d.Content,
                d.CreatedAt,
                d.AuthorName,
                d.CommentsCount))
            .ToList();
    }
}
