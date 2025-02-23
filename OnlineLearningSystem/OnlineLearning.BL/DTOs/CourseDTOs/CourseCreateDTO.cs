using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineLearning.Core.Enums;

public class CourseCreateDTO
{
    public string CourseName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public CourseDuration? Duration { get; set; }
    public IFormFile? Image { get; set; }  // Şəkil faylı üçün
    public string? ImgUrl { get; set; }  // Fayl yükləndikdən sonra URL təyin ediləcək
}

