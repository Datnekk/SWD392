using be.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace be.Data.Configurations;

public class ExaminationConfiguration : IEntityTypeConfiguration<Examination>
{
    public void Configure(EntityTypeBuilder<Examination> entity)
    {
        entity.ToTable("Examinations");
        entity.HasKey(e => e.Exam_id);
        entity.Property(e => e.Exam_name)
            .IsRequired(true)
            .HasMaxLength(255);
        entity.Property(e => e.Exam_password)
            .IsRequired(true)
            .HasMaxLength(255);
        entity.Property(e => e.No_of_question)
            .IsRequired(true)
            .HasMaxLength(60);
        entity.Property(e => e.Created_at)
            .IsRequired(true)
            .HasDefaultValueSql("GETUTCDATE()");
        entity.Property(e => e.Updated_at)
            .IsRequired(true)
            .HasDefaultValueSql("GETUTCDATE()");
        entity.HasOne(e => e.Subject)
            .WithMany(s => s.Examinations)
            .HasForeignKey(e => e.Subject_id)
            .OnDelete(DeleteBehavior.Cascade);
        entity.HasMany(e => e.UserExaminations)
            .WithOne(ue => ue.Examination)
            .HasForeignKey(ue => ue.Exam_id)
            .OnDelete(DeleteBehavior.Cascade);
        entity.HasMany(e => e.Results)
            .WithOne(r => r.Examination)
            .HasForeignKey(r => r.Exam_id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}