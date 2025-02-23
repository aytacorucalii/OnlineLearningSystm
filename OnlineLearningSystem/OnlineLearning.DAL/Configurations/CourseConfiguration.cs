using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearning.Core.Models;

namespace OnlineLearning.DAL.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
	public void Configure(EntityTypeBuilder<Course> builder)
	{
		// Table name
		builder.ToTable("Courses");

		builder.HasKey(c => c.Id);

		builder.Property(c => c.CourseName)
			   .IsRequired()
			   .HasMaxLength(200);

		builder.HasOne(c => c.Teacher)
			   .WithMany(t => t.Courses)
			   .HasForeignKey(c => c.TeacherId);
		builder.Property(c => c.Description)
			   .HasMaxLength(500);

		// Price must be positive
		builder.Property(c => c.Price)
			   .IsRequired()
			   .HasColumnType("decimal(18,2)");

		// Rating should be between 1 and 3
		builder.Property(c => c.Rating)
			   .IsRequired()
			   .HasColumnType("decimal(3,2)")
			   .HasDefaultValue(0.0);

		// Duration (can be stored as string, like "12 Weeks")
		builder.Property(c => c.Duration)
			   .IsRequired()
			   .HasMaxLength(50);
        // Many-to-Many əlaqə StudentCourse vasitəsilə
        builder.HasMany(c => c.StudentCourses)
               .WithOne(sc => sc.Course)
               .HasForeignKey(sc => sc.CourseId)
		       .OnDelete(DeleteBehavior.NoAction);

		builder.HasMany(c => c.Contacts)
			  .WithOne(co => co.Course)  
			  .HasForeignKey(co => co.CourseId) // ForeignKey: CourseId
			  .OnDelete(DeleteBehavior.NoAction);
	}
}
