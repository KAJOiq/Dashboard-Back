using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using projects.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace projects.Data
{
    public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : IdentityDbContext<User>(options)
    {
        public DbSet<User> User { get; set; } = null!;
        public DbSet<Project> Project { get; set; } = null!;
        public DbSet<Students> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.ManyServiceProvidersCreatedWarning));
            optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles =
            [
                new()
                {
                    Name = "Student",
                    NormalizedName = "STUDENT"
                },
                new()
                {
                    Name = "Supervisor",
                    NormalizedName = "SUPERVISOR"
                },
            ];
            builder.Entity<IdentityRole>().HasData(roles);


        }
    }
}