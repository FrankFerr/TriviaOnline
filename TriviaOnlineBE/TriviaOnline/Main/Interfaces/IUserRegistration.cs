using Shared;

namespace Main.Interfaces
{
    public interface IUserRegistration
    {
        bool EmailExists(string email);
        void InitializeValidator();
        UserRegitrationResponse Validate();
    }
}
