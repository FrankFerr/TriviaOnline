using TriviaRepository.Context.TriviaModel;
using TriviaRepository.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModel;

namespace TriviaRepository.Controllers.TriviaControllers
{
    [Route("api/repository/[controller]")]
    [ApiController]
    public class PartiteDomandeController : StandardRepositoryController<PartiteDomande, PartiteDomandeVM>
    {
        public PartiteDomandeController(IStandardRepository<PartiteDomande, PartiteDomandeVM> repository) : base(repository)
        {
        }
    }
}
