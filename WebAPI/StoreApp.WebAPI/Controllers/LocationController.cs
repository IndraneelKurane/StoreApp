
using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;
using StoreApp.Persister;


namespace StoreApp.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class LocationController : ControllerBase
{
    private readonly LocationPersister _locationPersister;

    public LocationController(LocationPersister locationPersister)
    {
        _locationPersister = locationPersister;
    }

    [HttpGet(Name = "GetAllLocations")]
    public async Task<IEnumerable<Location>> GetAllLocations()
    {
        var locations = await _locationPersister.GetAllAsync();
        return locations;
    }

    [HttpGet("{id:int}", Name = "GetLocationById")]
    public async Task<IActionResult> GetLocationById(int id)
    {
        var location = await _locationPersister.GetByIdAsync(id);
        if (location == null)
        {
            return NotFound();
        }
        return Ok(location);
    }


    [HttpPost( Name = "CreateLocation")]
    public async Task<IActionResult> CreateLocation([FromBody] Location location)
    {
          
        try
        {
            await _locationPersister.Save(location);
            return Ok(location);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message} {ex.InnerException?.Message}");
        }
    }

    [HttpPut(Name = "UpdateLocation")]
    public async Task<IActionResult> UpdateLocation([FromBody] Location location)
    {
        if (location == null || location.Id <= 0)
        {
            return BadRequest("Invalid location data");
        }
        try
        {
            await _locationPersister.Save(location);
            return Ok(location);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message} {ex.InnerException?.Message}");
        }
    }

    [HttpDelete(Name = "DeleteLocation")]
    public async Task<IActionResult> DeleteLocation([FromBody] Location location)
    {
        if (location == null || location.Id <= 0)
        {
            return BadRequest("Invalid location data");
        }
        try
        {
            location.MarkAsDeleted();
            await _locationPersister.Save(location);
            return Ok(location);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message} {ex.InnerException?.Message}");
        }
    }
}
