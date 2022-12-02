namespace TShop.Contracts.Utils.Commons;

public class Pagination<T> where T : class
{
    public List<T> Data { get; set; } = new();
    public int TotalPages { get; set; } = 0;
    public int PageSize { get; set; } = 0;
    public int PageIndex { get; set; } = 0;
    public int TotalRows { get; set; } = 0;
    public bool HasNext { get; set; }
    public bool HasPrevious { get; set; }
}
