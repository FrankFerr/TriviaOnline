using TriviaRepository.Context.TriviaModel;
using TriviaRepository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace TriviaRepository.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StandardRepositoryController<T> : ControllerBase where T : class
    {
        private TriviaContext _context;
        private IStandardRepository<T> _repository;

        public StandardRepositoryController(TriviaContext context, IStandardRepository<T> repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet]
        public async Task<RepositoryResponse> GetAll()
        {
            RepositoryResponse response = new();

            try
            {
                IEnumerable<T> values = await _repository.GetAllAsync();
                response.Data = values;
            }
            catch(Exception e)
            {
                response.Result = false;
                response.Message = e.Message;
            }

            return response;
        }

        [HttpGet("{oid:decimal}")]
        public async Task<RepositoryResponse> GetByOid(decimal oid)
        {
            RepositoryResponse response = new();

            try
            {
                T? entity = await _repository.GetByOidAsync(oid);
                
                if(entity == null)
                {
                    response.Result = false;
                    response.Message = Constants.ERepositoryResponse.NON_TROVATO.ToString();
                }

                response.Data = entity;
            }
            catch (Exception e)
            {
                response.Result = false;
                response.Message = e.Message;
            }

            return response;
        }

        [HttpPost]
        public virtual async Task<RepositoryResponse> InsertEntity([FromBody] T entity)
        {
            RepositoryResponse response = new();

            try
            {
                await _repository.InsertAsync(entity);
            }
            catch (Exception e)
            {
                response.Result = false;
                response.Message = e.Message;
            }

            return response;
        }

        [HttpPut]
        public virtual async Task<RepositoryResponse> UpdateEntity([FromBody] T entity)
        {
            RepositoryResponse response = new();

            try
            {
                await _repository.UpdateAsync(entity);
            }
            catch (Exception e)
            {
                response.Result = false;
                response.Message = e.Message;
            }

            return response;
        }

        [HttpDelete("{oid:decimal}")]
        public virtual async Task<RepositoryResponse> DeleteEntity(decimal oid)
        {
            RepositoryResponse response = new();

            try
            {
                await _repository.DeleteAsync(oid);
            }
            catch (Exception e)
            {
                response.Result = false;
                response.Message = e.Message;
            }

            return response;
        }
    }
}
