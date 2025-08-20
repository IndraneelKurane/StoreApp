using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Models;
using StoreApp.HttpHandler;

namespace StoreApp.MVCUI.Controllers;

public class LocationRowController : Controller
{
    private readonly LocationRowHttpService _locationRowHttpService;

    public LocationRowController(LocationRowHttpService locationRowHttpService)
    {
        _locationRowHttpService = locationRowHttpService;
    }

    // GET: LocationRow
    public async Task<IActionResult> Index()
    {
        return View(await _locationRowHttpService.GetAllAsync("LocationRow"));
    }

    // GET: LocationRow/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var locationRow = await _locationRowHttpService.GetByIdAsync("LocationRow", id.Value);
        if (locationRow == null)
        {
            return NotFound();
        }

        return View(locationRow);
    }

    // GET: LocationRow/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: LocationRow/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(LocationRow locationRow)
    {
        if (ModelState.IsValid)
        {
            await _locationRowHttpService.CreateAsync("LocationRow", locationRow);
            return RedirectToAction(nameof(Index));
        }
        return View(locationRow);
    }

    // GET: LocationRow/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var locationRow = await _locationRowHttpService.GetByIdAsync("LocationRow", id.Value);
        if (locationRow == null)
        {
            return NotFound();
        }
        return View(locationRow);
    }

    // POST: LocationRow/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, LocationRow locationRow)
    {
        if (id != locationRow.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _locationRowHttpService.UpdateAsync("LocationRow",locationRow);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await LocationRowExists(locationRow.Id))
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
        return View(locationRow);
    }

    // GET: LocationRow/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var locationRow = await _locationRowHttpService.GetByIdAsync("LocationRow", id.Value);
        if (locationRow == null)
        {
            return NotFound();
        }

        return View(locationRow);
    }

    // POST: LocationRow/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id, LocationRow locationRow)
    {
        //var locationRow = await __locationRowHttpService.GetByIdAsync();
        //if (locationRow != null)
        //{
        //    __locationRowHttpService.LocationRow.Remove(locationRow);
        //}
        locationRow.MarkAsDeleted();
        await _locationRowHttpService.DeleteAsync("LocationRow", locationRow);

        return RedirectToAction(nameof(Index));
    }

    private async Task<bool> LocationRowExists(int id)
    {
        // return __locationRowHttpService.LocationRow.Any(e => e.Id == id);
        return ((await _locationRowHttpService.GetByIdAsync("LocationRow", id)) != null);
    }
}
