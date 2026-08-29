namespace Domain.Models.OrderModule;
public class Order : BaseEntity<Guid>
{
    public Order() {}
    public Order(
        string userEmail,
        OrderAddress address,
        DeliveryMethod deliveryMethod,
        ICollection<OrderItem> items
        , decimal subTotal)
    {
        UserEmail = userEmail;
        Address = address;
        DeliveryMethod = deliveryMethod;
        Items = items;
        SubTotal = subTotal;
    }

    public string UserEmail { get; set; } = default!;
    public OrderAddress Address { get; set; } = default!;
    public DeliveryMethod DeliveryMethod { get; set; } = default!;
    public ICollection<OrderItem> Items { get; set; } = [];
    public decimal SubTotal { get; set; } //=> Price of items
    public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
    public OrderStatus Status { get; set; }
    public int DeliveryMethodId{ get; set; }
    //[NotMapped]
    //public decimal Total { get => SubTotal + DeliveryMethod.Price; } 
    public decimal GetTotal() => SubTotal + DeliveryMethod.Price;
}
