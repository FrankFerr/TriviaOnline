using TriviaRepository.Context.TriviaModel;
using TriviaRepository.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModel;

namespace TriviaRepository.Controllers.TriviaControllers
{
    [Route("api/repository/[controller]")]
    [ApiController]
    public class PartiteUtentiController : StandardRepositoryController<PartiteUtenti, PartiteUtentiVM>
    {
        public PartiteUtentiController(IStandardRepository<PartiteUtenti, PartiteUtentiVM> repository) : base(repository)
        {
        }
    }
}
