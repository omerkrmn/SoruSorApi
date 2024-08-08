using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.EFCore.Config;

namespace Repositories.EFCore
{
    public class RepositoryContext : DbContext
    {

        public RepositoryContext(DbContextOptions options)
        : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Answer> Answers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.QuestionsAsked)
                .WithOne(q => q.AskedBy)
                .HasForeignKey(q => q.AskedById)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<User>()
                .HasMany(u => u.QuestionsReceived)
                .WithOne(q => q.ReciveUser)
                .HasForeignKey(q => q.ReciveUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Likes)
                .WithOne(l => l.User)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Question>()
                .HasMany(q => q.Likes)
                .WithOne(l => l.Question)
                .HasForeignKey(l => l.QuestionId);

            
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Answer)
                .WithOne(a => a.Question)
                .HasForeignKey<Answer>(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Restrict); 


            modelBuilder.Entity<User>()
                .Property(u => u.CreatedDate)
                .HasDefaultValueSql("GETUTCDATE()");
            modelBuilder.Entity<Answer>()
                 .Property(u => u.CreatedDate)
                 .HasDefaultValueSql("GETUTCDATE()");
            modelBuilder.Entity<Question>()
                 .Property(u => u.CreatedDate)
                 .HasDefaultValueSql("GETUTCDATE()");
        }

    }
}
