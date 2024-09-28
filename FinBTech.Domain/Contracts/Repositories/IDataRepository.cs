namespace FinBTech.Domain.Contracts.Repositories;

public interface IDataRepository
{
    public Task ClearAsync(CancellationToken cancellationToken = default);
    public Task SaveAsync(IEnumerable<DataEntry> entries, CancellationToken cancellationToken = default);
    public Task<IEnumerable<DataEntry>> GetAsync(int? codeFilter = null, CancellationToken cancellationToken = default);
}