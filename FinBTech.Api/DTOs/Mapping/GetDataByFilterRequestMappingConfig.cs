namespace FinBTech.Api.DTOs.Mapping;

public static class GetDataByFilterRequestMappingConfig
{
    public static void ConfigureMapping()
    {
        TypeAdapterConfig<GetDataByFilterRequest, DataFilter>
            .NewConfig()
            .ConstructUsing(s => new DataFilter(s.Id, s.Code, s.Value))
            .Map(d => d.Offset, s => s.Offset)
            .Map(d => d.Limit, s => s.Limit);
    }
}