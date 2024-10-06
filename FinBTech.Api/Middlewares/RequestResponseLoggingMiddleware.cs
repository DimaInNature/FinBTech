namespace FinBTech.Api.Middlewares;

public sealed class RequestResponseLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IRequestResponseLogger _logger;

    private const int MaxBodySizeToRead = 1024 * 4; // 4 KB

    public RequestResponseLoggingMiddleware(
        RequestDelegate next, 
        IRequestResponseLogger logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        var originalRequestBody = context.Request.Body;
        using var requestBodyStream = new MemoryStream();
        await context.Request.Body.CopyToAsync(requestBodyStream);
        context.Request.Body = requestBodyStream;
        requestBodyStream.Seek(0, SeekOrigin.Begin);

        string requestBodyText = await ReadStreamAsync(requestBodyStream);

        requestBodyStream.Seek(0, SeekOrigin.Begin);
        context.Request.Body = requestBodyStream;

        var originalResponseBody = context.Response.Body;
        using var responseBodyStream = new MemoryStream();
        context.Response.Body = responseBodyStream;

        await _next(context);

        responseBodyStream.Seek(0, SeekOrigin.Begin);
        string responseBodyText = await ReadStreamAsync(responseBodyStream);

        responseBodyStream.Seek(0, SeekOrigin.Begin);
        await responseBodyStream.CopyToAsync(originalResponseBody);

        _ = _logger.LogAsync($"{context.Request.Path}{context.Request.QueryString}", requestBodyText, responseBodyText);
    }

    private async Task<string> ReadStreamAsync(Stream stream)
    {
        stream.Seek(0, SeekOrigin.Begin);
        using var reader = new StreamReader(stream, leaveOpen: true);

        var buffer = new char[MaxBodySizeToRead];
        var readLength = await reader.ReadBlockAsync(buffer, 0, MaxBodySizeToRead);

        var result = new string(buffer, 0, readLength);

        if (stream.Length > MaxBodySizeToRead)
        {
            result += "...[truncated]";
        }

        stream.Seek(0, SeekOrigin.Begin);
        return result;
    }
}