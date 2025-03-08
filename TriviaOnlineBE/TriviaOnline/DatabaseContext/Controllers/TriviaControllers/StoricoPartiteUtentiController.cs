using TriviaRepository.Context.TriviaModel;
using TriviaRepository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace TriviaRepository.Controllers.TriviaControllers
{
    [Route("api/repository/[controller]")]
    [ApiController]
    public class StoricoPartiteUtentiController : StandardRepositoryController<StoricoPartiteUtenti>
    {
        public StoricoPartiteUtentiController(TriviaContext context, IStandardRepository<StoricoPartiteUtenti> repository) : base(context, repository)
        {
        }

        [HttpPost(Name = "Insert entity")]
        public new Task<RepositoryResponse> InsertEntity(StoricoPartiteUtenti entity)
        {
            throw new NotImplementedException();
        }

        [HttpPut(Name = "Update entity")]
        public new Task<RepositoryResponse> UpdateEntity([FromBody] StoricoPartiteUtenti entity)
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
