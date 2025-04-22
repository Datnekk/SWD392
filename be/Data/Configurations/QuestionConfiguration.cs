using be.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace be.Data.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> entity)
    {
        entity.ToTable("Questions");
        entity.HasKey(q => q.Question_id);
        entity.Property(q => q.Question_text)
            .IsRequired(true)
            .HasMaxLength(5000);
        entity.Property(q => q.Question_type)
            .IsRequired(true)
            .HasConversion<int>();
        entity.Property(e => e.Created_at)
            .IsRequired(true)
            .HasDefaultValueSql("GETUTCDATE()");
        entity.Property(e => e.Updated_at)
            .IsRequired(true)
            .HasDefaultValueSql("GETUTCDATE()");
        entity.HasOne(q => q.Subject)
            .WithMany(s => s.Questions)
            .HasForeignKey(q => q.Subject_id)
            .OnDelete(DeleteBehavior.Cascade);
        entity.HasMany(q => q.Answers)
            .WithOne(a => a.Question)
            .HasForeignKey(q => q.Question_id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}