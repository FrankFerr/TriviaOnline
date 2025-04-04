﻿using TriviaRepository.Context.TriviaModel;
using TriviaRepository.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.ResponseModel;
using static Shared.Constants;

namespace TriviaRepository.Controllers
{
    [ApiController]
    public class StandardRepositoryController<TModel, TViewModel> : ControllerBase where TModel : class where TViewModel : class
    {
        protected IStandardRepository<TModel, TViewModel> _repository;

        public StandardRepositoryController(IStandardRepository<TModel, TViewModel> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<Response>> GetAll()
        {
            Response response = await _repository.GetAllAsync();

            return Ok(response);
        }

        [HttpGet("{oid:decimal}")]
        public async Task<ActionResult<Response>> GetByOid(decimal oid)
        {
            Response response = await _repository.GetByOidAsync(oid);
            
            return Ok(response);
        }

        [HttpPost]
        public virtual async Task<ActionResult<Response>> InsertEntity([FromBody] TViewModel entity)
        {
            Response response = await _repository.InsertAsync(entity);

            if (response.ResponseCode == EResponse.EXISTS_RECORD)
                return BadRequest(response);
            
            return Created("", response);
        }

        [HttpPut]
        public virtual async Task<ActionResult<Response>> UpdateEntity([FromBody] TViewModel entity)
        {
            Response response = await _repository.UpdateAsync(entity);

            if (response.ResponseCode == EResponse.NOT_FOUND)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("{oid:decimal}")]
        public virtual async Task<ActionResult<Response>> DeleteEntity(decimal oid)
        {
            Response response = await _repository.DeleteAsync(oid);

            if (response.ResponseCode == EResponse.NOT_FOUND)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
