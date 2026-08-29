using Order = Domain.Models.OrderModule.Order;
namespace Persistence.Data.Configurations;
public class OrderCofigurations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.Property(o=>o.SubTotal).HasColumnType("decimal(8,2)");
        builder.HasMany(o => o.Items).WithOne();
        builder.HasOne(o=>o.DeliveryMethod).WithMany().HasForeignKey(o=>o.DeliveryMethodId);
        builder.OwnsOne(O => O.Address);
    }
}

