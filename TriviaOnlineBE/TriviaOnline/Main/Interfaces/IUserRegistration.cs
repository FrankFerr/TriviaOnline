using Main.Classes.UserRegistrationHelper;
using Shared.Response;

namespace Main.Interfaces
{
    public interface IUserRegistration
    {
        bool EmailExists(string email);
        void InitializeValidator();
        Response Validate(UserValidateBody body);
    }
}
