namespace FinBTech.Application.Services;

public sealed class DataService : IDataService
{
    private readonly IDataRepository _repository;

    public DataService(IDataRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<DataEntry>> GetAsync(DataFilter? filter, int count = 1, CancellationToken cancellationToken = default)
    {
        if(count == 0)
        {
            return [];
        }

        var entities = await _repository.GetAsync(filter, count, cancellationToken);

        var entries = entities.Adapt<IEnumerable<DataEntry>>();

        return entries;
    }

    public async Task SaveDataAsync(IEnumerable<DataEntry> data, CancellationToken cancellationToken = default)
    {
        if(!data.Any())
        {
            return;
        }

        await _repository.ClearAsync(cancellationToken);

        var entries = data.OrderBy(entry => entry.Code);

        var entities = entries.Adapt<IEnumerable<DataEntity>>();

        await _repository.SaveAsync(entities, cancellationToken);
    }
}