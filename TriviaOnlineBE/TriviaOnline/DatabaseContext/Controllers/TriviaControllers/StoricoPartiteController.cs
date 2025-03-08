using TriviaRepository.Context.TriviaModel;
using TriviaRepository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace TriviaRepository.Controllers.TriviaControllers
{
    [Route("api/repository/[controller]")]
    [ApiController]
    public class StoricoPartiteController : StandardRepositoryController<StoricoPartite>
    {
        public StoricoPartiteController(TriviaContext context, IStandardRepository<StoricoPartite> repository) : base(context, repository)
        {
        }

        [HttpPost(Name = "Insert entity")]
        public new Task<RepositoryResponse> InsertEntity(StoricoPartite entity)
        {
            throw new NotImplementedException();
        }

        [HttpPut(Name = "Update entity")]
        public new Task<RepositoryResponse> UpdateEntity([FromBody] StoricoPartite entity)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{oid :decimal}", Name = "Delete entity")]
        public new Task<RepositoryResponse> DeleteEntity(decimal oid)
        {
            throw new NotImplementedException();
        }
    }
}
