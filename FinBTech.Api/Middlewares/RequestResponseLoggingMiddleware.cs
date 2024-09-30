namespace FinBTech.Api.Middlewares;

public sealed class RequestResponseLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IRequestResponseLogger _logger;

    public RequestResponseLoggingMiddleware(
        RequestDelegate next,
        IRequestResponseLogger logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var request = await FormatRequest(context.Request);

        var originalBodyStream = context.Response.Body;
        using var responseBody = new MemoryStream();
        context.Response.Body = responseBody;

        await _next(context);

        var response = await FormatResponse(context.Response);

        await _logger.LogAsync(context.Request.Path + context.Request.QueryString, request, response);
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
        var text = await new StreamReader(response.Body).ReadToEndAsync();
        response.Body.Seek(0, SeekOrigin.Begin);

        return text;
    }
}