using Persistence.Identity;
using System.Text.Json;
namespace Persistence.Data;
public class DataSeeding(
    StoreDbContext _dbContext,
    UserManager<ApplicationUser> _userManager,
    RoleManager<IdentityRole> _roleManager,
    StoreIdentityDbContext _identityDbContext) : IDataSeeding
{
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

    public async Task IdentityDataSeedAsync()
    {
        try
        {

            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
            }
            if (!_userManager.Users.Any())
            {
                var User01 = new ApplicationUser()
                {
                    Email = "Adhm@Gmail.com",
                    DisplayName = "Adhm Hossam",
                    PhoneNumber = "0123456789",
                    UserName = "AdhmHoassam"
                };
                var User02 = new ApplicationUser()
                {
                    Email = "Sherweet@Gmail.com",
                    DisplayName = "Sherweet Hossam",
                    PhoneNumber = "0123456789",
                    UserName = "SherweetHoassam"
                };

                var result01 =  await _userManager.CreateAsync(User01, "P@$$w0rd");
                if (result01.Succeeded)
                    await _userManager.AddToRoleAsync(User01, "Admin");
                else
                    Console.WriteLine(string.Join(", ",
                        result01.Errors.Select(e => e.Description)));

                var result02 = await _userManager.CreateAsync(User02, "P@$$w0rd");
                if (result02.Succeeded)
                    await _userManager.AddToRoleAsync(User02, "SuperAdmin");
                else
                    Console.WriteLine(string.Join(", ", result02.Errors.Select(e => e.Description)));
            }

            await _identityDbContext.SaveChangesAsync();

        }
        catch (Exception ex)
        {

            throw;
        }
    }
}


