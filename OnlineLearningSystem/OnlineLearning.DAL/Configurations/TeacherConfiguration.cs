using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearning.Core.Models;

namespace OnlineLearning.DAL.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("Teachers");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(t => t.Surname)
               .IsRequired()
               .HasMaxLength(150);

        builder.HasMany(t => t.Courses)
               .WithOne(c => c.Teacher)
               .HasForeignKey(c => c.TeacherId);
    }
}
