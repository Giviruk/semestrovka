using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ItemContext:DbContext
    {
        public DbSet<Phone> Items { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ItemContext(DbContextOptions<ItemContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}