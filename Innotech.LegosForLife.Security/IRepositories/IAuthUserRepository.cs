using InnoTech.LegosForLife.Security.Models;

namespace InnoTech.LegosForLife.Security.IRepositories
{
    public interface IAuthUserRepository
    {
        // AuthUser FindByUsernameAndPassword(string username, string password);
        AuthUser FindUser(string username);
    }
}