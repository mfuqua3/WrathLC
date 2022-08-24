using System;
using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLc.Core.ResourceAccess.Entities;

public class DiscordServerUser : IUnique<int>, ISoftDelete
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public int DiscordServerId { get; set; }
    public DiscordServer DiscordServer { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}