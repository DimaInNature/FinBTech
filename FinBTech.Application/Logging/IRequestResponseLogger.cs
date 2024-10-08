namespace FinBTech.Application.Logging;

public interface IRequestResponseLogger
{
    public Task LogAsync(string requestUri, string requestBody, string response,
        CancellationToken cancellationToken = default);
}