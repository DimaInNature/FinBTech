namespace FinBTech.Application.Services;

public sealed class DataService : IDataService
{
    private readonly IDataRepository _repository;

    public DataService(IDataRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DataEntry>> GetAsync(DataFilter? filter, CancellationToken cancellationToken = default)
    {
        if(filter?.Limit == 0)
        {
            return [];
        }

        var entries = await _repository.GetAsync(filter, cancellationToken);

        return entries;
    }

    public async Task SaveDataAsync(IEnumerable<DataEntry> data, CancellationToken cancellationToken = default)
    {
        if(!data.Any())
        {
            return;
        }

        await _repository.ClearAsync(cancellationToken);

        data = data.OrderBy(entry => entry.Code);

        await _repository.SaveAsync(data, cancellationToken);
    }
}