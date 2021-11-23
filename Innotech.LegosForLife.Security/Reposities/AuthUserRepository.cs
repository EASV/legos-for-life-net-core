using System.Linq;
using System.Text;
using InnoTech.LegosForLife.Security.IRepositories;
using InnoTech.LegosForLife.Security.Models;

namespace InnoTech.LegosForLife.Security.Reposities
{
    public class AuthUserRepository: IAuthUserRepository
    {
        private readonly AuthDbContext _ctx;

        public AuthUserRepository(AuthDbContext ctx)
        {
            _ctx = ctx;
        }
        public AuthUser FindByUsernameAndPassword(string username, string hashedPassword)
        {
            var entity = _ctx.AuthUsers
                .FirstOrDefault(user =>
                    hashedPassword.Equals(user.HashedPassword) &&
                    username.Equals(user.Username));
            if (entity == null) return null;
            return new AuthUser
            {
                Id = entity.Id,
                UserName = entity.Username
            };
        }

        public AuthUser FindUser(string username)
        {
            var entity = _ctx.AuthUsers
                .FirstOrDefault(user => username.Equals(user.Username));
            if (entity == null) return null;
            return new AuthUser
            {
                Id = entity.Id,
                UserName = entity.Username,
                HashedPassword = entity.HashedPassword,
                Salt = Encoding.ASCII.GetBytes(entity.Salt)
            };
        }
    }
}