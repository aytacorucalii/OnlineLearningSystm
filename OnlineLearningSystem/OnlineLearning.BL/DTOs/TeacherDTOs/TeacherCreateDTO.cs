using Microsoft.AspNetCore.Http;

namespace OnlineLearning.BL.DTOs;

public class TeacherCreateDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Subject { get; set; } // Fənn
    public int ExperienceYears { get; set; }
    public decimal Salary { get; set; }
    public IFormFile? Image { get; set; } 
    public string? ImgUrl { get; set; }

}
