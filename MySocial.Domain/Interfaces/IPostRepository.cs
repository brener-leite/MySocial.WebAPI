using MySocial.Domain.Entities;

namespace MySocial.Domain.Interfaces;
public interface IPostRepository
{
    Task<Post?> GetByIdAsync(Guid id);
    Task<IEnumerable<Post>> GetByUserIdAsync(Guid userId);
    Task<IEnumerable<Post>> GetAllAsync();
    Task AddAsync(Post post);
    Task DeleteAsync(Guid id);
}
