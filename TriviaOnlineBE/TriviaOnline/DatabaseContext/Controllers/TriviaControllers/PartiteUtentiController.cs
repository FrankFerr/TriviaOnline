using TriviaRepository.Context.TriviaModel;
using TriviaRepository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TriviaRepository.Controllers.TriviaControllers
{
    [Route("api/repository/[controller]")]
    [ApiController]
    public class PartiteUtentiController : StandardRepositoryController<PartiteUtenti>
    {
        public PartiteUtentiController(TriviaContext context, IStandardRepository<PartiteUtenti> repository) : base(context, repository)
        {
        }
    }
}
