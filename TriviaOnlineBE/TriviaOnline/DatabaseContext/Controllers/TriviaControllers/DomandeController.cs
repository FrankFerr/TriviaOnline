using TriviaRepository.Context.TriviaModel;
using TriviaRepository.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModel;

namespace TriviaRepository.Controllers.TriviaControllers
{
    [Route("api/repository/[controller]")]
    [ApiController]
    public class DomandeController : StandardRepositoryController<Domande, DomandeVM>
    {
        public DomandeController(IStandardRepository<Domande, DomandeVM> repository) : base(repository)
        {
        }
    }
}
