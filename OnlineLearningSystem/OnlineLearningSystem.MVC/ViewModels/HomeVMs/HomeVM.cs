using OnlineLearning.BL.DTOs;

namespace OnlineLearningSystem.MVC.ViewModels;

public class HomeVM
{
    public ICollection<TeacherViewItemDTO> Teachers { get; set; }
    public ICollection<CourseViewItemDTO> Courses { get; set; }
	public ICollection<ContactDTO> Messages { get; set; }
	public ICollection<StatisticsDTO> Statistics { get; set; }
}
