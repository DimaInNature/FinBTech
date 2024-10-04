﻿namespace FinBTech.Domain.Contracts.Repositories;

public interface IDataRepository
{
    public Task<IEnumerable<DataEntry>> GetAsync(DataFilter? filter, CancellationToken cancellationToken = default);

    public Task SaveAsync(IEnumerable<DataEntry> entities, CancellationToken cancellationToken = default);

    public Task ClearAsync(CancellationToken cancellationToken = default);
}