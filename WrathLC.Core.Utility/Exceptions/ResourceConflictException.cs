namespace WrathLC.Core.Utility.Exceptions;

public class ResourceConflictException : Exception
{
    public ResourceConflictException(string message): base(message)
    {}

    public ResourceConflictException(string message, Exception inner): base(message, inner)
    { }
}