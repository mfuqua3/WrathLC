using WrathLC.Utility.Common.DataContracts.Interfaces;

namespace WrathLC.DataEngine.Database;

public class ItemSocket : IUnique<int>, INamed
{
    public int Id { get; set; }
    public string Name { get; set; }
}