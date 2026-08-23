using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Persistence.Data.Configurations;

public class ProductConfigurations : IEntityTypeConfiguration<Product>{
    public void Configure(EntityTypeBuilder<Product> builder){
        builder.HasOne(p => p.ProductBrand)
               .WithMany(p => p.Products)
               .HasForeignKey(p => p.BrandId);
        builder.HasOne(p=>p.ProductType)
               .WithMany(T=>T.Products)
               .HasForeignKey(p => p.TypeId);
        builder.Property(p => p.Price)
               .HasColumnType("decimal(10,2)");
    }
}
