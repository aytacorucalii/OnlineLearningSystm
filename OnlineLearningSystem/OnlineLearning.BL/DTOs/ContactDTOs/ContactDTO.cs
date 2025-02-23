using System.ComponentModel.DataAnnotations;

namespace OnlineLearning.BL.DTOs;

public class ContactDTO
{
	public int Id { get; set; }
    public string? Name { get; set; }
	public string? UserName { get; set; }
	public string? Comment { get; set; }
	public double Rating { get; set; }
	public int? CourseId { get; set; }
}
