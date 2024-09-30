namespace FinBTech.Infrastructure.Context.Configuration;

public sealed class LogEntityConfiguration : IEntityTypeConfiguration<LogEntity>
{
    public void Configure(EntityTypeBuilder<LogEntity> builder)
    {
        builder.ToTable("Logs");

        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWID()")
            .IsRequired();

        builder.Property(e => e.RequestUri).IsRequired();

        builder.Property(e => e.Response).IsRequired();

        builder.Property(e => e.Date).IsRequired();
    }
}