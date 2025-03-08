using TriviaRepository.Context.TriviaModel;
using TriviaRepository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shared;
using static Shared.Constants;

namespace TriviaRepository.Services
{
    public class StandardRepository<T> : IStandardRepository<T> where T : class
    {
        private TriviaContext _context;
        private DbSet<T> _set;

        StandardRepository(TriviaContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _set.ToListAsync();
        }

        public async Task DeleteAsync(decimal oid)
        {
            T? entity = await _set.FindAsync(oid);

            if (entity == null)
                throw new Exception(ERepositoryResponse.NON_TROVATO.ToString());
            
            _set.Remove(entity);
            await _context.SaveChangesAsync();
            
        }

        public async Task<T?> GetByOidAsync(decimal oid)
        {
            return await _set.FindAsync(oid);
        }

        public async Task InsertAsync(T entity)
        {
            await _set.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _set.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
