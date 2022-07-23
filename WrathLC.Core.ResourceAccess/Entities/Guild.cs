using System;
using WrathLc.Common.Utilities.DataContracts;

namespace WrathLc.Core.ResourceAccess.Entities;

public class Guild : IUnique<int>, ICreated, IUpdated, INamed, ISoftDelete
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string Name { get; set; }
    public bool Deleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public ulong DiscordServerId { get; set; }
    public DiscordServer DiscordServer { get; set; }
}