using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;
using StoreApp.Persister;
using StoreApp.Persister.Base;
using System.Threading.Tasks;

namespace StoreApp.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class UnitController : ControllerBase
{
    private readonly UnitPersister _unitPersister;

    public UnitController(UnitPersister unitPersister)
    {
        _unitPersister = unitPersister;
    }

    [HttpGet(Name = "GetAllUnits")]
    public async Task<IEnumerable<Unit>> GetAllUnits()
    {
        var units = await _unitPersister.GetAllAsync();
        return units;
    }

    [HttpGet("{id:int}", Name = "GetUnitById")]
    public async Task<IActionResult> GetUnitById(int id)
    {
        var unit = await _unitPersister.GetByIdAsync(id);
        if (unit == null)
        {
            return NotFound();
        }
        return Ok(unit);
    }


    [HttpPost(Name = "CreateUnit")]
    public async Task<IActionResult> CreateUnit([FromBody] Unit unit)
    {
        if (unit == null)
        {
            return BadRequest("Unit cannot be null or empty");
        }
        try
        {
            await _unitPersister.Save(unit);
            return Ok(unit);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message} {ex.InnerException?.Message}");
        }
    }

    [HttpPut(Name = "UpdateUnit")]
    public async Task<IActionResult> UpdateUnit([FromBody] Unit unit)
    {
        if (unit == null || unit.Id <= 0)
        {
            return BadRequest("Invalid unit data");
        }
        try
        {
            await _unitPersister.Save(unit);
            return Ok(unit);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message} {ex.InnerException?.Message}");
        }
    }

    [HttpDelete(Name = "DeleteUnit")]
    public async Task<IActionResult> DeleteUnit([FromBody] Unit unit)
    {
        if (unit == null || unit.Id <= 0)
        {
            return BadRequest("Invalid unit data");
        }
        try
        {
            unit.MarkAsDeleted();
            await _unitPersister.Save(unit);
            return Ok(unit);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message} {ex.InnerException?.Message}");
        }
    }
}
