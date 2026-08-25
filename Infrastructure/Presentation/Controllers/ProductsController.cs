using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DTOs;
using Shared.Enums;
namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController (IServiceManager _serviceManager) :ControllerBase
{
    [HttpGet()]
    public async Task <ActionResult<IEnumerable<ProductDto>>> GetAllProducts(
        int? BrandId,
        int? TypeId,
        ProductSortingOptions sortingOptions)
    {
        var products= await _serviceManager
            .ProductService
            .GetAllProductsAsync(BrandId, TypeId, sortingOptions);
        return Ok(products);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetProduct(int id)
    {
        var product = await _serviceManager.ProductService.GetProductByIdAsync(id);
        return Ok(product);
    }

    [HttpGet("types")]
    public async Task<ActionResult<IEnumerable<TypeDto>>> GetTypes()
    {
        var types =await _serviceManager.ProductService.GetAllTypesAsync();
        return Ok(types);
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IEnumerable<BrandDto>>> GetBrands()
    {
        var brands =await _serviceManager.ProductService.GetAllBrandsAsync();
        return Ok(brands);
    }
}
