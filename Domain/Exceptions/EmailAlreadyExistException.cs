namespace UserSystem.Domain.Exceptions;

public class EmailAlreadyExistException : Exception
{
    public EmailAlreadyExistException(string message) : base(message) { }
}
