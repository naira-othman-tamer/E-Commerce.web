namespace ServiceAbstraction;
/// <summary>
/// Provides access to the application's service implementations.
/// </summary>
public interface IServiceManager {
    /// <summary>
    /// Gets the product service used to perform product-related operations.
    /// The service instance is initialized lazily by the implementation.
    /// </summary>
    public IProductService ProductService { get; }
    public IBasketService BasketService { get; }
    public IAuthenticationService AuthenticationService { get; }
    public IOrderService OrderService { get; }
}
