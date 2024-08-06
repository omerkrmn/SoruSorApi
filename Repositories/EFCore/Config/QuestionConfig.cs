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
            // Question - Answer relationship
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
                .OnDelete(DeleteBehavior.Cascade);

            // Question - AskingTheUser relationship
            builder
                .HasOne(q => q.AskingTheUser)
                .WithMany() // Kullanıcının sorularını takip eden bir koleksiyon yoksa boş bırakılır
                .HasForeignKey(q => q.AskingTheUserID)
                .OnDelete(DeleteBehavior.Cascade); // Opsiyonel ilişki, silme işlemi yapma

            // Question Table created date default value
            builder
                .Property(q => q.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
