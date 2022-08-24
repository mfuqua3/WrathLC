namespace WrathLC.Utility.Common.DataContracts.Models;

public class PagedListModel<T>
{
    public int Page { get; set; }

    public int PageSize { get; set; }

    public int PageCount
    {
        get
        {
            if (TotalCount == 0)
            {
                return 1;
            }

            return TotalCount % PageSize != 0
                ? TotalCount / PageSize + 1
                : TotalCount / PageSize;
        }

    }

    public int TotalCount { get; set; }

    public int ItemCount => Items.Count;

    public List<T> Items { get; set; }
}