using System;
using WrathLc.Common.Utilities.DataContracts;

namespace WrathLc.Core.ResourceAccess.Entities;

public class DiscordServerUser : IUnique<int>, ISoftDelete
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public ulong DiscordServerId { get; set; }
    public bool Deleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}