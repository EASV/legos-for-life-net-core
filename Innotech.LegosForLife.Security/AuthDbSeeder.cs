using InnoTech.LegosForLife.Security.Entities;

namespace InnoTech.LegosForLife.Security
{
    public class AuthDbSeeder
    {
        private readonly AuthDbContext _ctx;

        public AuthDbSeeder(AuthDbContext ctx)
        {
            _ctx = ctx;
        }

        public void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();
            
            _ctx.AuthUsers.Add(new AuthUserEntity
            {
                Password = "123456",
                Username = "ljuul"
            });
            _ctx.SaveChanges();
        }

        public void SeedProduction()
        {
            _ctx.Database.EnsureCreated();
           
        }
    }
}