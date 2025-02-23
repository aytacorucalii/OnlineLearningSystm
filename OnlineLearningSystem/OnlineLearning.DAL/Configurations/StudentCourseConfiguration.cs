using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearning.Core.Models;

namespace OnlineLearning.DAL.Configurations;

public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
{
    public void Configure(EntityTypeBuilder<StudentCourse> builder)
    {
        // Define composite key for the StudentCourse table
        builder.HasKey(sc => new { sc.StudentId, sc.CourseId });

        // Configuring the relationship between StudentCourse and Student
        builder.HasOne(sc => sc.Student)
            .WithMany(s => s.StudentCourses)
            .HasForeignKey(sc => sc.StudentId)
            .OnDelete(DeleteBehavior.NoAction); // ✅ Əlavə etdik

        // Configuring the relationship between StudentCourse and Course
        builder.HasOne(sc => sc.Course)
            .WithMany(c => c.StudentCourses)
            .HasForeignKey(sc => sc.CourseId)
            .OnDelete(DeleteBehavior.NoAction); // ✅ Əlavə etdik
    }
}

