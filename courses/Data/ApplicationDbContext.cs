using courses.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace courses.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, ApplicationRole, int>
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-RA7DRFGM;Database=SkillTechDB;Integrated Security=true;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Course>()
                .HasMany(c => c.Students)
                .WithMany(s => s.Courses)
                .UsingEntity(j => j.ToTable("Enrollments"));

            modelBuilder
                .Entity<Course>()
                .HasMany(c => c.Authors)
                .WithMany(a => a.CoursesAuthorship)
                .UsingEntity(j => j.ToTable("Authorship"));

            modelBuilder
                .Entity<User>()
                .HasAlternateKey(c => c.Email);

            base.OnModelCreating(modelBuilder);
        }
    }
}
