using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.Core.Utility.DataContracts.Requests;

public class CreateCharacterRequest : IGuildId, IUserId
{
    [JsonIgnore]
    public string UserId { get; set; }
    [JsonIgnore]
    public int GuildId { get; set; }

    [Required(ErrorMessage = "A name for the character must be provided.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "A class must be specified.")]
    [Range(1, 10)]
    public int ClassId { get; set; }

    [DefaultValue(false)]
    public bool AssignToMe { get; set; }

}