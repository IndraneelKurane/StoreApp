using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;
using StoreApp.Persister;

namespace StoreApp.WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
[Produces("application/json")]


public class BillController : ControllerBase
{
    private readonly BillPersister _billPersister;

    public BillController(BillPersister billPersister)
    {
        _billPersister = billPersister;
    }

    [HttpGet(Name = "GetAllBills")]
    public async Task<IEnumerable<Bill>> GetAllBills()
    {
        var bills = await _billPersister.GetAllAsync();
        return bills;
    }

    [HttpGet("{id:int}", Name = "GetBillById")]
    public async Task<IActionResult> GetBillById(int id)
    {
        var bill = await _billPersister.GetByIdAsync(id);
        if (bill == null)
        {
            return NotFound();
        }
        return Ok(bill);
    }

    [HttpPost(Name = "CreateBill")]
    public async Task<IActionResult> CreateBill([FromBody] Bill bill)
    {
        if (bill == null)
        {
            return BadRequest("Bill cannot be null");
        }

        try
        {
            await _billPersister.Save(bill);
            return Ok(bill);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message} {ex.InnerException?.Message}");
        }
    }

    [HttpPut(Name = "UpdateBill")]
    public async Task<IActionResult> UpdateBill([FromBody] Bill bill)
    {
        if (bill == null || bill.Id <= 0)
        {
            return BadRequest("Invalid Bill data");
        }
        try
        {
            await _billPersister.Save(bill);
            return Ok(bill);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message} {ex.InnerException?.Message}");
        }
    }

    [HttpDelete(Name = "DeleteBill")]
    public async Task<IActionResult> DeleteBill([FromBody] Bill bill)
    {
        if (bill == null || bill.Id <= 0)
        {
            return BadRequest("Invalid Bill data");
        }

        try
        {
            bill.MarkAsDeleted();
            await _billPersister.Save(bill); // Use the public Save method instead of the protected DeleteAsync
            return Ok(bill);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message} {ex.InnerException?.Message}");
        }
    }
    }
  