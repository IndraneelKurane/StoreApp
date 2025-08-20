using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Models;
using StoreApp.HttpHandler;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StoreApp.MVCUI.Controllers;

public class LocationController : Controller
{
    private readonly LocationHttpService _locationHttpService;
    private readonly LocationRowHttpService _locationRowHttpService;

    public LocationController(LocationHttpService locationHttpService, LocationRowHttpService locationRowHttpService)
    {
        _locationHttpService = locationHttpService;
        _locationRowHttpService = locationRowHttpService;
    }

    // GET: Location
    public async Task<IActionResult> Index()
    {
        var locations = await _locationHttpService.GetAllAsync("Location"); 
        return View(locations);
    }

    // GET: Location/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var location = await _locationHttpService.GetByIdAsync("Location", id.Value);
        if (location == null)
        {
            return NotFound();
        }

        return View(location);
    }

    // GET: Location/Create
    public async Task<IActionResult> Create()
    {
        ViewData["LocationRowNo"] = new SelectList(await _locationRowHttpService.GetAllAsync("LocationRow"), "Id", "Name");
        return View();
        // Add this using directive at the top of the file
    }

    // POST: Location/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Location location)
    {
        if (ModelState.IsValid)
        {
            await _locationHttpService.CreateAsync("Location", location);
            return RedirectToAction(nameof(Index));
        }
        ViewData["LocationRowNo"] = new SelectList(await _locationRowHttpService.GetAllAsync("LocationRow"), "Id", "Name", location.LocationRowId);
        return View(location);
    }

    // GET: Location/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var location = await _locationHttpService.GetByIdAsync("Location", id.Value);
        if (location == null)
        {
            return NotFound();
        }
        ViewData["LocationRowNo"] = new SelectList(await _locationRowHttpService.GetAllAsync("LocationRow"), "Id", "Name", location.LocationRowId);
        //return View(Location);
        return RedirectToAction(nameof(Index));
    }

    // POST: Location/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Location location)
    {
        if (id != location.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _locationHttpService.UpdateAsync("Location", location);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await LocationExists(location.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["LocationRowNo"] = new SelectList(await _locationRowHttpService.GetAllAsync("LocationRow"), "Id", "Name", location.LocationRowId);
        return View(location);
    }

    // GET: Location/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var location = await _locationHttpService.GetByIdAsync("Location", id.Value);
        if (location == null)
        {
            return NotFound();
        }

        return View(location);
    }

    // POST: Location/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id, Location location)
    {
        //var Location = await _locationHttpService.GetByIdAsync(id);
        //if (Location != null)
        //{
        location.MarkAsDeleted();
        await _locationHttpService.DeleteAsync("Location", location);
        //}

        return RedirectToAction(nameof(Index));
    }

    private async Task<bool> LocationExists(int id)
    {
        return ((await _locationHttpService.GetByIdAsync("Location", id)) != null);
    }
}
