﻿using Main.Classes.UserRegistrationHelper;
using Main.Services.Interfaces;
using Shared.RequestConfigManager;
using Shared.RequestManager;
using Shared.RequestModel;
using Shared.ResponseModel;
using Shared.ViewModel;
using static Shared.Constants;

namespace Main.Services.Implementations
{
    public class UserRegistration : IUserRegistration
    {
        private static RequiredValidDel _requireValidDel = null!;
        private static StringLengthValidDel _stringLengthValidDel = null!;
        private static PatternMatchingValidDel _patternMatchingValidDel = null!;
        private readonly IRequestManager _requestManager;
        private readonly IRequestConfigManager _requestConfigManager;
        private readonly ILogger<UserRegistration> _logger;
        private int usernameMinChar = 3, usernameMaxChar = 30;

        public UserRegistration(IRequestManager requestManager, IRequestConfigManager requestConfigManager, ILogger<UserRegistration> logger)
        {
            _requestManager = requestManager;
            _requestConfigManager = requestConfigManager;
            _logger = logger;
            InitializeValidator();
        }

        public async Task<Response> Register(UserValidateBody body)
        {
            _logger.LogInformation($"Users Service -> Register({body})");

            Response response = new();

            // Validazioni campi
            if(!(_requireValidDel(body.Email) || _requireValidDel(body.Username) || _requireValidDel(body.Password)))
            {
                _logger.LogWarning("Campi obbligatori non trovati {body}", body);
                response.Result = false;
                response.ResponseCode = EResponse.REQUIRED_FIELD_NOT_FOUND;
                response.Message = "Campi obbligatori non trovati";
                return response;
            }

            // USERNAME
            if(!_stringLengthValidDel(body.Username, usernameMinChar, usernameMaxChar))
            {
                _logger.LogWarning("Username non valido: {username}", body.Username);
                response.Result = false;
                response.ResponseCode = EResponse.USERNAME_NOT_VALID;
                response.Message = "Username non valido";
                return response;
            }

            if (await UsernameExists(body.Username))
            {
                _logger.LogWarning("Username esistente: {username}", body.Username);
                response.Result = false;
                response.ResponseCode = EResponse.EXISTS_USERNAME;
                response.Message = "Username esistente";
                return response;
            }

            // EMAIL
            if (!_patternMatchingValidDel(body.Email, UserRegexValidator.EMAIL_PATTERN))
            {
                _logger.LogWarning("Email non valida: {email}", body.Email);
                response.Result = false;
                response.ResponseCode = EResponse.EMAIL_NOT_VALID;
                response.Message = "Email non valida";
                return response;
            }

            if (await EmailExists(body.Email))
            {
                _logger.LogWarning("Email esistente: {email}", body.Email);
                response.Result = false;
                response.ResponseCode = EResponse.EXISTS_EMAIL;
                response.Message = "Email esistente";
                return response;
            }

            //PASSWORD
            if (!_patternMatchingValidDel(body.Password, UserRegexValidator.PASSWORD_PATTERN))
            {
                _logger.LogWarning("Password non valida: {password}", body.Password);
                response.Result = false;
                response.ResponseCode = EResponse.PASSWORD_NOT_VALID;
                response.Message = "Password non valida";
                return response;
            }


            //Registrazione sull'Identity Server
            // TODO

            UtentiVM user = new UtentiVM()
            {
                ExternalId = Guid.NewGuid().ToString(), // da sostituire con l'id dell'Identity server
                IdUsername = body.Username,
                IdEmail = body.Email
            };

            RequestConfig requestConfig = await _requestConfigManager.Get("InsertUser");

            response = await _requestManager.Execute(requestConfig, user);

            if (response.Result)
                _logger.LogInformation("Utente {0} registrato con successo", user.IdUsername);
            else
                _logger.LogInformation("Utente {0} non registrato: {1}", user.IdUsername, response.Message);


            return response;
        }
        
        private void InitializeValidator()
        {
            _requireValidDel = UserFieldValidator.RequiredValidDel;
            _stringLengthValidDel = UserFieldValidator.StringLengthValidDel;
            _patternMatchingValidDel = UserFieldValidator.PatternMatchingValidDel;
        }

        private async Task<bool> EmailExists(string email)
        {
            RequestConfig requestConfig = await _requestConfigManager.Get("CheckEmail");

            _requestManager.AddParameters(new Shared.RequestParameter()
            {
                Key = "email",
                Value = email,
                Type = ParametersType.PATH
            });

            Response resp = await _requestManager.Execute(requestConfig);

            return resp.Result;
        }

        private async Task<bool> UsernameExists(string username)
        {
            RequestConfig requestConfig = await _requestConfigManager.Get("CheckUsername");

            _requestManager.AddParameters(new Shared.RequestParameter()
            {
                Key = "username",
                Value = username,
                Type = ParametersType.PATH
            });

            Response resp = await _requestManager.Execute(requestConfig);

            return resp.Result;
        }

    }
}
