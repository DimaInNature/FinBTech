namespace FinBTech.Application.Contracts.Logging;

public interface IRequestResponseLogger
{
    public Task LogAsync(string requestUri, string requestBody, string response,
        CancellationToken cancellationToken = default);
}