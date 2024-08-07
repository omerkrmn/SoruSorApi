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
            base.OnModelCreating(modelBuilder);
            //modelBuilder.ApplyConfiguration(new QuestionConfig());
            //modelBuilder.ApplyConfiguration(new UserConfig());   
            //modelBuilder.ApplyConfiguration(new LikeConfig());
            //modelBuilder.ApplyConfiguration(new AnswerConfig());

            modelBuilder.Entity<Question>()
                 .HasOne(q => q.AskedByUser)
                 .WithMany(u => u.Questions)
                 .HasForeignKey(q => q.AskedByUserID)
                 .OnDelete(DeleteBehavior.Cascade); // veya NoAction

            modelBuilder.Entity<Question>()
                .HasOne(q => q.AskingTheUser)
                .WithMany()
                .HasForeignKey(q => q.AskingTheUserID)
                .OnDelete(DeleteBehavior.NoAction); // veya NoAction

            modelBuilder.Entity<Like>()
                .HasOne(l => l.Question)
                .WithMany(q => q.Likes)
                .HasForeignKey(l => l.QuestionID)
                .OnDelete(DeleteBehavior.NoAction); // veya NoAction

            modelBuilder.Entity<Like>()
                .HasOne(l => l.LikedByUser)
                .WithMany()
                .HasForeignKey(l => l.LikedByUserID)
                .OnDelete(DeleteBehavior.NoAction); // veya NoAction

            modelBuilder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithOne(q => q.Answer)
                .HasForeignKey<Answer>(a => a.QuestionId)
                .OnDelete(DeleteBehavior.NoAction); // veya NoAction


        }

    }
}
