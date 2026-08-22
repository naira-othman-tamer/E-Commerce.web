using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text.Json;
namespace Persistence.Data;

public class DataSeeding(StoreDbContext _dbContext) : IDataSeeding
{
    public async Task DataSeedAsync()
    {
        try
        {
            if (_dbContext.Database.GetPendingMigrations().Any())
            {
                _dbContext.Database.Migrate();
            }

            if (!_dbContext.ProductBrands.Any())
            {
                var productBrandData = File
                                        .ReadAllText(@"..\Infrastructure\Persistence\Data\DataSeedAsync\brands.json");
                var productBrands = JsonSerializer
                                         .Deserialize<List<ProductBrand>>(productBrandData);
                if (productBrands is not null && productBrands.Any())
                {
                    _dbContext.ProductBrands.AddRange(productBrands);
                }
            }

            if (!_dbContext.ProductTypes.Any())
            {

                var productTypeData = File
                                        .ReadAllText(@"..\Infrastructure\Persistence\Data\DataSeedAsync\types.json");
                var productTypes = JsonSerializer
                                         .Deserialize<List<ProductType>>(productTypeData);
                if (productTypes is not null && productTypes.Any())
                {
                    _dbContext.ProductTypes.AddRange(productTypes);
                }
            }

            if (!_dbContext.Products.Any())
            {

                var productData = File
                                        .ReadAllText(@"..\Infrastructure\Persistence\Data\DataSeedAsync\products.json");
                var products = JsonSerializer
                                         .Deserialize<List<Product>>(productData);
                if (products is not null && products.Any())
                {
                    _dbContext.Products.AddRange(products);
                }
            }

                await _dbContext.SaveChangesAsync();

         }
        catch (Exception ex)
        {

        }
     }
       
 }


