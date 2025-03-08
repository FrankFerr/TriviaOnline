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

        [HttpPost]
        public override Task<RepositoryResponse> InsertEntity(StoricoPartiteUtenti entity)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public override Task<RepositoryResponse> UpdateEntity([FromBody] StoricoPartiteUtenti entity)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{oid :decimal}")]
        public override Task<RepositoryResponse> DeleteEntity(decimal oid)
        {
            throw new NotImplementedException();
        }
    }
}
