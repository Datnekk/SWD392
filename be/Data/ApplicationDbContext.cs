using be.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace be.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<User> User { get; set; }
    public DbSet<Examination> Examination { get; set; }
    public DbSet<Result> Result { get; set; }
    public DbSet<Subject> Subject { get; set; }
    public DbSet<Warning> Warning { get; set; }
    public DbSet<Question> Questions { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
        
        List<IdentityRole<Guid>> roles =
        [
            new IdentityRole<Guid> {Id = new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), Name = "Student", NormalizedName = "STUDENT"},
            new IdentityRole<Guid> {Id = new Guid("b2c3d4e5-f678-9012-bcde-f12345678901"), Name = "Proctors ", NormalizedName = "PROCTORS"},
        ];  
        modelBuilder.Entity<IdentityRole<Guid>>().HasData(roles);

        //Model Relation Here

        //Composite keys for Identity tables
        modelBuilder.Entity<IdentityUserLogin<Guid>>().HasKey(x => new { x.LoginProvider, x.ProviderKey });

        modelBuilder.Entity<IdentityUserRole<Guid>>().HasKey(x => new { x.UserId, x.RoleId });
            
        modelBuilder.Entity<IdentityUserToken<Guid>>().HasKey(x => new { x.UserId, x.LoginProvider, x.Name });
    }
}