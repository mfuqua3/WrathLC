namespace WrathLC.Utility.Common.DataContracts.Interfaces;

public interface ISoftDelete
{
    bool IsDeleted { get; set; }

    public DateTime? DeletedAt { get; set; }
}