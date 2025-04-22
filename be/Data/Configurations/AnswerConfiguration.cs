using be.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace be.Data.Configurations;

public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> entity)
    {
        entity.ToTable("Answers");
        entity.HasKey(a => a.Answer_id);
        entity.Property(a => a.Answer_text)
            .IsRequired(true)
            .HasMaxLength(5000);
        entity.Property(a => a.Is_Correct)
            .IsRequired(true)
            .HasDefaultValue(false);
        entity.Property(e => e.Created_at)
            .IsRequired(true)
            .HasDefaultValueSql("GETUTCDATE()");
        entity.Property(e => e.Updated_at)
            .IsRequired(true)
            .HasDefaultValueSql("GETUTCDATE()");
        entity.HasOne(a => a.Question)
            .WithMany(q => q.Answers)
            .HasForeignKey(a => a.Question_id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}