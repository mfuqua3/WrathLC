using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.Items.Data.Entities;

public class WowClass : IUnique<int>, INamed
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int WowheadFlagEnumId { get; set; }
}