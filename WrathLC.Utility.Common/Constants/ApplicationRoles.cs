namespace WrathLC.Utility.Common.Constants;

public static class ApplicationRoles
{
    public const string BasicUser = "Basic";
    public const string Admin = "Admin";
    public static IReadOnlyCollection<string> AllRoles = new string[]
    {
        BasicUser,
        Admin
    };
    
}