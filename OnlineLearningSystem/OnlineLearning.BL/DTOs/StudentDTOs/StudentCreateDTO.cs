using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineLearning.Core.Enums;

public class StudentCreateDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public Grade Grade { get; set; }
    public Gender? Gender { get; set; }
    public IFormFile? Image { get; set; }
    public string? ImgUrl { get; set; }
    public List<int> Courses { get; set; } 
}

