using Main.Classes.UserRegistrationHelper;
using Shared.ResponseModel;

namespace Main.Services.Interfaces
{
    public interface IUserRegistration
    {
        bool EmailExists(string email);
        Response Register(UserValidateBody body);
    }
}
