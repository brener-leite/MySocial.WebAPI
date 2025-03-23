using Microsoft.EntityFrameworkCore;
using MySocial.Domain.Entities;
using MySocial.Domain.Exceptions;
using MySocial.Domain.Interfaces;
using MySocial.Infrastructure.Data;

namespace MySocial.Infrastructure.Repositories;
public class PostRepository : IPostRepository
{
    private readonly AppDbContext _context;

    public PostRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Post?> GetByIdAsync(Guid id)
    {
        return await _context.Posts
            .Include(p => p.User)
            .Include(p => p.Comments)
            .Where(p => !p.IsDeleted)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
    public async Task<IEnumerable<Post>> GetByUserIdAsync(Guid userId)
    {
        return await _context.Posts
            .Include(p => p.User)
            .Include(p => p.Comments)
            .Where(p => p.UserId == userId && !p.IsDeleted)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
    }
    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        return await _context.Posts
            .Include(p => p.User)
            .Include(p => p.Comments)
            .Where(p => !p.IsDeleted)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
    }
    public async Task AddAsync(Post post)
    {
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(Guid id)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id) ?? throw new NotFoundException($"Post with ID {id} not found");

        post.Delete();
        await _context.SaveChangesAsync();
    }
}
