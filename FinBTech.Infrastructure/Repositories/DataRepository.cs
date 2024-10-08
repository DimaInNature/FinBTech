namespace FinBTech.Infrastructure.Repositories;

public class DataRepository : IDataRepository
{
    private readonly ApplicationContext _context;

    public DataRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<DataEntry>> GetAsync(DataFilter filter, CancellationToken cancellationToken = default)
    {
        if(filter is { Limit: < 1} or null)
            return [];
        
        var query = _context.Data
            .AsNoTracking()
            .AsQueryable();

        if (filter.Id.HasValue)
        {
            query = query.Where(entity => entity.Id == filter.Id.Value);
        }

        if (filter.Code.HasValue)
        {
            query = query.Where(entity => entity.Code == filter.Code.Value);
        }

        if (string.IsNullOrWhiteSpace(filter.Value) is false)
        {
            query = query.Where(entity => entity.Value == filter.Value);
        }

        query = query.Skip(filter.Offset).Take(filter.Limit);

        var entities = await query.ToListAsync(cancellationToken);

        var data = entities.Adapt<IEnumerable<DataEntry>>();

        return data;
    }

    public async Task ReplaceAsync(IEnumerable<DataEntry> data, CancellationToken cancellationToken = default)
    {
        if (data.Any() is false)
            return;
        
        var entities = data.Adapt<IEnumerable<DataEntity>>();

        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            await _context.Data.ExecuteDeleteAsync(cancellationToken);

            await _context.BulkInsertAsync(entities, cancellationToken: cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            await transaction.CommitAsync(cancellationToken);
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);

            throw;
        }
    }
}