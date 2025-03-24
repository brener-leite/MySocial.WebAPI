using MediatR;

namespace MySocial.Application.Features.Post.Queries.GetPostsByUserId;
public record GetPostsByUserIdQuery(Guid UserId) : IRequest<IEnumerable<GetPostsByUserIdQueryResponse>>;