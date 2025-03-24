namespace MySocial.Domain.Entities;

public class Comment
{
    public Guid Id { get; private set; }
    public string Content { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public bool IsDeleted { get; private set; }

    public Guid PostId { get; private set; }
    public Post Post { get; private set; }

    public Guid UserId { get; private set; }
    public User User { get; private set; }

    public Comment(string content, Post post, User user)
    {
        Id = Guid.NewGuid();
        Content = content;
        Post = post;
        PostId = post.Id;
        User = user;
        UserId = user.Id;
        CreatedAt = DateTime.UtcNow;
        IsDeleted = false;
    }

    public void UpdateContent(string content)
    {
        Content = content;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Delete()
    {
        IsDeleted = true;
    }
}
