namespace FinBTech.Domain.Contracts.Repositories;

public interface IDataRepository
{
    public Task<IEnumerable<DataEntity>> GetAsync(DataFilter? filter, int count, CancellationToken cancellationToken = default);

    public Task SaveAsync(IEnumerable<DataEntity> entities, CancellationToken cancellationToken = default);

    public Task ClearAsync(CancellationToken cancellationToken = default);
}