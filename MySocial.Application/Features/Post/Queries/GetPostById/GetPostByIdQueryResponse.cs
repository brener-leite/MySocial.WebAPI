namespace MySocial.Application.Features.Post.Queries.GetPostById;
public record GetPostByIdQueryResponse(
    Guid Id,
    string Content,
    DateTime CreatedAt,
    string AuthorName,
    int CommentsCount
);
