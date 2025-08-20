using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;
using StoreApp.Persister;

namespace StoreApp.WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
[Produces("application/json")]


public class BillItemController : ControllerBase
{
    private readonly BillItemPersister _billItemPersister;

    public BillItemController(BillItemPersister billItemPersister)
    {
        _billItemPersister = billItemPersister;
    }

    [HttpGet(Name = "GetAllBillItems")]
    public async Task<IEnumerable<BillItem>> GetAllBillItems()
    {
        var billItems = await _billItemPersister.GetAllAsync();
        return billItems;
    }

    [HttpGet("{id:int}", Name = "GetBillItemById")]
    public async Task<IActionResult> GetBillItemById(int id)
    {
        var billItem = await _billItemPersister.GetByIdAsync(id);
        if (billItem == null)
        {
            return NotFound();
        }
        return Ok(billItem);
    }

    [HttpPost(Name = "CreateBillItem")]
    public async Task<IActionResult> CreateBill([FromBody] BillItem billItem)
    {
        if (billItem == null)
        {
            return BadRequest("Bill Item cannot be null");
        }

        try
        {
            await _billItemPersister.Save(billItem);
            return Ok(billItem);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message} {ex.InnerException?.Message}");
        }
    }

    [HttpPut(Name = "UpdateBillItem")]
    public async Task<IActionResult> UpdateBill([FromBody] BillItem billItem)
    {
        if (billItem == null || billItem.Id <= 0)
        {
            return BadRequest("Invalid Bill Item data");
        }

        try
        {
            await _billItemPersister.Save(billItem);
            return Ok(billItem);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message} {ex.InnerException?.Message}");
        }
    }

    [HttpDelete(Name = "DeleteBillItem")]
    public async Task<IActionResult> DeleteBillItem([FromBody] BillItem billItem)
    {
        if (billItem == null || billItem.Id <= 0)
        {
            return BadRequest("Invalid Bill Item data");
        }

        try
        {
            billItem.MarkAsDeleted();
            await _billItemPersister.Save(billItem); // Use the public Save method instead of the protected DeleteAsync
            return Ok(billItem);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message} {ex.InnerException?.Message}");
        }
    }
}