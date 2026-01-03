using Blogoria.Models.Entities;

namespace Blogoria.Repositories.Interfaces
{
    public interface IBlogRepository
    {
        Task<Blog?> GetByIdAsync(int id);
        Task<IReadOnlyList<Blog>> GetByAuthorIdAsync(int authorId);

        Task AddAsync(Blog blog);
        Task UpdateAsync(Blog blog);
        Task RemoveAsync(Blog blog);
    }
}
