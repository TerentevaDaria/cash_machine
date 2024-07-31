namespace Core.Exceptions;

public class LoginFailedException : InvalidOperationException
{
    public LoginFailedException()
    {
    }

    public LoginFailedException(string message)
        : base(message)
    {
    }

    public LoginFailedException(string message, Exception inner)
        : base(message, inner)
    {
    }
}