using TriviaRepository.Context.TriviaModel;
using TriviaRepository.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ResponseModel;
using TriviaRepository.Services.Implementations;
using Shared.ViewModel;

namespace TriviaRepository.Controllers.TriviaControllers
{
    [Route("api/repository/[controller]")]
    [ApiController]
    public class UtentiController : StandardRepositoryController<Utenti, UtentiVM>
    {
        private readonly UtentiRepository _utentiRepository;
        private readonly ILogger<UtentiController> _logger;

        public UtentiController(IStandardRepository<Utenti, UtentiVM> repository, ILogger<UtentiController> logger) : base(repository)
        {
            _utentiRepository = (UtentiRepository)repository;
            _logger = logger;
        }

        [HttpGet("email/{email}")]
        public ActionResult<Response> FindByEmail(string email)
        {
            _logger.LogInformation("TriviaRepository -> Utenti -> FindByEmail({email})", email);
            return Ok(_utentiRepository.FindByEmail(email));
        }

        [HttpGet("username/{username}")]
        public ActionResult<Response> FindByUsername(string username)
        {
            _logger.LogInformation("TriviaRepository -> Utenti -> FindByUsername({username})", username);
            return Ok(_utentiRepository.FindByUsername(username));
        }
    }
}
