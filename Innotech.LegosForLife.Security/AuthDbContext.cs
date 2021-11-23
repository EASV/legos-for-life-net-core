using InnoTech.LegosForLife.Security.Entities;
using InnoTech.LegosForLife.Security.Models;
using Microsoft.EntityFrameworkCore;

namespace InnoTech.LegosForLife.Security
{
    public class AuthDbContext: DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options): base(options) { }

        public DbSet<AuthUserEntity> AuthUsers { get; set; }
        
    }
}