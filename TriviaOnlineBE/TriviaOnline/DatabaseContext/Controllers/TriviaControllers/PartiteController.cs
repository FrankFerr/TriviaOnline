using TriviaRepository.Context.TriviaModel;
using TriviaRepository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TriviaRepository.Controllers.TriviaControllers
{
    [Route("api/repository/[controller]")]
    [ApiController]
    public class PartiteController : StandardRepositoryController<Partite>
    {
        public PartiteController(TriviaContext context, IStandardRepository<Partite> repository) : base(context, repository)
        {
        }
    }
}
