using MediatR;

namespace MySocial.Application.Features.Post.Queries.GetAllPosts;
public record GetAllPostsQuery() : IRequest<IEnumerable<GetAllPostsQueryResponse>>;
