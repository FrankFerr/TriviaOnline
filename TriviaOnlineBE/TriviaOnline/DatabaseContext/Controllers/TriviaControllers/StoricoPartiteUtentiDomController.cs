using TriviaRepository.Context.TriviaModel;
using Microsoft.AspNetCore.Mvc;
using Shared.ResponseModel;
using TriviaRepository.Services.Interfaces;
using Shared.ViewModel;

namespace TriviaRepository.Controllers.TriviaControllers
{
    [Route("api/repository/[controller]")]
    [ApiController]
    public class StoricoPartiteUtentiDomController : StandardRepositoryController<StoricoPartiteUtentiDom, StoricoPartiteUtentiDomVM>
    {
        public StoricoPartiteUtentiDomController(IStandardRepository<StoricoPartiteUtentiDom, StoricoPartiteUtentiDomVM> repository) : base(repository)
        {
        }

        [HttpPost]
        public override Task<ActionResult<Response>> InsertEntity(StoricoPartiteUtentiDomVM entity)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public override Task<ActionResult<Response>> UpdateEntity([FromBody] StoricoPartiteUtentiDomVM entity)
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
