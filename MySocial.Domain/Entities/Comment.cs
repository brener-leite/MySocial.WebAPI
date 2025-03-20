namespace MySocial.Domain.Entities;

public class Comment
{
    public Guid Id { get; private set; }
    public Guid PostId { get; private set; }
    public Guid UserId { get; private set; }
    public string Content { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public Comment(Guid postId, Guid userId, string content)
    {
        Id = Guid.NewGuid();
        PostId = postId;
        UserId = userId;
        Content = content;
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateContent(string content)
    {
        Content = content;
        UpdatedAt = DateTime.UtcNow;
    }
}
