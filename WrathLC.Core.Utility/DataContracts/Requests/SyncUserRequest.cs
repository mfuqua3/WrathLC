namespace WrathLC.Core.Utility.DataContracts.Requests;

public class SyncUserRequest
{
    public string DiscordAccessToken { get; set; }
    public string UserId { get; set; }
}