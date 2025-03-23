using TriviaRepository.Context.TriviaModel;
using TriviaRepository.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModel;

namespace TriviaRepository.Controllers.TriviaControllers
{
    [Route("api/repository/[controller]")]
    [ApiController]
    public class PartiteUtentiRisposteController : StandardRepositoryController<PartiteUtentiRisposte, PartiteUtentiRisposteVM>
    {
        public PartiteUtentiRisposteController(IStandardRepository<PartiteUtentiRisposte, PartiteUtentiRisposteVM> repository) : base(repository)
        {
        }
    }
}
