using MySocial.Domain.Entities;

namespace MySocial.Domain.Interfaces;
public interface ICommentRepository
{
    Task AddAsync(Comment comment);
    Task<IEnumerable<Comment>> GetByPostIdAsync(Guid postId);
    Task DeleteAsync(Guid id);
}
