namespace FinBTech.Infrastructure.Repositories;

public class DataRepository : IDataRepository
{
    private readonly ApplicationContext _context;

    public DataRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DataEntity>> GetAsync(DataFilter? filter, int count, CancellationToken cancellationToken = default)
    {
        if(count < 1)
        {
            return [];
        }

        var query = _context.Data
            .AsNoTracking()
            .AsQueryable();

        if(filter is null)
        {
            return [.. query.Take(count)];
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

        query = query.Take(count);

        return await query.ToListAsync(cancellationToken);
    }

    public async Task SaveAsync(IEnumerable<DataEntity> entities, CancellationToken cancellationToken = default)
    {
        if (!entities.Any())
        {
            return;
        }

        await _context.AddRangeAsync(entities, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task ClearAsync(CancellationToken cancellationToken = default)
    {
        await _context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE [Data]", cancellationToken);
    }
}