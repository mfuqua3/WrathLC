using System;
using System.Collections.Generic;
using WrathLc.Common.Utilities.DataContracts;

namespace WrathLc.Core.ResourceAccess.Entities;

public class DiscordServer : IUnique<ulong>, ICreated, IUpdated, INamed
{
    public ulong Id { get; set; } 
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<DiscordServerUser> Users { get; set; }
}