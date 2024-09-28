namespace FinBTech.Application.Services;

public sealed class DataService : IDataService
{
    private readonly IDataRepository _repository;

    public DataService(IDataRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<DataEntry>> GetAsync(int? codeFilter = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task SaveDataAsync(IEnumerable<DataEntry> data, CancellationToken cancellationToken = default)
    {
        var entries = data.OrderBy(entry => entry.Code);

        throw new NotImplementedException();
    }
}