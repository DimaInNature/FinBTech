namespace FinBTech.Api.Controllers;

[ApiController]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/data")]
[Produces("application/json")]
public sealed class DataController : ControllerBase
{
    private readonly IDataService _dataService;

    public DataController(IDataService dataService)
    {
        _dataService = dataService;
    }

    /// <summary>
    /// Get <see cref="DataEntry"/> by filter.
    /// </summary>
    /// <param name="request">Filter.</param>
    /// <returns>List of data.</returns>
    [HttpGet]
    [SwaggerResponse(StatusCodes.Status200OK, type: typeof(GetDataByFilterResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetDataByFilterResponse>> GetByFilter([FromQuery] GetDataByFilterRequest? request)
    {
        var filter = request.Adapt<DataFilter>();

        var data = await _dataService.GetAsync(filter);

        if(data is null)
        {
            return NotFound();
        }

        var response = new GetDataByFilterResponse()
        {
            Entries = data
        };

        return Ok(response);
    }

    /// <summary>
    /// Replace a list of data.
    /// </summary>
    /// <remarks>
    /// Before saving the data list, the existing data is deleted.
    /// </remarks>
    /// <param name="request">List of data.</param>
    /// <returns>Operation result.</returns>
    [SwaggerResponse(StatusCodes.Status201Created)]
    [SwaggerResponse(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<IActionResult> Replace([FromBody] SaveDataRequest request)
    {
        if (request.Entries?.Any() is false)
        {
            return BadRequest("Empty collection cannot be saved.");
        }

        await _dataService.ReplaceAsync(request.Entries!);

        return Ok();
    }
}