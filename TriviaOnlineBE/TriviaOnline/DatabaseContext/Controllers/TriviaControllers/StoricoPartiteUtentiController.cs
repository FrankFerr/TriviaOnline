using TriviaRepository.Context.TriviaModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ResponseModel;
using TriviaRepository.Services.Interfaces;

namespace TriviaRepository.Controllers.TriviaControllers
{
    [Route("api/repository/[controller]")]
    [ApiController]
    public class StoricoPartiteUtentiController : StandardRepositoryController<StoricoPartiteUtenti>
    {
        public StoricoPartiteUtentiController(IStandardRepository<StoricoPartiteUtenti> repository) : base(repository)
        {
        }

        [HttpPost]
        public override Task<ActionResult<Response>> InsertEntity(StoricoPartiteUtenti entity)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public override Task<ActionResult<Response>> UpdateEntity([FromBody] StoricoPartiteUtenti entity)
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
