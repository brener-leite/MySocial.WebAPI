using MySocial.Domain.Entities;

namespace MySocial.Application.DTOs;
public class PostDto
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public string AuthorName { get; set; }
    public int CommentsCount { get; set; }

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
