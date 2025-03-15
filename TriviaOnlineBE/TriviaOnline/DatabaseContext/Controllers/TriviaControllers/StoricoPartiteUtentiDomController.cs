using TriviaRepository.Context.TriviaModel;
using Microsoft.AspNetCore.Mvc;
using Shared.ResponseModel;
using TriviaRepository.Services.Interfaces;

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
