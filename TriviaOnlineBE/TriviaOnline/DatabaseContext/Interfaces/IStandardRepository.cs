using static Shared.Constants;

namespace TriviaRepository.Interfaces
{
    public interface IStandardRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T?> GetByOidAsync(decimal oid);
        public Task UpdateAsync(T entity);
        public Task InsertAsync(T entity);
        public Task DeleteAsync(decimal oid);
    }
}
