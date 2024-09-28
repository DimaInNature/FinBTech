namespace FinBTech.Infrastructure.Repositories;

public class DataRepository : IDataRepository
{
    public Task ClearAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<DataEntry>> GetAsync(int? codeFilter = null, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync(IEnumerable<DataEntry> data, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}