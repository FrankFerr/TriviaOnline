using TriviaRepository.Context.TriviaModel;
using TriviaRepository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Response;

namespace TriviaRepository.Controllers.TriviaControllers
{
    [Route("api/repository/[controller]")]
    [ApiController]
    public class StoricoPartiteUtentiDomController : StandardRepositoryController<StoricoPartiteUtentiDom>
    {
        public StoricoPartiteUtentiDomController(IStandardRepository<StoricoPartiteUtentiDom> repository) : base(repository)
        {
        }

        [HttpPost]
        public override Task<ActionResult<Response>> InsertEntity(StoricoPartiteUtentiDom entity)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public override Task<ActionResult<Response>> UpdateEntity([FromBody] StoricoPartiteUtentiDom entity)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{oid:decimal}")]
        public override Task<ActionResult<Response>> DeleteEntity(decimal oid)
        {
            throw new NotImplementedException();
        }
    }
}
