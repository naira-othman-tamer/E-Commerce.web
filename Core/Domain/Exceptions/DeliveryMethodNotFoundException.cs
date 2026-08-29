namespace Domain.Exceptions;
public sealed class DeliveryMethodNotFoundException(int id) : NotFoundException($"Delivery Method with id {id} Not Found")
{
}
