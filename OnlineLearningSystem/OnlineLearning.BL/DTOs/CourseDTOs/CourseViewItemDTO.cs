using OnlineLearning.Core.Enums;

public class CourseViewItemDTO
{
    public string CourseName { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; } // Kursun qiyməti
    public CourseDuration Duration { get; set; }
    public string ImgUrl { get; set; }
    public string TeacherName { get; set; } // Müəllimin adı
    public decimal Rating { get; set; } // Kursun qiymətləndirməsi
    public int RatingCount { get; set; } // Qiymətləndirmə sayı
}
