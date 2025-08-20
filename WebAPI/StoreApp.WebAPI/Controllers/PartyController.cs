using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;
using StoreApp.Persister;

namespace StoreApp.WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class PartyController : ControllerBase
{
    private readonly PartyPersister _partyPersister;

    public PartyController(PartyPersister partyPersister)
    {
        _partyPersister = partyPersister;
    }
    [HttpGet(Name = "GetAllPartys")]
    public async Task<IEnumerable<Party>> GetAllPartys()
    {
        var partys = await _partyPersister.GetAllAsync();
        return partys;
    }

    [HttpGet("{id:int}", Name = "GetPartyById")]
    public async Task<IActionResult> GetPartyById(int id)
    {
        var party = await _partyPersister.GetByIdAsync(id);
        if (party == null)
        {
            return NotFound();
        }
        return Ok(party);
    }


    [HttpPost("{name}", Name = "CreateParty")]
    public async Task<IActionResult> CreateParty(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return BadRequest("Name cannot be null or empty");
        }

        try
        {
            var party = new Party { Name = name };
            await _partyPersister.Save(party);
            return Ok(party);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message} {ex.InnerException?.Message}");
        }
    }

    [HttpPut(Name = "UpdateParty")]
    public async Task<IActionResult> UpdateParty([FromBody] Party party)
    {
        if (party == null || party.Id <= 0)
        {
            return BadRequest("Invalid Party data");
        }
        try
        {
            await _partyPersister.Save(party);
            return Ok(party);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message} {ex.InnerException?.Message}");
        }
    }

    [HttpDelete(Name = "DeleteParty")]
    public async Task<IActionResult> DeleteParty([FromBody] Party party)
    {
        if (party == null || party.Id <= 0)
        {
            return BadRequest("Invalid Party data");
        }
        try
        {
            party.MarkAsDeleted();
            await _partyPersister.Save(party);
            return Ok(party);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message} {ex.InnerException?.Message}");
        }
    }
}


