using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DTOs;
namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController (IServiceManager _serviceManager) :ControllerBase
{
    [HttpGet()]
    public async Task <ActionResult<IEnumerable<ProductDto>>> GetAllProducts()
    {
        var products= await _serviceManager.ProductService.GetAllProductsAsync();
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
