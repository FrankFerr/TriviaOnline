﻿using AutoMapper;
using Shared.ResponseModel;
using Shared.ViewModel;
using TriviaRepository.Context.TriviaModel;

namespace TriviaRepository.Services.Implementations
{
    public class UtentiRepository : StandardRepository<Utenti, UtentiVM>
    {
        public UtentiRepository(TriviaContext context, ILogger<UtentiRepository> logger, IMapper mapper) : base(context, logger, mapper)
        {
        }

        public Response FindByEmail(string email)
        {
            Response response = new();

            response.Data = _context.Utenti.Where(u => u.IdEmail == email).FirstOrDefault();

            if(response.Data == null)
            {
                response.Result = false;
                response.ResponseCode = Shared.Constants.EResponse.USER_NOT_FOUND;
            }

            return response;
        }

        public Response FindByUsername(string username)
        {
            Response response = new();

            response.Data = _context.Utenti.Where(u => u.IdUsername == username).FirstOrDefault();

            if (response.Data == null)
            {
                response.Result = false;
                response.ResponseCode = Shared.Constants.EResponse.USER_NOT_FOUND;
            }

            return response;
        }
    }
}
