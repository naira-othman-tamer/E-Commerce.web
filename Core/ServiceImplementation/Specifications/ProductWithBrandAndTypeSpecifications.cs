using Domain.Models;
using Shared.Enums;

namespace ServiceImplementation.Specifications;
/// <summary>
/// Defines a specification for retrieving products with their associated
/// brand and type, optionally filtered by brand ID and/or type ID.
/// </summary>
public class ProductWithBrandAndTypeSpecifications : BaseSpecification<Product, int>
{
    /// <summary>
    /// Initializes a specification for retrieving products with their associated
    /// brand and type, optionally filtering the results by brand ID and type ID.
    /// </summary>
    /// <param name="BrandId">
    /// The optional ID of the brand used to filter the products.
    /// If null, products from all brands are included.
    /// </param>
    /// <param name="TypeId">
    /// The optional ID of the product type used to filter the products.
    /// If null, products from all types are included.
    /// </param>
    public ProductWithBrandAndTypeSpecifications(int? BrandId , int? TypeId, ProductSortingOptions sortingOptions) 
        : base(p=>(!BrandId.HasValue || p.BrandId==BrandId)
        &&
        (!TypeId.HasValue || p.TypeId == TypeId))
    {
        AddIncludes(p => p.ProductBrand);
        AddIncludes(p => p.ProductType);

        switch (sortingOptions)
        {
            case ProductSortingOptions.NameAsc:
                AddOrderBy(p => p.Name);
                break;
            case ProductSortingOptions.NameDesc:
                AddOrderByDescending(p => p.Name);
                break;
            case ProductSortingOptions.PriceAsc:
                AddOrderBy(p => p.Price);
                break;
            case ProductSortingOptions.PriceDesc:
                AddOrderByDescending(p => p.Price);
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// Initializes a specification for retrieving a specific product
    /// by its ID with its associated brand and type.
    /// </summary>
    /// <param name="id">The unique identifier of the product.</param>
    public ProductWithBrandAndTypeSpecifications(int id):base(p=>p.Id==id)
    {
        AddIncludes(p => p.ProductBrand);
        AddIncludes(p => p.ProductType);
    }
}
