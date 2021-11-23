namespace InnoTech.LegosForLife.Security.Entities
{
    public class AuthUserEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        //Hashed Password
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
    }
}