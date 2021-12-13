using InnoTech.LegosForLife.Security.IRepositories;
using InnoTech.LegosForLife.Security.IServices;
using InnoTech.LegosForLife.Security.Models;

namespace InnoTech.LegosForLife.Security.Services
{
    public class AuthUserService: IAuthUserService
    {
        private readonly IAuthUserRepository _authUserRepository;
        public AuthUserService(IAuthUserRepository authUserRepository)
        {
            _authUserRepository = authUserRepository;
        }
        public AuthUser GetUser(string username)
        {
            return _authUserRepository.FindUser(username);
        }

        public AuthUser Create(AuthUser authUser)
        {
            return _authUserRepository.Save(authUser);
        }
    }
}