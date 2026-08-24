using Domain.Models;

namespace ServiceImplementation.Specifications;
/// <summary>
/// Defines specifications for retrieving products with their associated
/// brand and type, optionally filtered by product ID.
/// </summary>
public class ProductWithBrandAndTypeSpecifications : BaseSpecification<Product, int>
{
    /// <summary>
    /// Initializes a specification for retrieving products
    /// with their associated brand and type.
    /// </summary>
    public ProductWithBrandAndTypeSpecifications() 
        : base(null)
    {
        AddIncludes(p => p.ProductBrand);
        AddIncludes(p => p.ProductType);
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
