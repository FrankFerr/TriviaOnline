﻿using TriviaRepository.Context.TriviaModel;
using TriviaRepository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TriviaRepository.Controllers.TriviaControllers
{
    [Route("api/repository/[controller]")]
    [ApiController]
    public class DomandeRisposteController : StandardRepositoryController<DomandeRisposte>
    {
        public DomandeRisposteController(TriviaContext context, IStandardRepository<DomandeRisposte> repository) : base(context, repository)
        {
        }
    }
}
