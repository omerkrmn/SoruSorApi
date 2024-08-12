using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<int>>
{
    public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
    {
        builder.HasData(
            new IdentityRole<int>
            {
                Id = 1, 
                Name = "User",
                NormalizedName = "USER"
            },
            new IdentityRole<int>
            {
                Id = 2,
                Name = "Admin",
                NormalizedName = "ADMIN"
            }
        );
    }
}
