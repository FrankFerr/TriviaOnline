using TriviaRepository.Context.TriviaModel;
using Microsoft.EntityFrameworkCore;
using Shared;
using static Shared.Constants;
using Shared.ResponseModel;
using System.Security.Cryptography;
using TriviaRepository.Services.Interfaces;
using AutoMapper;

namespace TriviaRepository.Services.Implementations
{
    public class StandardRepository<TModel, TViewModel> : IStandardRepository<TModel, TViewModel> where TModel : class where TViewModel : class
    {
        protected TriviaContext _context;
        private DbSet<TModel> _set;
        private readonly ILogger<StandardRepository<TModel, TViewModel>> _logger;
        private readonly IMapper _mapper;

        public StandardRepository(TriviaContext context, ILogger<StandardRepository<TModel, TViewModel>> logger, IMapper mapper)
        {
            _context = context;
            _set = _context.Set<TModel>();
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Response> GetAllAsync()
        {
            Response response = new();

            IEnumerable<TModel> values = await _set.ToListAsync();

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

            TModel? entity = await _set.FindAsync(oid);

            if (entity == null)
            {
                response.ResponseCode = EResponse.NOT_FOUND;
                response.Result = false;
                response.Message = "Record non trovato";
                _logger.LogInformation("DeleteAsync({0}) -> Record non trovato", oid);
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
                _logger.LogInformation("GetByOidAsync({0}) -> Record non trovato", oid);
            }

            return response;
        }

        public async Task<Response> InsertAsync(TViewModel entity)
        {
            Response response = new();

            TModel modelEntity = _mapper.Map<TModel>(entity);

            try
            {
                await _set.AddAsync(modelEntity);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException dbEx)
            {
                response.Result = false;
                response.ResponseCode = EResponse.EXISTS_RECORD;
                response.Message = dbEx.Message;
                _logger.LogInformation("InsertAsync({0}) -> Inserimento di un record esistente", modelEntity);
            }

            return response;
        }

        public async Task<Response> UpdateAsync(TViewModel entity)
        {
            Response response = new();

            TModel modelEntity = _mapper.Map<TModel>(entity);

            _set.Update(modelEntity);
            int affectedRows = await _context.SaveChangesAsync();

            if(affectedRows == 0)
            {
                response.Result = false;
                response.ResponseCode = EResponse.NOT_FOUND;
                response.Message = "Record non trovato";
                _logger.LogInformation("UpdateAsync({0}) -> Record non trovato", modelEntity);
            }

            return response;
        }
    }
}
