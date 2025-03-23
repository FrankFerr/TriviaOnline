using Main.Classes.UserRegistrationHelper;
using Shared.ResponseModel;

namespace Main.Services.Interfaces
{
    public interface IUserRegistration
    {
        Task<Response> Register(UserValidateBody body);
    }
}
