namespace MySocial.Application.Features.Post.Queries.GetPostsByUserId;
public record GetPostsByUserIdQueryResponse(
    Guid Id, 
    string Content, 
    DateTime CreatedAt,
    string AuthorName,
    int CommentsCount);
