namespace MySocial.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public string? Bio { get; private set; }
    public List<Post> Posts { get; private set; } = new();

    public User(string name, string email, string? bio = null)
    {
        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        Bio = bio;
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateProfile(string? name = null, string? bio = null)
    {
        if (!string.IsNullOrEmpty(name))
        {
            Name = name;
        }

        if (bio != null)
        {
            Bio = bio;
        }
    }
}
