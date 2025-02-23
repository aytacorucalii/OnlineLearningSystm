using OnlineLearning.Core.Models.Base;

namespace OnlineLearning.Core.Models;

public class Statistics : BaseEntity
{
	public int StudentCount { get; set; }
	public int LearningProgramCount { get; set; }
	public int LanguageTrainingCount { get; set; }
	public int TeacherCount { get; set; }
	public int BranchCount { get; set; }
}

//search etmenin viewsu yoxdur (coureservice) chatgpt basa dusmur
//payment var isleyir yeqin ki secretkey var onun da viewsu yoxdu
//payment istese evvel login sonra payment
//selectleri duzelt
