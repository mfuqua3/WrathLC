using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.Core.Utility.DataContracts.Requests;

public class CreateGuildRequest:IUserId
{
    [Required]
    public int ServerId { get; set; }
    [JsonIgnore]
    public string UserId { get; set; }
    public string Name { get; set; }
}