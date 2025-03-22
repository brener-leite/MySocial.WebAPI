using MySocial.Domain.Entities;

namespace MySocial.Application.DTOs;
public class PostDto
{
    Guid Id { get; set; }
    string Content { get; set; }
    DateTime CreatedAt { get; set; }
    string AuthorName { get; set; }
    int CommentsCount { get; set; }

    public static explicit operator PostDto(Post post)
    {
        return new PostDto
        {
            Id = post.Id,
            Content = post.Content,
            CreatedAt = post.CreatedAt,
            AuthorName = post.User.Name,
            CommentsCount = post.Comments.Count
        };
    }
}
