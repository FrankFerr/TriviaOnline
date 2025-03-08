﻿using TriviaRepository.Context.TriviaModel;
using TriviaRepository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TriviaRepository.Controllers.TriviaControllers
{
    [Route("api/repository/[controller]")]
    [ApiController]
    public class PartiteDomandeController : StandardRepositoryController<PartiteDomande>
    {
        public PartiteDomandeController(TriviaContext context, IStandardRepository<PartiteDomande> repository) : base(context, repository)
        {
        }
    }
}
