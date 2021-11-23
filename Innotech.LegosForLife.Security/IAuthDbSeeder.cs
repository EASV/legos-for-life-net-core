namespace InnoTech.LegosForLife.Security
{
    public interface IAuthDbSeeder
    {
        void SeedDevelopment();
        void SeedProduction();
    }
}