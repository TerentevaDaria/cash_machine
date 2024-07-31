namespace Core.Exceptions;

public class InsufficientBalanceException : InvalidOperationException
{
    public InsufficientBalanceException()
    {
    }

    public InsufficientBalanceException(string message)
        : base(message)
    {
    }

    public InsufficientBalanceException(string message, Exception inner)
        : base(message, inner)
    {
    }
}