using Shared;
using Shared.DTOs.ProductDTOs;
namespace ServiceAbstraction;
public interface IProductService{
    Task <PaginatedResult<ProductDto>> GetAllProductsAsync(ProductQueryParams queryParams);
    Task <ProductDto> GetProductByIdAsync(int Id);
    Task<IEnumerable<TypeDto>> GetAllTypesAsync();
    Task<IEnumerable<BrandDto>> GetAllBrandsAsync();
}
