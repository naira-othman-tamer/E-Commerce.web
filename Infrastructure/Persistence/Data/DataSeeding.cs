using Domain.Contracts;
using Domain.Models.ProductModule;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
namespace Persistence.Data;

public class DataSeeding(StoreDbContext _dbContext) : IDataSeeding {
    public async Task DataSeedAsync(){
        try {
            if (_dbContext.Database.GetPendingMigrations().Any()){
                await _dbContext.Database.MigrateAsync();
            }

            if (!await _dbContext.ProductBrands.AnyAsync()) {
                //var productBrandData = await File
                //      .ReadAllTextAsync(@"..\Infrastructure\Persistence\Datavar productBrandData = await File
                var productBrandData = File
                      .OpenRead(@"..\Infrastructure\Persistence\Data\DataSeed\brands.json");
                var productBrands = await JsonSerializer
                                         .DeserializeAsync<List<ProductBrand>>(productBrandData);
                if (productBrands is not null && productBrands.Any()) {
                    _dbContext.ProductBrands.AddRange(productBrands);
                }
            }

            if (!await _dbContext.ProductTypes.AnyAsync()) {
                var productTypeData = await File
                       .ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\DataSeed\types.json");
                var productTypes = JsonSerializer
                                         .Deserialize<List<ProductType>>(productTypeData);
                if (productTypes is not null && productTypes.Any()) {
                    _dbContext.ProductTypes.AddRange(productTypes);
                }
            }

            if (!await _dbContext.Products.AnyAsync()) {
                var productData = await File
                    .ReadAllTextAsync(@"..\Infrastructure\Persistence\Data\DataSeed\products.json");
                var products = JsonSerializer
                                         .Deserialize<List<Product>>(productData);
                if (products is not null && products.Any()) {
                    _dbContext.Products.AddRange(products);
                }
            }
                await _dbContext.SaveChangesAsync();
         }
        catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
     }
 }


