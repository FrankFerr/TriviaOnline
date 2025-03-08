using TriviaRepository.Context.TriviaModel;
using TriviaRepository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace TriviaRepository.Controllers.TriviaControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoricoPartiteUtentiDomController : StandardRepositoryController<StoricoPartiteUtentiDom>
    {
        public StoricoPartiteUtentiDomController(TriviaContext context, IStandardRepository<StoricoPartiteUtentiDom> repository) : base(context, repository)
        {
        }

        [HttpPost]
        public override Task<RepositoryResponse> InsertEntity(StoricoPartiteUtentiDom entity)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public override Task<RepositoryResponse> UpdateEntity([FromBody] StoricoPartiteUtentiDom entity)
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
