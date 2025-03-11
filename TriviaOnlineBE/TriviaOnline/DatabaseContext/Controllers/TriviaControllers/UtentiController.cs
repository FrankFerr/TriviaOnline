using TriviaRepository.Context.TriviaModel;
using TriviaRepository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TriviaRepository.Controllers.TriviaControllers
{
    [Route("api/repository/[controller]")]
    [ApiController]
    public class UtentiController : StandardRepositoryController<Utenti>
    {
        public UtentiController(IStandardRepository<Utenti> repository) : base(repository)
        {
        }
    }
}
