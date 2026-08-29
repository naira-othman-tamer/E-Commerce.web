using Domain.Models.OrderModule;
using Order = Domain.Models.OrderModule.Order;

namespace Persistence.Data;

public class StoreDbContext : DbContext {
    public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductBrand> ProductBrands { get; set; }
    public DbSet<ProductType> ProductTypes { get; set; }
    public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    protected override void OnModelCreating (ModelBuilder modelBuilder) {
        //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyRefrences).Assembly);
    }
}
