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
        private readonly ILogger<StandardRepository<T>> _logger;

        public StandardRepository(TriviaContext context, ILogger<StandardRepository<T>> logger)
        {
            _context = context;
            _set = _context.Set<T>();
            _logger = logger;
        }

        public async Task<Response> GetAllAsync()
        {
            Response response = new();

            IEnumerable<T> values = await _set.ToListAsync();

            if (values.Count() == 0)
            {
                response.Result = false;
                response.ResponseCode = EResponse.NOT_FOUND;
                response.Message = "Nessun elemento trovato!";
                _logger.LogInformation("GetAllAsync() -> Nessun elemento trovato");
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
                response.Message = "Record non trovato";
                _logger.LogInformation("DeleteAsync() -> Record non trovato");
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
                response.Message = "Record non trovato";
                _logger.LogInformation("GetByOidAsync() -> Record non trovato");
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
                _logger.LogInformation("InsertAsync() -> Inserimento di un record esistente");
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
                response.Message = "Record non trovato";
                _logger.LogInformation("UpdateAsync() -> Record non trovato");
            }

            return response;
        }
    }
}
