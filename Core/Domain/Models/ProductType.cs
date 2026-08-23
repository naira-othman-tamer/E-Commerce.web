namespace Domain.Models;

public class ProductType : BaseEntity<int>{
    public string Name { get; set; } = default!;
    public ICollection<Product> Products { get; set;} = new List<Product>();
}
