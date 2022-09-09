using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.DataEngine.Database;

public class WowClass : IUnique<int>, INamed
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int WowheadFlagEnumId { get; set; }
}