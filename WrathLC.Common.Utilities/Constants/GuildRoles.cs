namespace WrathLc.Common.Utilities.Constants;

public static class GuildRoles
{
    public const string BasicUser = "Basic";
    public const string Admin = "Admin";
    public static IReadOnlyCollection<string> AllRoles = new string[]
    {
        BasicUser,
        Admin
    };
    
}