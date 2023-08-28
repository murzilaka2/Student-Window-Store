using System.Security.Claims;

namespace WebApplication1.Data.Repository
{
    public class UserRepository : IAllUser
    {
        private readonly AppDbContext appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public IEnumerable<User> GetUsers => appDbContext.Users;

        public void AddUser(User user)
        {
            appDbContext.Users.Add(user);
            appDbContext.SaveChanges();
        }
        public void UpdateUser(User user)
        {
            appDbContext.Users.Update(user);
            appDbContext.SaveChanges();
        }

        public User GetObjectUser(int id)
        {
            return appDbContext.Users.FirstOrDefault(e => e.Id == id)!;
        }

        public bool IsEmailExists(string email, string exceptEmail)
        {
            return appDbContext.Users.Where(e => !e.Email.ToLower().Equals(exceptEmail.ToLower())).
                Any(e => e.Email.ToLower().Equals(email.ToLower()));
        }
    }
}
