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

        [HttpPost(Name = "Insert entity")]
        public new Task<RepositoryResponse> InsertEntity(StoricoPartiteUtentiDom entity)
        {
            throw new NotImplementedException();
        }

        [HttpPut(Name = "Update entity")]
        public new Task<RepositoryResponse> UpdateEntity([FromBody] StoricoPartiteUtentiDom entity)
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
