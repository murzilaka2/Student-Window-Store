namespace WebApplication1.Data.Interfaces
{
    public interface IAllUser
    {
        IEnumerable<User> GetUsers { get; }
        User GetObjectUser(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        bool IsEmailExists(string email, string exceptEmail);
    }
}
