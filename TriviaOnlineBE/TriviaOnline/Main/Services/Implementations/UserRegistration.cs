using Main.Classes.UserRegistrationHelper;
using Main.Services.Interfaces;
using Shared.ResponseModel;
using static Shared.Constants;

namespace Main.Services.Implementations
{
    public class UserRegistration : IUserRegistration
    {
        private static RequiredValidDel _requireValidDel = null!;
        private static StringLengthValidDel _stringLengthValidDel = null!;
        private static PatternMatchingValidDel _patternMatchingValidDel = null!;

        public UserRegistration()
        {
            InitializeValidator();
        }

        public bool EmailExists(string email)
        {
            //TODO
            return true;
        }

        private void InitializeValidator()
        {
            _requireValidDel = UserFieldValidator.RequiredValidDel;
            _stringLengthValidDel = UserFieldValidator.StringLengthValidDel;
            _patternMatchingValidDel = UserFieldValidator.PatternMatchingValidDel;
        }

        public Response Register(UserValidateBody body)
        {
            Response response = new();

            if (EmailExists(body.Email))
            {
                response.Result = false;
                response.ResponseCode = EResponse.EMAIL_ESISTENTE;
                return response;
            }

            //TODO

            return response;
        }
    }
}
