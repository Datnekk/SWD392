using be.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace be.Data.Configurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> entity)
    {
        entity.ToTable("Subjects");
        entity.HasKey(s => s.Subject_id);
        entity.Property(s => s.Subject_id)
            .ValueGeneratedOnAdd();
        entity.Property(s => s.Subject_code)
            .IsRequired(true)
            .HasMaxLength(255);
        entity.Property(s => s.Subject_name)
            .IsRequired(true)
            .HasMaxLength(255);
        entity.Property(e => e.Created_at)
            .IsRequired(true)
            .HasDefaultValueSql("GETUTCDATE()");
        entity.Property(e => e.Updated_at)
            .IsRequired(true)
            .HasDefaultValueSql("GETUTCDATE()");
        entity.HasMany(s => s.Examinations)
            .WithOne(e => e.Subject)
            .HasForeignKey(e => e.Subject_id)
            .OnDelete(DeleteBehavior.Cascade);
        entity.HasMany(s => s.Questions)
            .WithOne(q => q.Subject)
            .HasForeignKey(q => q.Subject_id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}