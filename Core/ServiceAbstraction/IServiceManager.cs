namespace ServiceAbstraction;
public interface IServiceManager{
    /// <summary>
    /// initialize using Lazy attribute
    /// </summary>
    public IProductService ProductService { get; }
}
