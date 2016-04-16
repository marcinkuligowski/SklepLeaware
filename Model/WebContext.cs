using Model.Models;
using System.Data.Entity;

namespace Model
{
    public class WebContext : DbContext
    {
        public DbSet<User> userAccount { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set;}
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        

    }
}