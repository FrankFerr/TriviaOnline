using TriviaRepository.Context.TriviaModel;
using TriviaRepository.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ViewModel;

namespace TriviaRepository.Controllers.TriviaControllers
{
    [Route("api/repository/[controller]")]
    [ApiController]
    public class PartiteController : StandardRepositoryController<Partite, PartiteVM>
    {
        public PartiteController(IStandardRepository<Partite, PartiteVM> repository) : base(repository)
        {
        }
    }
}
