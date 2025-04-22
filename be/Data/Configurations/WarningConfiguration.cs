using be.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace be.Data.Configurations;

public class WarningConfiguration : IEntityTypeConfiguration<Warning>
{
    public void Configure(EntityTypeBuilder<Warning> entity)
    {
        entity.ToTable("Warnings");
        entity.HasKey(w => w.Warning_id);
        entity.Property(w => w.Warning_type)
            .IsRequired(true)
            .HasConversion<int>();
        entity.Property(e => e.Created_at)
            .IsRequired(true)
            .HasDefaultValueSql("GETUTCDATE()");
        entity.HasOne(w => w.User)
            .WithMany(u => u.Warnings)
            .HasForeignKey(w => w.User_id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}