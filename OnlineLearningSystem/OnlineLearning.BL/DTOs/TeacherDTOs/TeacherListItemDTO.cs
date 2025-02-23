using Microsoft.AspNetCore.Mvc.Rendering;

public class TeacherListItemDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Subject { get; set; } // Fənn
    public decimal Salary { get; set; }
    public string CourseName { get; set; }
    public int ExperienceYears { get; set; }

}
