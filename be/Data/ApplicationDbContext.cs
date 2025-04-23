using be.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace be.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<User, IdentityRole<int>, int>(options)
{
    public DbSet<User> User { get; set; }
    public DbSet<UserExamination> UserExamination { get; set; }
    public DbSet<Examination> Examination { get; set; }
    public DbSet<Result> Result { get; set; }
    public DbSet<Subject> Subject { get; set; }
    public DbSet<Warning> Warning { get; set; }
    public DbSet<Question> Question { get; set; }
    public DbSet<Answer> Answer { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        
        List<IdentityRole<int>> roles =
        [
            new IdentityRole<int> {Id = 1, Name = "Student", NormalizedName = "STUDENT"},
            new IdentityRole<int> {Id = 2, Name = "Proctors ", NormalizedName = "PROCTORS"},
            new IdentityRole<int> {Id = 3, Name = "Admin", NormalizedName = "ADMIN"},
        ];  
        modelBuilder.Entity<IdentityRole<int>>().HasData(roles);

        modelBuilder.Entity<IdentityUserLogin<int>>().HasKey(x => new { x.LoginProvider, x.ProviderKey });

        modelBuilder.Entity<IdentityUserRole<int>>().HasKey(x => new { x.UserId, x.RoleId });
            
        modelBuilder.Entity<IdentityUserToken<int>>().HasKey(x => new { x.UserId, x.LoginProvider, x.Name });
    }
}