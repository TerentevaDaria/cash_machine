namespace Core.Exceptions;

public class RepositoryException : InvalidOperationException
{
    public RepositoryException()
    {
    }

    public RepositoryException(string message)
        : base(message)
    {
    }

    public RepositoryException(string message, Exception inner)
        : base(message, inner)
    {
    }
}