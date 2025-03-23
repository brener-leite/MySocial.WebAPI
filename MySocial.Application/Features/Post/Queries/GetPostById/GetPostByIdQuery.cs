using MediatR;

namespace MySocial.Application.Features.Post.Queries.GetPostById;
public record GetPostByIdQuery(
    Guid PostId
) : IRequest<GetPostByIdQueryResponse>;
