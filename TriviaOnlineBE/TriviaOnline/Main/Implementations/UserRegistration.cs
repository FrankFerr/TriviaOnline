using Main.Classes.UserRegistrationHelper;
using Main.Interfaces;
using Shared.Response;
using static Shared.Constants;

namespace Main.Implementations
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

        public void InitializeValidator()
        {
            _requireValidDel = UserFieldValidator.RequiredValidDel;
            _stringLengthValidDel = UserFieldValidator.StringLengthValidDel;
            _patternMatchingValidDel = UserFieldValidator.PatternMatchingValidDel;
        }

        public Response Validate(UserValidateBody body)
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
