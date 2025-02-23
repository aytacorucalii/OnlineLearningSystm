using OnlineLearning.Core.Enums;

public class CourseListItemDTO
{
    public int Id { get; set; }
    public string CourseName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; } // Kursun qiyməti
    public CourseDuration Duration { get; set; }
    public string TeacherName { get; set; } // Müəllim adı
    public string ImgUrl { get; set; } // Kurs şəkli
}
