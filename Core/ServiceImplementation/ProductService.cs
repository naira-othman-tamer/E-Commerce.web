using AutoMapper;
using Domain.Contracts;
using Domain.Models;
using ServiceAbstraction;
using Shared.DTOs;
namespace ServiceImplementation;
public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper ) : IProductService {
    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync(){
        var Repo = _unitOfWork.GetRepository<Product, int>();
        var Products = await Repo.GetAllAsync();
        IEnumerable<ProductDto> productsList = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(Products);
        return productsList;
    }
    public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync() {
        var Brands = await _unitOfWork
            .GetRepository<ProductBrand, int>()
            .GetAllAsync();
        return _mapper.Map <IEnumerable<ProductBrand>, IEnumerable<BrandDto>>(Brands);
    }
    public async Task<IEnumerable<TypeDto>> GetAllTypesAsync() {
        var ProductTypes = await _unitOfWork
            .GetRepository<ProductType, int>()
            .GetAllAsync();
        return _mapper
               .Map<IEnumerable<ProductType>, IEnumerable<TypeDto>>(ProductTypes);
    }
    public async Task<ProductDto> GetProductByIdAsync(int Id) {
        var product= await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(Id);
        return _mapper.Map<Product, ProductDto>(product);
    }
}
