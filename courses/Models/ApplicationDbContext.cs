using Microsoft.EntityFrameworkCore;

namespace courses.Models
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string connectionString;
        public DbSet<Student> Students { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        public ApplicationDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
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
                .WithMany(a => a.Courses)
                .UsingEntity(j => j.ToTable("Authorship"));

            modelBuilder
                .Entity<Student>()
                .HasAlternateKey(c => c.Email);
        }
    }
}
