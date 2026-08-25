using Shared.DTOs;
using Shared.Enums;
namespace ServiceAbstraction;
public interface IProductService{
    Task <IEnumerable<ProductDto>> GetAllProductsAsync(int? BrandId , int? TypeId, ProductSortingOptions sortingOptions);
    Task <ProductDto> GetProductByIdAsync(int Id);
    Task<IEnumerable<TypeDto>> GetAllTypesAsync();
    Task<IEnumerable<BrandDto>> GetAllBrandsAsync();
}
