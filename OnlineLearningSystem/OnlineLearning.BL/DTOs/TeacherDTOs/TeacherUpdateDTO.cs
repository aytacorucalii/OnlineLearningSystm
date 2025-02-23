using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

public class TeacherUpdateDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Subject { get; set; } // Fənn
    public int ExperienceYears { get; set; }
    public string? ImgUrl { get; set; }
    public decimal Salary { get; set; }
    public IFormFile? Image { get; set; }
}
