using TriviaRepository.Context.TriviaModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ResponseModel;
using TriviaRepository.Services.Interfaces;

namespace TriviaRepository.Controllers.TriviaControllers
{
    //[Route("api/repository/[controller]")]
    //[ApiController]
    //public class StoricoPartiteController : StandardRepositoryController<StoricoPartite>
    //{
    //    public StoricoPartiteController(IStandardRepository<StoricoPartite> repository) : base(repository)
    //    {
    //    }

    //    [HttpPost]
    //    public override Task<ActionResult<Response>> InsertEntity(StoricoPartite entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    [HttpPut]
    //    public override Task<ActionResult<Response>> UpdateEntity([FromBody] StoricoPartite entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    [HttpDelete("{oid:decimal}")]
    //    public override Task<ActionResult<Response>> DeleteEntity(decimal oid)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
