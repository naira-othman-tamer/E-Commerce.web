using Shared.DTOs;
namespace ServiceAbstraction;
public interface IProductService{
    Task <IEnumerable<ProductDto>> GetAllProductsAsync(int? BrandId , int? TypeId);
    Task <ProductDto> GetProductByIdAsync(int Id);
    Task<IEnumerable<TypeDto>> GetAllTypesAsync();
    Task<IEnumerable<BrandDto>> GetAllBrandsAsync();
}
