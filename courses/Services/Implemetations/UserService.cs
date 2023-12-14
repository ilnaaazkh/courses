using courses.Interfaces;
using courses.Services.Interfaces;
using courses.ViewModels;

namespace courses.Services.Implemetations
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository usersRepository;

        public UserService(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public bool Login(LoginViewModel model)
        {
            throw new NotImplementedException();
        }

        public bool LogOut()
        {
            throw new NotImplementedException();
        }

        public bool Register(RegistrationViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
