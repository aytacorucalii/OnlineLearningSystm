using OnlineLearning.Core.Enums;
using OnlineLearning.Core.Models.Base;

namespace OnlineLearning.Core.Models;

public class Teacher : BaseAuditable
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Subject { get; set; } // Fənn
    public int ExperienceYears { get; set; }
    public Gender? Gender { get; set; }
    public decimal Salary { get; set; }
    public string ImgUrl { get; set; }

    // Bir müəllimin bir neçə kursu ola bilər
    public ICollection<Course>? Courses { get; set; } = new List<Course>();
}
