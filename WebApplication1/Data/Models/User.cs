namespace WebApplication1.Data.Models
{
    public enum Role { RegisteredUser = 1, Administrator, Editor }
    public class User
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
    }
}
