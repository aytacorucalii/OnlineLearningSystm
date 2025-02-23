using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearning.Core.Models;
using System.Reflection.Emit;

namespace OnlineLearning.DAL.Configurations;
public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");

        // Primary key
        builder.HasKey(s => s.Id);

        // Properties
        builder.Property(s => s.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(s => s.Surname)
               .IsRequired()
               .HasMaxLength(150);

        builder.Property(s => s.EnrollmentDate)
               .IsRequired()
               .HasDefaultValue(DateTime.UtcNow);

        // Many-to-Many əlaqə StudentCourse vasitəsilə
        builder.HasMany(s => s.StudentCourses)
               .WithOne(sc => sc.Student)
               .HasForeignKey(sc => sc.StudentId)
               .OnDelete(DeleteBehavior.NoAction); 
    }
}


