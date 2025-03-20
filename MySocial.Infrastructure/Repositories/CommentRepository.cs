using Microsoft.EntityFrameworkCore;
using MySocial.Domain.Entities;
using MySocial.Domain.Interfaces;
using MySocial.Infrastructure.Data;

namespace MySocial.Infrastructure.Repositories;
public class CommentRepository : ICommentRepository
{
    private readonly AppDbContext _context;

    public CommentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Comment comment)
    {
        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
    }

    public async Task<Comment?> GetByIdAsync(Guid id)
    {
        return await _context.Comments.FindAsync(id);
    }

    public async Task<IEnumerable<Comment>> GetByPostIdAsync(Guid postId)
    {
        return await _context.Comments.Where(c => c.PostId == postId).ToListAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var comment = await GetByIdAsync(id);
        if (comment is null) return;

        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
    }
}
