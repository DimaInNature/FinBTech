namespace FinBTech.Infrastructure.Context;

public class LoggingContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<LogEntity> Logs { get; set; }

    public LoggingContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Database"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new LogEntityConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}