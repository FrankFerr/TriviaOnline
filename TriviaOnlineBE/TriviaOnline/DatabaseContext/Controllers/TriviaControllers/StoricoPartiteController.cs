using TriviaRepository.Context.TriviaModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ResponseModel;
using TriviaRepository.Services.Interfaces;
using Shared.ViewModel;

namespace TriviaRepository.Controllers.TriviaControllers
{
    [Route("api/repository/[controller]")]
    [ApiController]
    public class StoricoPartiteController : StandardRepositoryController<StoricoPartite, StoricoPartiteVM>
    {
        public StoricoPartiteController(IStandardRepository<StoricoPartite, StoricoPartiteVM> repository) : base(repository)
        {
        }

        [HttpPost]
        public override Task<ActionResult<Response>> InsertEntity(StoricoPartiteVM entity)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public override Task<ActionResult<Response>> UpdateEntity([FromBody] StoricoPartiteVM entity)
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
