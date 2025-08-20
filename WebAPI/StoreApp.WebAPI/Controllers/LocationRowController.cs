
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;
using StoreApp.Persister;
using StoreApp.Persister.Base;
using System.Threading.Tasks;

namespace StoreApp.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class LocationRowController : ControllerBase
{
    private readonly LocationRowPersister _locationRowPersister;

    public LocationRowController(LocationRowPersister locationRowPersister)
    {
        _locationRowPersister = locationRowPersister;
    }

    [HttpGet(Name = "GetAllLocationRows")]
    public async Task<IEnumerable<LocationRow>> GetAllLocationRows()
    {
        var locationRows = await _locationRowPersister.GetAllAsync();
        return locationRows;
    }

    [HttpGet("{id:int}", Name = "GetLocationRowById")]
    public async Task<IActionResult> GetLocationRowById(int id)
    {
        var locationRow = await _locationRowPersister.GetByIdAsync(id);
        if (locationRow == null)
        {
            return NotFound();
        }
        return Ok(locationRow);
    }


    [HttpPost( Name = "CreateLocationRow")]
    public async Task<IActionResult> CreateLocationRow([FromBody] LocationRow locationRow)
    {
        try
        {
            await _locationRowPersister.Save(locationRow);
            return Ok(locationRow);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message} {ex.InnerException?.Message}");
        }
    }

    [HttpPut(Name = "UpdateLocationRow")]
    public async Task<IActionResult> UpdateLocationRow([FromBody] LocationRow locationRow)
    {
        if (locationRow == null || locationRow.Id <= 0)
        {
            return BadRequest("Invalid location row data");
        }
        try
        {
            await _locationRowPersister.Save(locationRow);
            return Ok(locationRow);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message} {ex.InnerException?.Message}");
        }
    }

    [HttpDelete(Name = "DeleteLocationRow")]
    public async Task<IActionResult> DeleteLocationRow([FromBody] LocationRow locationRow)
    {
        if (locationRow == null || locationRow.Id <= 0)
        {
            return BadRequest("Invalid location row data");
        }
        try
        {
            locationRow.MarkAsDeleted();
            await _locationRowPersister.Save(locationRow);
            return Ok(locationRow);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message} {ex.InnerException?.Message}");
        }
    }
}
