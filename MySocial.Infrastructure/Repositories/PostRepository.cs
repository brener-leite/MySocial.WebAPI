using Microsoft.EntityFrameworkCore;
using MySocial.Domain.Entities;
using MySocial.Infrastructure.Data;

namespace MySocial.Infrastructure.Repositories;
internal class PostRepository
{
    private readonly AppDbContext _context;

    public PostRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Post?> GetByIdAsync(Guid id)
    {
        var post = await _context.Posts.FindAsync(id);
        return post;
    }
    public async Task AddAsync(Post post)
    {
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
    }
    public async Task<IEnumerable<Post>> GetByUserIdAsync(Guid userId)
    {
        var posts = await _context.Posts.Where(p => p.UserId == userId).ToListAsync();
        return posts;
    }
    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        var posts = await _context.Posts.ToListAsync();
        return posts;
    }
    public async Task DeleteAsync(Guid id)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id) ?? throw new Exception($"Post with ID {id} not found");

        post.Delete();
        await _context.SaveChangesAsync();
    }
}
