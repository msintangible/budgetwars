
using Budget_wars.Models;
using Microsoft;
using Microsoft.EntityFrameworkCore;




namespace Budget_wars.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional model configuration can go here  
        }

        public DbSet<ExpenseUser> Users { get; set; } // DbSet for User model  
    }
}
