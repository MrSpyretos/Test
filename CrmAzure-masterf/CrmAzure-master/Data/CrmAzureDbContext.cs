using CrmAzure.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CrmAzure.Data
{
    public class CrmAzureDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    "Server=tcp:mrspyretos.database.windows.net,1433;Initial Catalog=CrmAzure;Persist Security Info=False;" +
                    "User ID=spylak;Password=ueh5235K;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>();

            modelBuilder.Entity<Customer>()
                .Property(c => c.FirstName)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .Property(c => c.LastName)
                .IsRequired();

            modelBuilder.Entity<Order>();

            modelBuilder.Entity<Product>();

            // works on EF Core 5.0
            //modelBuilder.Entity<Order>().HasMany(o => o.Products).WitMany()

            // Many-to-many: works on EF Core 3.x
            modelBuilder.Entity<Order>().HasKey(o => new { o.CustomerId , o.ProductId });
            modelBuilder.Entity<OrderProduct>().HasKey(op => new { op.OrderId, op.ProductId });
            modelBuilder.Entity<Customer>().HasOne(o => o.Orders);
            modelBuilder.Entity<Customer>().HasOne(o => o.Order);
            modelBuilder.Entity<Order>().HasOne(o => o.OrderProduct);
            modelBuilder.Entity<Order>().HasOne(o => o.Products);
            modelBuilder.Entity<OrderProduct>().HasOne(o => o.Order);
            modelBuilder.Entity<OrderProduct>().HasOne(o => o.Product);
        }
    }
}
