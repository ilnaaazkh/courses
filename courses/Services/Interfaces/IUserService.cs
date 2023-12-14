using courses.ViewModels;

namespace courses.Services.Interfaces
{
    public interface IUserService
    {
        public bool Login(LoginViewModel model);
        public bool Register(RegistrationViewModel model);

        public bool LogOut();
    }
}
