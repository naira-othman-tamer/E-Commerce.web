namespace Domain.Models.BasketModule;
public class CustomerBasket
{
    public string Id { get; set; } // Created From Front => GUID 
    public ICollection<BasketItem> Items { get; set; } = [];
}
