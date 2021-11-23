using InnoTech.LegosForLife.Security.IRepositories;
using InnoTech.LegosForLife.Security.IServices;
using InnoTech.LegosForLife.Security.Models;
using InnoTech.LegosForLife.Security.Reposities;

namespace InnoTech.LegosForLife.Security.Services
{
    public class AuthUserService: IAuthUserService
    {
        private readonly IAuthUserRepository _authUserRepository;

        public AuthUserService(IAuthUserRepository authUserRepository)
        {
            _authUserRepository = authUserRepository;
        }
        public AuthUser Login(string username, string password)
        {
            return _authUserRepository.FindByUsernameAndPassword(username, password);
        }
    }
}