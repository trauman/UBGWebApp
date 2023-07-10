using Microsoft.EntityFrameworkCore;
using UBGWebApp.Models;

namespace UBGWebApp.Data
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
            
        }

        public DbSet<TestModel> Tests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestModel>().ToTable("Test");
        }
    }
}
