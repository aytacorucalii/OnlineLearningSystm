namespace OnlineLearning.BL.Exceptions;

public class NotFoundException : Exception
{
	public NotFoundException(string message) : base(message) { }

	public NotFoundException() : base("Identity not found") { } // Yalniz Admin! Axtarılan obyekt tapılmayıb (məsələn, ID-yə görə istifadəçi yoxdur).
}
