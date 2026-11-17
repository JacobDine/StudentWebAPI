using Microsoft.EntityFrameworkCore;
using StudentWebAPI.Models;

public class StudentWebAPIContext(DbContextOptions<StudentWebAPIContext> options) : DbContext(options)
{
    public DbSet<StudentWebAPI.Models.Student> Student { get; set; } = default!;
    public DbSet<StudentWebAPI.Models.Course> Course { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, Name = "John Doe", City = "New York", Age = 20 },
            new Student { Id = 2, Name = "Jane Smith", City = "Los Angeles", Age = 22 },
            new Student { Id = 3, Name = "Michael Johnson", City = "Chicago", Age = 21 }
        );
        modelBuilder.Entity<Course>().HasData(
            new Course { Id = 1, Name = "Math", Description = "Mathematics" },
            new Course { Id = 2, Name = "Science", Description = "Science" },
            new Course { Id = 3, Name = "History", Description = "History" }
        );
    }
}
