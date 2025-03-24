namespace MySocial.Application.Features.Post.Queries.GetAllPosts;
public record GetAllPostsQueryResponse(
    Guid Id,
    string Content,
    DateTime CreatedAt,
    string AuthorName,
    int CommentsCount);
