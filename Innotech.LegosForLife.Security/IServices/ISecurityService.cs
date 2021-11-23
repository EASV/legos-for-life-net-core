using InnoTech.LegosForLife.Security.Models;

namespace InnoTech.LegosForLife.Security.IServices
{
    public interface ISecurityService
    {
        JwtToken GenerateJwtToken(string username, string password);
        string HashedPassword(string plainTextPassword, byte[] userSalt);
    }
}