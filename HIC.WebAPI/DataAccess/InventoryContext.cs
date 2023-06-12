using Microsoft.EntityFrameworkCore;
using HIC.WebAPI.Domain.Models;

namespace HIC.WebAPI.DataAccess
{
    public class InventoryContext  : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options) {}

        public DbSet<InventoryBO> InventoryItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Inventory.db;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventoryBO>().HasData(
                new InventoryBO()
                {
                    Id = 1,
                    Name = "Table",
                    Description = "Ordered from Wayfair",
                    Count = 25
                },
                new InventoryBO()
                {
                    Id = 2,
                    Name = "Chair",
                    Description = "Delivered by Amazon",
                    Count = 49
                },
                new InventoryBO()
                {
                    Id = 3,
                    Name = "Vases",
                    Description = "Extra stock",
                    Count = 17
                }
            );
        }
    }
}
