using System;
using System.Collections.Generic;
using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLc.Core.ResourceAccess.Entities;

public class DiscordServer : IUnique<int>, ICreated, IUpdated, INamed
{
    public int Id { get; set; }
    public ulong ServerId { get; set; } 
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public List<DiscordServerUser> Users { get; set; }
    public Guild Guild { get; set; }
}