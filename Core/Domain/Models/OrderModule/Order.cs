namespace Domain.Models.OrderModule;
public class Order : BaseEntity<Guid>
{
    public string UserEmail { get; set; } = default!;
    public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
    public OrderStatus Status { get; set; }
    public OrderAddress Address { get; set; }
    public DeliveryMethod DeliveryMethod { get; set; } = default!;
    public int DeliveryMethodId{ get; set; }
    public ICollection<OrderItem> Items { get; set; } = [];
    public decimal SubTotal { get; set; } //=> Price of items
    //[NotMapped]
    //public decimal Total { get => SubTotal + DeliveryMethod.Price; } 
    public decimal GetTotal() => SubTotal + DeliveryMethod.Price;
}
