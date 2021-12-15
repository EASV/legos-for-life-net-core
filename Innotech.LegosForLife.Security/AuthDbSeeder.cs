using System.Text;
using InnoTech.LegosForLife.DataAccess;
using InnoTech.LegosForLife.Security.Entities;
using InnoTech.LegosForLife.Security.IServices;

namespace InnoTech.LegosForLife.Security
{
    public class AuthDbSeeder: IAuthDbSeeder
    {
        private readonly AuthDbContext _ctx;
        private readonly ISecurityService _securityService;

        public AuthDbSeeder(
            AuthDbContext ctx,
            ISecurityService securityService)
        {
            _ctx = ctx;
            _securityService = securityService;
        }

        public void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();

            _securityService.GenerateNewAuthUser("ljuul");
        }

        public void SeedProduction()
        {
            _ctx.Database.EnsureCreated();
           
        }
    }
}