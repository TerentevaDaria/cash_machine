namespace Core.Exceptions;

public class LoginRequiredException : InvalidOperationException
{
    public LoginRequiredException()
    {
    }

    public LoginRequiredException(string operation)
        : base("login required to " + operation)
    {
    }

    public LoginRequiredException(string message, Exception inner)
        : base(message, inner)
    {
    }
}