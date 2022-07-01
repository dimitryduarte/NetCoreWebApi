using Microsoft.EntityFrameworkCore;

namespace NetCoreWebApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public AppDbContext() { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Telephone> Telephone { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Customers>()
            //.HasData(
            // new Customer {}
            //);
        }
    }
}
