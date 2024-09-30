namespace FinBTech.Api.Configuration;

internal static class RequestResponseLoggingConfiguration
{
    public static IServiceCollection AddRequestResponseLogging(this IServiceCollection services)
    {
        return services
            .AddTransient<IRequestResponseLogger, RequestResponseLogger>()
            .AddLoggingContext();
    }

    public static IApplicationBuilder UseRequestResponseLogging(this IApplicationBuilder app)
    {
        return app.UseMiddleware<RequestResponseLoggingMiddleware>();
    }
}