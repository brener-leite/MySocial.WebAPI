using MySocial.Domain.Entities;

namespace MySocial.Domain.Interfaces;
public interface IPostRepository
{
    Task<Post?> GetByIdAsync(Guid id);
    Task AddAsync(Post post);
    Task<IEnumerable<Post>> GetByUserIdAsync(Guid userId);
    Task<IEnumerable<Post>> GetAllAsync();
    Task DeleteAsync(Guid id);
}
