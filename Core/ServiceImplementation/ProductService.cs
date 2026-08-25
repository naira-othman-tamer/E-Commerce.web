using AutoMapper;
using Domain.Contracts;
using Domain.Models;
using ServiceAbstraction;
using ServiceImplementation.Specifications;
using Shared;
using Shared.DTOs;
namespace ServiceImplementation;
/// <summary>
/// Provides application-level operations for retrieving products,
/// brands, and product types.
/// </summary>
public class ProductService(
    IUnitOfWork _unitOfWork,
    IMapper _mapper ) : IProductService {
    /// <summary>
    /// Retrieves products along with their associated brand and type,
    /// optionally filtered by brand ID and/or type ID, then maps them to product DTOs.
    /// </summary>
    /// <param name="BrandId">
    /// The optional ID of the brand used to filter the products.
    /// If null, products from all brands are included.
    /// </param>
    /// <param name="TypeId">
    /// The optional ID of the product type used to filter the products.
    /// If null, products from all types are included.
    /// </param>
    /// <returns>
    /// A collection of <see cref="ProductDto"/> objects representing the filtered products.
    /// </returns>
    public async Task<PaginatedResult<ProductDto>> GetAllProductsAsync(ProductQueryParams queryParams)
    {
        var Repo = _unitOfWork.GetRepository<Product, int>();
        var specifications = new ProductWithBrandAndTypeSpecifications(queryParams);
        var Products = await Repo.GetAllAsync(specifications);
        int ProductsCount = Products.Count();
        int TotalProductsCount = await Repo.CountAsync(new ProductCountSpecification(queryParams));
        IEnumerable<ProductDto> productsList = _mapper
                               .Map<IEnumerable<Product>, IEnumerable<ProductDto>>(Products);
        return new PaginatedResult<ProductDto>(
            queryParams.PageIndex,
            ProductsCount,
            TotalProductsCount,
            productsList );
    }

    /// <summary>
    /// Retrieves all product brands and maps them to brand DTOs.
    /// </summary>
    /// <returns>
    /// A collection of <see cref="BrandDto"/> objects representing all product brands.
    /// </returns>
    public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync() {
        var Brands = await _unitOfWork
            .GetRepository<ProductBrand, int>()
            .GetAllAsync();
        return _mapper.Map <IEnumerable<ProductBrand>, IEnumerable<BrandDto>>(Brands);
    }

    /// <summary>
    /// Retrieves all product types and maps them to type DTOs.
    /// </summary>
    /// <returns>
    /// A collection of <see cref="TypeDto"/> objects representing all product types.
    /// </returns>
    public async Task<IEnumerable<TypeDto>> GetAllTypesAsync() {
        var ProductTypes = await _unitOfWork
            .GetRepository<ProductType, int>()
            .GetAllAsync();
        return _mapper
               .Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(ProductTypes);
    }

    /// <summary>
    /// Retrieves a specific product by its ID along with its associated
    /// brand and type, then maps it to a product DTO.
    /// </summary>
    /// <param name="Id">The unique identifier of the product.</param>
    /// <returns>
    /// A <see cref="ProductDto"/> representing the requested product.
    /// </returns>
    public async Task<ProductDto> GetProductByIdAsync(int Id) {
        var specifications = new ProductWithBrandAndTypeSpecifications(Id);
        var product = await _unitOfWork
                      .GetRepository<Product, int>()
                      .GetByIdAsync(specifications);
        return _mapper.Map<Product, ProductDto>(product);
    }
}
