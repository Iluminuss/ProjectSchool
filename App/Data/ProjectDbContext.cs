using App.Data.Entities;
using Microsoft.EntityFrameworkCore;
using App.Data.Models;

namespace App.Data
{
    public class ProjectDbContext:DbContext
    {
        public ProjectDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CookedFood> CookedFoods { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RestaurantDb;Integrated Security=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<App.Data.Models.OrderDTO> OrderDTO { get; set; }
    }
}
