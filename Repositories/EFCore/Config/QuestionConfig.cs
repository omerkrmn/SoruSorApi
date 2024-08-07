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
           
            builder
                .HasOne(q => q.Answer)
                .WithOne(a => a.Question)
                .HasForeignKey<Answer>(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

          
            builder
                .HasOne(q => q.AskedByUser)
                .WithMany(u => u.Questions)
                .HasForeignKey(q => q.AskedByUserID)
                .OnDelete(DeleteBehavior.Cascade);

           
            builder
                .HasOne(q => q.AskingTheUser)
                .WithMany(u => u.Questions)
                .HasForeignKey(q => q.AskingTheUserID)
                .OnDelete(DeleteBehavior.Cascade); 

            
            builder
                .Property(q => q.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
