using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        //Получение всех товаров
        public DbSet<Window> Windows { get; set; }
        //Получение всех категорий
        public DbSet<Category> Categories { get; set; }
        //Товары в корзине
        public DbSet<ShopWindowItem> ShopWindowItems { get; set; }
        //Заказ и Информация о заказе
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        //Пользователи
        public DbSet<User> Users { get; set; }
        //Настройки сайта
        public DbSet<SiteSettings> SiteSettings { get; set; }
        //Приглашения
        public DbSet<Invitation> Invitation { get; set; }
        //Заявки
        public DbSet<Booked> Bookeds { get; set; }
        //Отзывы
        public DbSet<FeedBack> FeedBacks { get; set; }
        //Поставщики
        public DbSet<Supplier> Suppliers{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasCheckConstraint("Role", "(Role in ('RegisteredUser','Administrator','Editor'))");
            modelBuilder.Entity<Order>().Property(e => e.OrderStatus).HasDefaultValue("New");
            modelBuilder.Entity<Order>().HasCheckConstraint("OrderStatus", "(OrderStatus in ('New','Sent','Paid','Cancelled'))");
            modelBuilder.Entity<Category>().HasIndex(u => u.CategoryName).IsUnique();
        }

    }
}
