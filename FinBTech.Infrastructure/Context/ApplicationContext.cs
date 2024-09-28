namespace FinBTech.Infrastructure.Context;

public class ApplicationContext : DbContext
{
    public DbSet<DataEntity> Data { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}