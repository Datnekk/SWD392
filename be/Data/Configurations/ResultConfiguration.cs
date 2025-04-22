using be.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace be.Data.Configurations;

public class ResultConfiguration : IEntityTypeConfiguration<Result>
{
    public void Configure(EntityTypeBuilder<Result> entity)
    {
        entity.ToTable("Results");
        entity.HasKey(r => r.Result_id);
        entity.Property(r => r.Grade)
            .IsRequired(true);
        entity.Property(e => e.Created_at)
            .IsRequired(true)
            .HasDefaultValueSql("GETUTCDATE()");
        entity.HasOne(r => r.User)
            .WithMany(u => u.Results)
            .HasForeignKey(r => r.User_id)
            .OnDelete(DeleteBehavior.Cascade);
        entity.HasOne(r => r.Examination)
            .WithMany(e => e.Results)
            .HasForeignKey(r => r.Exam_id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}