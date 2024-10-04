namespace FinBTech.Api.Middlewares;

public sealed class RequestResponseLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IRequestResponseLogger _logger;

    public RequestResponseLoggingMiddleware(RequestDelegate next, IRequestResponseLogger logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var originalBodyStream = context.Response.Body;

        await using var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        var requestBody = await FormatRequest(context.Request);

        await _next(context);

        var responseBodyText = await FormatResponse(context.Response);

        _logger.LogAsync(context.Request.Path + context.Request.QueryString, requestBody, responseBodyText);

        await responseBody.CopyToAsync(originalBodyStream);
    }

    private async Task<string?> FormatRequest(HttpRequest request)
    {
        request.EnableBuffering();

        using var reader = new StreamReader(request.Body, leaveOpen: true);
        var body = await reader.ReadToEndAsync();
        request.Body.Position = 0;

        return body;
    }

    private async Task<string?> FormatResponse(HttpResponse response)
    {
        response.Body.Seek(0, SeekOrigin.Begin);
        var responseBodyText = await new StreamReader(response.Body).ReadToEndAsync();
        response.Body.Seek(0, SeekOrigin.Begin);

        return responseBodyText;
    }
}