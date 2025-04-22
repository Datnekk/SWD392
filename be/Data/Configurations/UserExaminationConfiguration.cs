using be.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace be.Data.Configurations;

public class UserExaminationConfiguration : IEntityTypeConfiguration<UserExamination>
{
    public void Configure(EntityTypeBuilder<UserExamination> entity)
    {
        entity.ToTable("AspNetUsers_Examinations");
        entity.HasKey(ue => new {ue.User_id, ue.Exam_id});
        entity.HasOne(ue => ue.User)
            .WithMany(u => u.UserExaminations)
            .HasForeignKey(ue => ue.User_id)
            .OnDelete(DeleteBehavior.Cascade);
        entity.HasOne(ue => ue.Examination)
            .WithMany(e => e.UserExaminations)
            .HasForeignKey(ue => ue.Exam_id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}