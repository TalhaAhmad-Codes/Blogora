namespace Blogoria.Repositories.Interfaces
{
    public interface IGeneralRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T user);
        Task UpdateAsync(T user);
        Task RemoveAsync(T user);
    }
}
