namespace FinBTech.Api.Controllers;

public sealed class DataController : ControllerBase
{
    private readonly IDataService _dataService;

    public DataController(IDataService dataService)
    {
        _dataService = dataService;
    }

    [HttpPost("save")]
    public async Task<IActionResult> SaveData([FromBody] IEnumerable<DataEntry> data)
    {
        await _dataService.SaveDataAsync(data);

        return Ok();
    }

    [HttpGet("get")]
    public async Task<ActionResult<IEnumerable<DataEntry>>> GetDataByCode([FromQuery] int? codeFilter)
    {
        var data = await _dataService.GetAsync(codeFilter);

        return Ok(data);
    }
}