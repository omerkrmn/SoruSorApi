using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    /// <summary>
    /// Contains the Configure operations of the Question model
    /// </summary>
    public class QuestionConfig : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            // Question - Answer releationship
            builder
                .HasOne(q => q.Answer)
                .WithOne(a => a.Question)
                .HasForeignKey<Answer>(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Question - AskedByUser relationship
            builder
                .HasOne(q => q.AskedByUser)
                .WithMany(u => u.Questions)
                .HasForeignKey(q => q.AskedByUserID)
                .OnDelete(DeleteBehavior.Restrict);

            // Question - AskingTheUser relationship
            builder
                .HasOne(q => q.AskingTheUser)
                .WithMany()
                .HasForeignKey(q => q.AskingTheUserID)
                .OnDelete(DeleteBehavior.Restrict);

            // Question Table created date default value
            builder
                .Property(q => q.CreatedDate)
                .HasDefaultValueSql("GETDATE()");


        }
    }
}
