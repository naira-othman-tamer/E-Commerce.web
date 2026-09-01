namespace ServiceImplementation.Specifications.ProductModuleSpecifications;
public class ProductCountSpecification : BaseSpecification<Product, int>
{
    public ProductCountSpecification(ProductQueryParams queryParams)
        : base(p =>
        (!queryParams.BrandId.HasValue || p.BrandId == queryParams.BrandId)
        &&
        (!queryParams.TypeId.HasValue || p.TypeId == queryParams.TypeId)
        &&
        (String.IsNullOrWhiteSpace(queryParams.SearchValue) ||
        p.Name.ToLower().Contains(queryParams.SearchValue.ToLower()))
        )
    {
    }
}
