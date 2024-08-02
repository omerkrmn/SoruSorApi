using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace SoruSorApi.Repositories
{
    public class RepositoryContext : DbContext
    {

        public RepositoryContext(DbContextOptions options)
        : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Like> Likes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Question - AskedByUser relationship
            modelBuilder.Entity<Question>()
            .HasOne(q => q.AskedByUser)
            .WithMany(u => u.Questions)
            .HasForeignKey(q => q.AskedByUserID)
            .OnDelete(DeleteBehavior.Restrict);

            // Question - AskingTheUser relationship
            modelBuilder.Entity<Question>()
                .HasOne(q => q.AskingTheUser)
                .WithMany()
                .HasForeignKey(q => q.AskingTheUserID)
                .OnDelete(DeleteBehavior.Restrict);

            // Question Table created date default value
            modelBuilder.Entity<Question>()
            .Property(q => q.CreatedDate)
            .HasDefaultValueSql("GETDATE()");

            // User Table created date default value
            modelBuilder.Entity<User>()
            .Property(q => q.CreatedDate)
            .HasDefaultValueSql("GETDATE()");
        }
    }

}
