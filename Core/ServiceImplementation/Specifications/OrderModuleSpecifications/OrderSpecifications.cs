namespace ServiceImplementation.Specifications.OrderModuleSpecifications;

public class OrderSpecifications : BaseSpecification<Order, Guid>
{
    public OrderSpecifications(string Email) : base(O=>O.UserEmail==Email)
    {
        AddIncludes(O => O.DeliveryMethod);
        AddIncludes(O => O.Items);
        AddOrderByDescending(O => O.OrderDate);
    }
    public OrderSpecifications(Guid Id) : base(O=>O.Id == Id)
    {
        AddIncludes(O => O.DeliveryMethod);
        AddIncludes(O => O.Items);
    }
}
