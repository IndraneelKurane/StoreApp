using Microsoft.AspNetCore.Mvc;
using StoreApp.Models;
using StoreApp.Persister;

namespace StoreApp.WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
[Produces("application/json")]


public class DeliveryScheduleController : ControllerBase
{
    private readonly DeliverySchedulePersister _deliverySchedulePersister;

    public DeliveryScheduleController(DeliverySchedulePersister deliverySchedulePersister)
    {
        _deliverySchedulePersister = deliverySchedulePersister;
    }

    [HttpGet(Name = "GetAllDeliverySchedules")]
    public async Task<IEnumerable<DeliverySchedule>> GetAllDeliverySchedules()
    {
        var deliverySchedules = await _deliverySchedulePersister.GetAllAsync();
        return deliverySchedules;
    }

    [HttpGet("{id:int}", Name = "GetDeliveryScheduleById")]
    public async Task<IActionResult> GetDeliveryScheduleById(int id)
    {
        var deliverySchedule = await _deliverySchedulePersister.GetByIdAsync(id);
        if (deliverySchedule == null)
        {
            return NotFound();
        }
        return Ok(deliverySchedule);
    }

    [HttpPost(Name = "CreateDeliverySchedule")]
    public async Task<IActionResult> CreateDeliverySchedule([FromBody] DeliverySchedule deliverySchedule)
    {
        if (deliverySchedule == null)
        {
            return BadRequest("Bill Schedule cannot be null");
        }

        try
        {
            await _deliverySchedulePersister.Save(deliverySchedule);
            return Ok(deliverySchedule);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message} {ex.InnerException?.Message}");
        }
    }

    [HttpPut(Name = "UpdateDeliverySchedule")]
    public async Task<IActionResult> UpdateDeliverySchedule([FromBody] DeliverySchedule deliverySchedule)
    {
        if (deliverySchedule == null || deliverySchedule.Id <= 0)
        {
            return BadRequest("Invalid Bill Schedule data");
        }

        try
        {
            await _deliverySchedulePersister.Save(deliverySchedule);
            return Ok(deliverySchedule);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message} {ex.InnerException?.Message}");
        }
    }

    [HttpDelete(Name = "DeleteDeliverySchedule")]
    public async Task<IActionResult> DeleteBill([FromBody] DeliverySchedule deliverySchedule)
    {
        if (deliverySchedule == null || deliverySchedule.Id <= 0)
        {
            return BadRequest("Invalid Bill Schedule data");
        }

        try
        {
            deliverySchedule.MarkAsDeleted();
            await _deliverySchedulePersister.Save(deliverySchedule); // Use the public Save method instead of the protected DeleteAsync
            return Ok(deliverySchedule);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message} {ex.InnerException?.Message}");
        }
    }
    }
  