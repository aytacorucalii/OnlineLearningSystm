using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineLearning.Core.Enums;

public class CourseUpdateDTO
{
    public int Id { get; set; }
    public string CourseName { get; set; }
    public string Description { get; set; }
    public IFormFile Image { get; set; }
    public string? ImgUrl { get; set; }
    public decimal Price { get; set; } // Kursun qiyməti
    public CourseDuration? Duration { get; set; }

}
