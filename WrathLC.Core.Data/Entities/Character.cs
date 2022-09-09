using System;
using WrathLC.Items.Data.Entities;
using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLc.Core.ResourceAccess.Entities;

public class Character : IUnique<int>, INamed, ITracked, ISoftDelete
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int WowClassId { get; set; }
    public WowClass WowClass { get; set; }
    public int? GuildUserId { get; set; }
    public bool IsPrimary { get; set; }
    public int GuildId { get; set; }
    public Guild Guild { get; set; }
    public GuildUser GuildUser { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}