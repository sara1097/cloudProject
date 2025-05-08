using Domin.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
       public DbSet<Category> Categories { get; set; }
       public DbSet<Budget> Budgets { get; set; }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    // Simple configuration without Category-Budget relationship
        //    builder.Entity<Budget>()
        //        .HasOne(b => b.User)
        //        .WithMany()
        //        .HasForeignKey(b => b.UserId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.Entity<Category>()
        //        .HasOne(c => c.User)
        //        .WithMany()
        //        .HasForeignKey(c => c.UserId)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}
    }
}
