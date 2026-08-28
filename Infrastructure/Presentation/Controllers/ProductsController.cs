using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using Shared.DTOs.ProductDTOs;
namespace Presentation.Controllers;

public class ProductsController (IServiceManager _serviceManager) :ApiBaseController
{
    [HttpGet()]
    public async Task <ActionResult<PaginatedResult<ProductDto>>> GetAllProducts([FromQuery]ProductQueryParams queryParams)
    {
        var products= await _serviceManager
            .ProductService
            .GetAllProductsAsync(queryParams);
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
