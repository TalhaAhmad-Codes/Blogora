using Blogoria.Models.Entities;

namespace Blogoria.Repositories.Interfaces
{
    public interface IBlogRepository : IGeneralRepository<Blog>
    {
        Task<IReadOnlyList<Blog>> GetByAuthorIdAsync(int authorId);
    }
}
