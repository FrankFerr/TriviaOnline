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

        [HttpPost]
        public override Task<RepositoryResponse> InsertEntity(StoricoPartite entity)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public override Task<RepositoryResponse> UpdateEntity([FromBody] StoricoPartite entity)
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
