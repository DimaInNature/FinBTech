namespace FinBTech.Api.Configuration;

public static class MappingConfiguration
{
    public static IServiceCollection AddMappingConfiguration(this IServiceCollection services)
    {
        GetDataByFilterRequestMappingConfig.ConfigureMapping();

        return services;
    }
}