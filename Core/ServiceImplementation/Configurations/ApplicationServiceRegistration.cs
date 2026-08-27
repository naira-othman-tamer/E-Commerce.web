namespace ServiceImplementation.Configurations;
public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices (this IServiceCollection Services)
    {
        Services.AddScoped<IServiceManager, ServiceManager>();
        Services.AddAutoMapper(
           cfg => { },
           typeof(ProductProfile).Assembly);

        return Services;
    }
}
