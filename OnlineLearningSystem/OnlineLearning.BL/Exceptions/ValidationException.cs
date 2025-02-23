namespace OnlineLearning.BL.Exceptions;

public class ValidationException : Exception
{
	public ValidationException(string message) : base(message) { }

	public ValidationException() : base("Something went wrong!") { }//Daxil edilən məlumat səhvdir (məsələn, şifrə 6 simvoldan qısa olması).
}
