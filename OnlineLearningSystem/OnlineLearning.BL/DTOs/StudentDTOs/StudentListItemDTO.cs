using OnlineLearning.Core.Enums;

public class StudentListItemDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public Grade Grade { get; set; }
    public string ImgUrl { get; set; } // Tələbənin şəkili
}
