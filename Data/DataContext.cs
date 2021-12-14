using Microsoft.EntityFrameworkCore;
using SogetiOrders.Models;

namespace SogetiOrders.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
            Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set;}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}