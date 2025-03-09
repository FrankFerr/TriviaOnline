using Main.Classes.UserRegistrationHelper;
using Main.Interfaces;
using Shared;

namespace Main.Classes
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
            throw new NotImplementedException();
        }

        public void InitializeValidator()
        {
            _requireValidDel = UserFieldValidator.RequiredValidDel;
            _stringLengthValidDel = UserFieldValidator.StringLengthValidDel;
            _patternMatchingValidDel = UserFieldValidator.PatternMatchingValidDel;
        }

        UserRegitrationResponse Validate()
        {
            throw new NotImplementedException();
        }
    }
}
