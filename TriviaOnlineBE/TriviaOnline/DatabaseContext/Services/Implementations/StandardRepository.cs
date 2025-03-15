using TriviaRepository.Context.TriviaModel;
using Microsoft.EntityFrameworkCore;
using Shared;
using static Shared.Constants;
using Shared.ResponseModel;
using System.Security.Cryptography;
using TriviaRepository.Services.Interfaces;

namespace TriviaRepository.Services.Implementations
{
    public class StandardRepository<T> : IStandardRepository<T> where T : class
    {
        protected TriviaContext _context;
        private DbSet<T> _set;

        public StandardRepository(TriviaContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public async Task<Response> GetAllAsync()
        {
            Response response = new();

            IEnumerable<T> values = await _set.ToListAsync();

            if (values.Count() == 0)
            {
                response.Result = false;
                response.ResponseCode = EResponse.NOT_FOUND;
            }

            response.Data = values;

            return response;
        }

        public async Task<Response> DeleteAsync(decimal oid)
        {
            Response response = new();

            T? entity = await _set.FindAsync(oid);

            if (entity == null)
            {
                response.ResponseCode = EResponse.NOT_FOUND;
                response.Result = false;
                return response;
            }
            
            _set.Remove(entity);
            await _context.SaveChangesAsync();

            return response;
        }

        public async Task<Response> GetByOidAsync(decimal oid)
        {
            Response response = new();
            
            response.Data =  await _set.FindAsync(oid);

            if(response.Data == null)
            {
                response.Result = false;
                response.ResponseCode = EResponse.NOT_FOUND;
            }

            return response;
        }

        public async Task<Response> InsertAsync(T entity)
        {
            Response response = new();

            try
            {
                await _set.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException dbEx)
            {
                response.Result = false;
                response.ResponseCode = EResponse.EXISTS_RECORD;
                response.Message = dbEx.Message;
            }

            return response;
        }

        public async Task<Response> UpdateAsync(T entity)
        {
            Response response = new();

            _set.Update(entity);
            int affectedRows = await _context.SaveChangesAsync();

            if(affectedRows == 0)
            {
                response.Result = false;
                response.ResponseCode = EResponse.NOT_FOUND;
            }

            return response;
        }
    }
}
