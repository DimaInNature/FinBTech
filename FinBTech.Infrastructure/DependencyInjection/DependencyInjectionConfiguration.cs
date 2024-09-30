namespace FinBTech.Infrastructure.DependencyInjection;

public static class DependencyInjectionConfiguration
{
    /// <summary> Add all repositories to IoC. </summary>
    /// <param name="services"> IoC. </param>
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services.AddScoped<IDataRepository, DataRepository>();
    }

    /// <summary> Add all services to IoC. </summary>
    /// <param name="services"> IoC. </param>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services.AddScoped<IDataService, DataService>();
    }

    /// <summary> Add <see cref="DbContext"/> for application. </summary>
    /// <param name="services"> IoC. </param>
    public static IServiceCollection AddApplicationContext(this IServiceCollection services)
    {
        return services.AddDbContext<ApplicationContext>();
    }

    /// <summary> Add <see cref="DbContext"/> for logging. </summary>
    /// <param name="services"> IoC. </param>
    public static IServiceCollection AddLoggingContext(this IServiceCollection services)
    {
        return services
            .AddDbContext<LoggingContext>()
            .AddTransient<LoggingContext>();
    }
}