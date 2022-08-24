using System;
using WrathLc.Common.Utilities.DataContracts.Interfaces;

namespace WrathLc.Core.ResourceAccess.Entities;

public class GuildUser : IUnique<int>, ICreated, IUpdated, ISoftDelete, INamed
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string Name { get; set; }
}