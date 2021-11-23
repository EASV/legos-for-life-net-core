using InnoTech.LegosForLife.Security.Models;

namespace InnoTech.LegosForLife.Security.IServices
{
    public interface IAuthUserService
    {
        AuthUser GetUser(string username);
    }
}