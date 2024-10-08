namespace FinBTech.Application.Services;

public sealed class DataService : IDataService
{
    private readonly IDataRepository _repository;

    public DataService(IDataRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DataEntry>> GetAsync(DataFilter filter, CancellationToken cancellationToken = default)
    {
        if(filter is { Limit: < 1 } or null)
            return [];
        
        var entries = await _repository.GetAsync(filter, cancellationToken);

        return entries;
    }

    public async Task ReplaceAsync(IEnumerable<DataEntry> data, CancellationToken cancellationToken = default)
    {
        if(data.Any() is false)
            return;
        
        data = data.OrderBy(entry => entry.Code);

        await _repository.ReplaceAsync(data, cancellationToken);
    }
}