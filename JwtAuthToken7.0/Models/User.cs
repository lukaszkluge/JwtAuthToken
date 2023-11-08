namespace JwtAuthToken7._0.Models
{
    public class User
    {

        public string Username { get; set; } = string.Empty;

        // The "PasswordHash" property stores the hashed password of the user.
        public string PasswordHash { get; set; } = string.Empty;
    }
}
