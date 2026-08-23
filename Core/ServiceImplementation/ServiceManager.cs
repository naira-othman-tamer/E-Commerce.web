using AutoMapper;
using Domain.Contracts;
using ServiceAbstraction;
namespace ServiceImplementation;

public class ServiceManager(IUnitOfWork _unitOfWork, IMapper _mapper) : IServiceManager{
    private readonly Lazy<IProductService> _lazyProductService = 
        new Lazy<IProductService>(() => new ProductService(_unitOfWork, _mapper));
    public IProductService ProductService => _lazyProductService.Value;
}
