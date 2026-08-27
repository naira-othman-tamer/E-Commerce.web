namespace Persistence.Identity;
public class StoreIdentityDbContext(DbContextOptions<StoreIdentityDbContext> contextOptions) 
    : IdentityDbContext<ApplicationUser>(contextOptions)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Address>().ToTable("Addresses"); 
        builder.Entity<ApplicationUser>().ToTable("users"); 
        builder.Entity<IdentityRole>().ToTable("Roles"); 
        builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        builder.Ignore<IdentityUserClaim<string>>();
        builder.Ignore<IdentityUserToken<string>>();
        builder.Ignore<IdentityUserLogin<string>>();
        builder.Ignore<IdentityRoleClaim<string>>();
    }
}
