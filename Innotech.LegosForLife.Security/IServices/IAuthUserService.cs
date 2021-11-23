using InnoTech.LegosForLife.Security.Models;

namespace InnoTech.LegosForLife.Security.IServices
{
    public interface IAuthUserService
    {
        AuthUser Login(string username, string password);
    }
}