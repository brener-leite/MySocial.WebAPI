using MediatR;
using MySocial.Application.DTOs;
using MySocial.Domain.Interfaces;

namespace MySocial.Application.Features.Post.Queries.GetAllPosts;
public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, IEnumerable<GetAllPostsQueryResponse>>
{
    private readonly IPostRepository _postRepository;
    public GetAllPostsQueryHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<IEnumerable<GetAllPostsQueryResponse>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        var posts = await _postRepository.GetAllAsync();
        return posts.Select(PostDto.FromEntity)
            .Select(d => new GetAllPostsQueryResponse(
                d.Id,
                d.Content,
                d.CreatedAt,
                d.AuthorName,
                d.CommentsCount))
            .ToList();
    }
}
