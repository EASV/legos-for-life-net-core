using System.Linq;
using InnoTech.LegosForLife.DataAccess.Entities;

namespace InnoTech.LegosForLife.DataAccess
{
    public class MainDbSeeder
    {
        private readonly MainDbContext _ctx;

        public MainDbSeeder(MainDbContext ctx)
        {
            _ctx = ctx;
        }

        public void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();
            _ctx.Products.Add(new ProductEntity{Name = "Lego1"});
            _ctx.Products.Add(new ProductEntity{Name = "Lego2"});
            _ctx.Products.Add(new ProductEntity{Name = "Lego3"});
            _ctx.SaveChanges();
        }

        public void SeedProduction()
        {
            _ctx.Database.EnsureCreated();
            var count = _ctx.Products.Count();
            if (count == 0)
            {
                _ctx.Products.Add(new ProductEntity{Name = "Lego1"});
                _ctx.Products.Add(new ProductEntity{Name = "Lego2"});
                _ctx.Products.Add(new ProductEntity{Name = "Lego3"});
                _ctx.SaveChanges();
            } 
        }
    }
}