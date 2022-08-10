namespace WrathLc.Common.Utilities.DataContracts;

public interface ISoftDelete
{
    bool Deleted { get; set; }
    DateTime? DeletedAt { get; set; }
}