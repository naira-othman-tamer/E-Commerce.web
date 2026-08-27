namespace ServiceImplementation.MappingProfiles;

public class PictureUrlResolver(Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor)//, IConfiguration _configuration)
                             : IValueResolver<Product, ProductDto, string>
{
    public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context){
        if (string.IsNullOrEmpty(source.PictureUrl)){
            return string.Empty;
        }
        var request = httpContextAccessor.HttpContext!.Request;
        var pictureUrl = $"{request.Scheme}://{request.Host}/{source.PictureUrl}";
        //var pictureUrl = $"{_configuration.GetSection("Urls")["BaseUrl"]}{source.PictureUrl}";
        return pictureUrl;
    }
}
