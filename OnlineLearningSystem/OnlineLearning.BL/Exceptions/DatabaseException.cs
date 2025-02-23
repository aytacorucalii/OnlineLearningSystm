namespace OnlineLearning.BL.Exceptions;

public class DatabaseException : Exception
{
	public DatabaseException(string message) : base(message) { }

	public DatabaseException() : base("An error occurred in the database.") { }//SQL və ya Entity Framework xətaları (məsələn, unikal dublikat problemi).
}
