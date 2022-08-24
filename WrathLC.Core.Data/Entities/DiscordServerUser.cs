using System;
using WrathLc.Common.Utilities.DataContracts.Interfaces;

namespace WrathLc.Core.ResourceAccess.Entities;

public class DiscordServerUser : IUnique<int>, ISoftDelete
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public ulong DiscordServerId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}