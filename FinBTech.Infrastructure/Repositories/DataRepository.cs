namespace FinBTech.Infrastructure.Repositories;

public class DataRepository : IDataRepository
{
    private readonly ApplicationContext _context;

    public DataRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DataEntry>> GetAsync(DataFilter? filter, CancellationToken cancellationToken = default)
    {
        if(filter?.Limit < 1)
        {
            return [];
        }

        var query = _context.Data
            .AsNoTracking()
            .AsQueryable();

        if(filter is null)
        {
            var queryResult = await query.Skip(filter.Offset).Take(filter.Limit).ToListAsync();

            var result = queryResult.Adapt<IEnumerable<DataEntry>>();

            return result;
        }

        if (filter.Id.HasValue)
        {
            query = query.Where(entity => entity.Id == filter.Id.Value);
        }

        if (filter.Code.HasValue)
        {
            query = query.Where(entity => entity.Code == filter.Code.Value);
        }

        if (!string.IsNullOrWhiteSpace(filter.Value))
        {
            query = query.Where(entity => entity.Value == filter.Value);
        }

        query = query.Skip(filter.Offset).Take(filter.Limit);

        var entities = await query.ToListAsync(cancellationToken);

        var data = entities.Adapt<IEnumerable<DataEntry>>();

        return data;
    }

    public async Task SaveAsync(IEnumerable<DataEntry> data, CancellationToken cancellationToken = default)
    {
        if (!data.Any())
        {
            return;
        }

        var entities = data.Adapt<IEnumerable<DataEntity>>();

        await _context.AddRangeAsync(entities, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task ClearAsync(CancellationToken cancellationToken = default)
    {
        await _context.Data.ExecuteDeleteAsync(cancellationToken);
    }
}