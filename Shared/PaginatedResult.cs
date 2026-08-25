namespace Shared;
public class PaginatedResult<TEntity>
{
    public PaginatedResult(int pageIndex, int pageSize, int elementCount, IEnumerable<TEntity> data)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        ElementCount = elementCount;
        Data = data;
    }

    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public int ElementCount { get; set; }
    public IEnumerable<TEntity> Data { get; set; }
}
