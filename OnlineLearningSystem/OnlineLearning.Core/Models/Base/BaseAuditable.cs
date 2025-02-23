namespace OnlineLearning.Core.Models.Base;

public class BaseAuditable: BaseEntity
{
	public string? CreatedBy { get; set; } 
	public string? UpdatedBy { get; set; }
	public string? DeletedBy { get; set; }
}
