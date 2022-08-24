namespace WrathLC.Core.Api.Middleware;

public class ServerIsTeapotException : Exception
{
    public ServerIsTeapotException():base("I'm a teapot")
    {   
    }
}