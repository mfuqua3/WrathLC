namespace WrathLc.Common.Utilities.DataContracts.Interfaces;

public interface IPaginated
{
    public int Page { get; set; }

    public int PageSize { get; set; }
}