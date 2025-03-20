namespace MySocial.Domain.Entities;

public class Post
{
    public Guid Id { get; private set; }
    public string Content { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public bool IsDeleted { get; private set; }
    public User User { get; private set; }
    public Guid UserId { get; private set; }

    public Post(string content, User user)
    {
        Id = Guid.NewGuid();
        User = user;
        UserId = user.Id;
        Content = content;
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
