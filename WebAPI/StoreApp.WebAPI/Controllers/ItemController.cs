using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;
using StoreApp.Persister;
using StoreApp.Persister.Base;
using System.Threading.Tasks;

namespace StoreApp.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class ItemController : ControllerBase
{
    private readonly ItemPersister _itemPersister;

    public ItemController(ItemPersister itemPersister)
    {
        _itemPersister = itemPersister;
    }

    [HttpGet(Name = "GetAllItems")]
    public async Task<IEnumerable<Item>> GetAllItems()
    {
        var items = await _itemPersister.GetAllAsync();
        return items;
    }

    [HttpGet("{id:int}", Name = "GetItemById")]
    public async Task<IActionResult> GetItemById(int id)
    {
        var item = await _itemPersister.GetByIdAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }


    [HttpPost(Name = "CreateItem")]
    public async Task<IActionResult> CreateItem([FromBody] Item item)
    {
        if (item == null)
        {
            return BadRequest("Unit cannot be null or empty");
        }
        try
        {
            await _itemPersister.Save(item);
            return Ok(item);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message} {ex.InnerException?.Message}");
        }
    }

    [HttpPut(Name = "UpdateItem")]
    public async Task<IActionResult> UpdateItem([FromBody] Item item)
    {
        if (item == null || item.Id <= 0)
        {
            return BadRequest("Invalid item data");
        }
        try
        {
            await _itemPersister.Save(item);
            return Ok(item);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message} {ex.InnerException?.Message}");
        }
    }

    [HttpDelete(Name = "DeleteItem")]
    public async Task<IActionResult> DeleteItem([FromBody] Item item)
    {
        if (item == null || item.Id <= 0)
        {
            return BadRequest("Invalid item data");
        }
        try
        {
            item.MarkAsDeleted();
            await _itemPersister.Save(item);
            return Ok(item);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message} {ex.InnerException?.Message}");
        }
    }
}
