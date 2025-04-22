using be.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace be.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.Property(u => u.Id).HasColumnName("User_id");
        entity.Property(u => u.RefreshToken)
            .IsRequired(false)
            .HasMaxLength(100);
        entity.Property(u => u.Email)
            .IsRequired(true)
            .HasMaxLength(255);
        entity.Property(u => u.UserName)
            .IsRequired(false)
            .HasMaxLength(255);
        entity.Property(u => u.RefreshTokenExpiryTime)
            .IsRequired(false);
        entity.HasMany(u => u.UserExaminations)
            .WithOne(ue => ue.User)
            .HasForeignKey(ue => ue.User_id)
            .OnDelete(DeleteBehavior.Cascade);
        entity.HasMany(u => u.Results)
            .WithOne(ue => ue.User)
            .HasForeignKey(ue => ue.User_id)
            .OnDelete(DeleteBehavior.Cascade);
        entity.HasMany(u => u.Warnings)
            .WithOne(ue => ue.User)
            .HasForeignKey(ue => ue.User_id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}