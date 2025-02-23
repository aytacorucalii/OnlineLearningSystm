using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineLearning.Core.Models;
using System.Reflection;
namespace OnlineLearning.DAL.Contexts;

public class AppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
	public DbSet<Teacher> Teachers { get; set; }
	public DbSet<Student> Students { get; set; }
	public DbSet<Course> Courses { get; set; }
	public DbSet<Statistics> Statistics { get; set; }
	public DbSet<StudentCourse>StudentCourses { get; set; }
	public DbSet<Payment> Payments { get; set; }
	public DbSet<PaymentResult> PaymentResults { get; set; }
	public DbSet<Settings> Settings { get; set; }
	public DbSet<Contact> Contacts { get; set; }

	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		#region Roles
		modelBuilder.Entity<IdentityRole>().HasData(
			new IdentityRole { Id = "36f92c7f-a6e4-48b1-96e9-f3b284c6a5b7", Name = "Admin", NormalizedName = "ADMIN" },
			new IdentityRole { Id = "601a1942-44a1-4f22-bebf-b24df757d368", Name = "User", NormalizedName = "USER" }
		);
		#endregion

		#region User
		IdentityUser admin = new()
		{
			Id = "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
			UserName = "admin",
			NormalizedUserName = "ADMIN"
		};

		PasswordHasher<IdentityUser> hasher = new();
		admin.PasswordHash = hasher.HashPassword(admin, "admin123");

		modelBuilder.Entity<IdentityUser>().HasData(admin);

		modelBuilder.Entity<IdentityUserRole<string>>().HasData(
			new IdentityUserRole<string> { UserId = admin.Id, RoleId = "36f92c7f-a6e4-48b1-96e9-f3b284c6a5b7" }
		);
		#endregion

		#region Settings
		modelBuilder.Entity<Settings>().HasData(
			new Settings { Id = 1, Key = "facebook", Value = "https://www.facebook.com/login" },
			new Settings { Id = 2, Key = "instagram", Value = "https://www.instagram.com/accounts/login/" },
			new Settings { Id = 3, Key = "linkedin", Value = "https://www.linkedin.com/login" },
			new Settings { Id = 4, Key = "twitter", Value = "https://twitter.com/login" },
			new Settings { Id = 5, Key = "youtube", Value = "https://accounts.google.com/ServiceLogin?service=youtube" }
		);
		#endregion

		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}
