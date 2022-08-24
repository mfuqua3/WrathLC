using System;
using WrathLc.Common.Utilities.DataContracts.Interfaces;

namespace WrathLc.Core.ResourceAccess.Entities;

public class Guild : IUnique<int>, ICreated, IUpdated, INamed, ISoftDelete
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public ulong DiscordServerId { get; set; }
    public DiscordServer DiscordServer { get; set; }
}