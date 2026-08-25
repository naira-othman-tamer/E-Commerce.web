using Shared.Enums;
namespace Shared;
public class ProductQueryParams
{
    public int? TypeId { get; set; }
    public int? BrandId { get; set; }
    public string? SearchValue { get; set; }
    public ProductSortingOptions sortingOptions { get; set; }
    public int PageIndex { get; set; } = 1;

    private const int _defaultPageSize = 5;
    private const int _maxPageSize = 10;
    private int _pageSize = _defaultPageSize;
    public int PageSize
    { 
        get => _pageSize;
        set { _pageSize = value > _maxPageSize ? _maxPageSize : value; }
    }
}
