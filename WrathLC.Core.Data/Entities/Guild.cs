using System;
using System.Collections.Generic;
using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLc.Core.ResourceAccess.Entities;

public class Guild : IUnique<int>, ICreated, IUpdated, INamed, ISoftDelete
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string Name { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public int DiscordServerId { get; set; }
    public DiscordServer DiscordServer { get; set; }
    public List<GuildUser> GuildUsers { get; set; }
}