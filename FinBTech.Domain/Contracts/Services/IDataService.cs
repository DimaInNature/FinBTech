namespace FinBTech.Domain.Contracts.Services;

public interface IDataService
{
    public Task ReplaceAsync(IEnumerable<DataEntry> data, CancellationToken cancellationToken = default);
    public Task<IEnumerable<DataEntry>> GetAsync(DataFilter filter, CancellationToken cancellationToken = default); 
}