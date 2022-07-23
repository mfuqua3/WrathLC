namespace WrathLc.Core.Data.Requests;

public class SyncUserRequest
{
    public string DiscordAccessToken { get; set; }
    public string UserId { get; set; }
}