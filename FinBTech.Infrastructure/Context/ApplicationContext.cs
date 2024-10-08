﻿namespace FinBTech.Infrastructure.Context;

public sealed class ApplicationContext : DbContext
{
    private readonly IConfiguration _configuration;

    public DbSet<DataEntity> Data { get; set; }

    public ApplicationContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Database"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new DataEntityConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}