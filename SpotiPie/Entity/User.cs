namespace SpotiPie.Entity
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; } = String.Empty;

        public string Password { get; set; } = String.Empty;

        public required string Roles { get; set; } = "User";
    }
}
