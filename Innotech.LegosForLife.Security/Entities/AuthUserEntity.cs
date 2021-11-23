namespace InnoTech.LegosForLife.Security.Entities
{
    public class AuthUserEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        //Hashed Password
        public string Password { get; set; }
    }
}