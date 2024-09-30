namespace FinBTech.Infrastructure.Logging;

public sealed class RequestResponseLogger : IRequestResponseLogger
{
    private readonly LoggingContext _context;

    public RequestResponseLogger(LoggingContext context)
    {
        _context = context;
    }

    public async Task LogAsync(string requestUri, string requestBody, string response,
        CancellationToken cancellationToken = default)
    {
        var logEntity = new LogEntity()
        {
            RequestUri = requestUri,
            RequestBody = requestBody,
            Response = response,
            Date = DateTime.UtcNow
        };

        await _context.Logs.AddAsync(logEntity, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }
}