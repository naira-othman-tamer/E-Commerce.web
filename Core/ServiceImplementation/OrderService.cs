using Domain.Models.OrderModule;
using ServiceImplementation.Specifications.OrderModuleSpecifications;
using Shared.DTOs.OrderDTOs;
namespace ServiceImplementation;
public class OrderService(IUnitOfWork unitOfWork, IMapper mapper, IBasketRepository basketRepository) : IOrderService
{
    /// <summary>
    /// 1- Map Address to Order Address, 2- Get Basket => Create Order Item List => Add Order Items, 3- Get Delivery method, 4- Calculate SubTotal 
    /// </summary>
    /// <param name="orderDto"></param>
    /// <param name="Email"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<OrderToReturnDto> CreateOrderAsync(OrderRequestDto orderDto, string Email)
    {
        var OrderAddress = mapper.Map<AddressDto, OrderAddress>(orderDto.Address);
        var basket = await basketRepository.GetBasketAsync(orderDto.BasketId) 
            ?? throw new BasketNotFoundException(orderDto.BasketId);
        List<OrderItem> orderItems = [];
        var productRepo = unitOfWork.GetRepository<Product, int>();
        foreach (var item in basket.Items)
        {
            var product = await productRepo.GetByIdAsync(item.Id) ?? throw new ProductNotFoundException(item.Id);
            orderItems.Add(CreateOrdetItem(item, product));
        }
        var DeliveryMethod =  await unitOfWork
                            .GetRepository<DeliveryMethod, int>()
                            .GetByIdAsync(orderDto.DeliveryMethodId)
                            ?? throw new DeliveryMethodNotFoundException(orderDto.DeliveryMethodId);
        var SubTotal = orderItems.Sum(i=> i.Quantity *  i.Price);
        var newOrder = new Order(Email, OrderAddress, DeliveryMethod, orderItems, SubTotal); 
        await unitOfWork.GetRepository<Order, Guid>().AddAsync(newOrder);
        await unitOfWork.SaveChangesAsync();
        return mapper.Map<Order, OrderToReturnDto>(newOrder);
     }

    private static OrderItem CreateOrdetItem(BasketItem item, Product product)
    {
        return new OrderItem()
        {
            Product = new ProductItemOrdered()
            {
                ProductId = product.Id,
                PictureUrl = product.PictureUrl,
                ProductName = product.Name,
            },
            Price = product.Price,
            Quantity = item.Quantity,
        };
    }

    public async Task<IEnumerable<DeliveryMethodDTo>> GetDeliveryMethodsAsync()
    {
        var deliveryMethods = await unitOfWork.GetRepository<DeliveryMethod, int>().GetAllAsync();
        return mapper.Map<IEnumerable<DeliveryMethod>, IEnumerable<DeliveryMethodDTo>>(deliveryMethods);
    }

    public async Task<IEnumerable<OrderToReturnDto>> GetAllOrdersAsync(string Email)
    {
        var specification = new OrderSpecifications(Email);
        var Orders = await unitOfWork.GetRepository<Order, Guid>().GetAllAsync(specification);
        return mapper.Map<IEnumerable<Order>, IEnumerable<OrderToReturnDto>>(Orders);
    }

    public async Task<OrderToReturnDto> GetOrdersByIdAsync(Guid Id)
    {
        var specification = new OrderSpecifications(Id);
        var Orders = await unitOfWork.GetRepository<Order, Guid>().GetByIdAsync(specification);
        return mapper.Map<Order, OrderToReturnDto>(Orders);
    }
}
