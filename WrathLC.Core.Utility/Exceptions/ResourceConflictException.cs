namespace WrathLC.Core.Utility.Exceptions;
/// <summary>
/// This exception is thrown where an operation could not be carried out because of a conflict on the server.
/// </summary>
public class ResourceConflictException : Exception
{
    public ResourceConflictException(string message): base(message)
    {}

    public ResourceConflictException(string message, Exception inner): base(message, inner)
    { }
}