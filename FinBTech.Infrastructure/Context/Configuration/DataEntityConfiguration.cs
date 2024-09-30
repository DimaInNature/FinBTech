namespace FinBTech.Infrastructure.Context.Configuration;

public sealed class DataEntityConfiguration : IEntityTypeConfiguration<DataEntity>
{
    public void Configure(EntityTypeBuilder<DataEntity> builder)
    {
        builder.ToTable("Data");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Code).IsRequired();

        builder.Property(e => e.Value).IsRequired();
    }
}