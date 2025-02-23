using OnlineLearning.Core.Enums;
using OnlineLearning.Core.Models.Base;
using Stripe;

namespace OnlineLearning.Core.Models;

public class Course : BaseAuditable
{
    public string CourseName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal Rating { get; set; }
    public int RatingCount { get; set; }
    public string ImgUrl { get; set; }
    public CourseDuration? Duration { get; set; } 
    public int? TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
	public ICollection<Contact>? Contacts { get; set; }
	public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
}
