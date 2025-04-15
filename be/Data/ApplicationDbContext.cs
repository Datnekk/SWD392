using be.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace be.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<User> User { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }
    public DbSet<Question> Questions { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
        
        List<IdentityRole<Guid>> roles =
        [
            new IdentityRole<Guid> {Id = new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), Name = "Student", NormalizedName = "STUDENT"},
            new IdentityRole<Guid> {Id = new Guid("b2c3d4e5-f678-9012-bcde-f12345678901"), Name = "Proctors ", NormalizedName = "PROCTORS"},
        ];  
        modelBuilder.Entity<IdentityRole<Guid>>().HasData(roles);

        // User → Session (One-to-Many)
        modelBuilder.Entity<User>()
            .HasOne(u => u.CurrentSession)
            .WithMany(s => s.Users)
            .HasForeignKey(u => u.CurrentSessionId)
            .IsRequired(false);
        
        // User → Quiz (One-to-Many)
        modelBuilder.Entity<User>()
            .HasMany(u => u.CreatedQuizzes)
            .WithOne(q => q.Creator)
            .HasForeignKey(q => q.CreatorId);

        // Session → Quiz (One-to-One)
        modelBuilder.Entity<Session>()
            .HasOne(s => s.Quiz)
            .WithOne()
            .HasForeignKey<Session>(s => s.QuizId);
        
        // Quiz ↔ Question (Many-to-Many)
        modelBuilder.Entity<Quiz>()
            .HasMany(q => q.Questions)
            .WithMany(q => q.Quizzes)
            .UsingEntity(j => j.ToTable("QuizQuestions"));

        //Composite keys for Identity tables
        modelBuilder.Entity<IdentityUserLogin<Guid>>().HasKey(x => new { x.LoginProvider, x.ProviderKey });

        modelBuilder.Entity<IdentityUserRole<Guid>>().HasKey(x => new { x.UserId, x.RoleId });
            
        modelBuilder.Entity<IdentityUserToken<Guid>>().HasKey(x => new { x.UserId, x.LoginProvider, x.Name });
    }
}