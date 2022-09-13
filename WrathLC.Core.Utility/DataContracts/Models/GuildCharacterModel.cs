namespace WrathLC.Core.Utility.DataContracts.Models;

public class GuildCharacterModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Class { get; set; }
    public bool IsPrimary { get; set; }
    public string UserId { get; set; }
}