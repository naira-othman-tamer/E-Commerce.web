namespace ServiceImplementation;
public class ServiceManager
    (IUnitOfWork _unitOfWork,
    IBasketRepository _basketRepository,
    UserManager<ApplicationUser> userManager,
    IMapper _mapper) : IServiceManager
{
    private readonly Lazy<IProductService> _lazyProductService = 
        new Lazy<IProductService>(() => new ProductService(_unitOfWork, _mapper));
    public IProductService ProductService => _lazyProductService.Value;

    private readonly Lazy<IBasketService> _lazyBasketService = 
        new Lazy<IBasketService>(() => new BasketService(_basketRepository, _mapper));
    public IBasketService BasketService => _lazyBasketService.Value;

    private readonly Lazy<IAuthenticationService> _lazyAuthService = 
        new Lazy<IAuthenticationService>(() => new AuthenticationService(userManager, _mapper));
    public IAuthenticationService AuthenticationService => _lazyAuthService.Value;
}
