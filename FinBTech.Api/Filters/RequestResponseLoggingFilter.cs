namespace FinBTech.Api.Filters;

public class RequestResponseLoggingFilter : IFeatureFilter
{
    private readonly IHttpContextAccessor _httpContextAccessor;


    public RequestResponseLoggingFilter(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
    {
        var allowedMethods = context.Parameters.GetRequiredSection("AllowedMethods").Get<string[]>();

        var httpContext = _httpContextAccessor.HttpContext!;
        bool methodAllowed = allowedMethods != null && allowedMethods.Contains(httpContext.Request.Method);

        return Task.FromResult(methodAllowed);
    }
}