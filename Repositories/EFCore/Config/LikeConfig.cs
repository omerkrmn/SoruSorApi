using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config
{
    public class LikeConfig : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            // Like - Question relationship
            builder
                .HasOne(l => l.Question)
                .WithMany(q => q.Likes)
                .HasForeignKey(l => l.QuestionID)
                .OnDelete(DeleteBehavior.Cascade);

            // Like - User relationship
            builder
                .HasOne(l => l.LikedByUser)
                .WithMany() // Kullanıcının beğenileri takip eden bir koleksiyon yoksa boş bırakılır
                .HasForeignKey(l => l.LikedByUserID)
                .OnDelete(DeleteBehavior.Cascade); // Opsiyonel ilişki, silme işlemi yapma
        }
    }
}
