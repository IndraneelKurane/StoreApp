using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Models;
using StoreApp.HttpHandler;

namespace StoreApp.MVCUI.Controllers;

public class UnitController : Controller
{
    private readonly UnitHttpService _unitHttpService;

    public UnitController(UnitHttpService unitHttpService)
    {
        _unitHttpService = unitHttpService;
    }

    // GET: Unit
    public async Task<IActionResult> Index()
    {
        return View(await _unitHttpService.GetAllAsync("Unit"));
    }

    // GET: Unit/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var unit = await _unitHttpService.GetByIdAsync("Unit", id.Value);
        if (unit == null)
        {
            return NotFound();
        }

        return View(unit);
    }

    // GET: Unit/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Unit/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Unit unit)
    {
        if (ModelState.IsValid)
        {
            await _unitHttpService.CreateAsync("Unit", unit);
            return RedirectToAction(nameof(Index));
        }
        return View(unit);
    }

    // GET: Unit/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var unit = await _unitHttpService.GetByIdAsync("Unit", id.Value);
        if (unit == null)
        {
            return NotFound();
        }
        return View(unit);
    }

    // POST: Unit/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Unit unit)
    {
        if (id != unit.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _unitHttpService.UpdateAsync("Unit", unit);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await UnitExists(unit.Id))
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
        return View(unit);
    }

    // GET: Unit/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var unit = await _unitHttpService.GetByIdAsync("Unit", id.Value);
        if (unit == null)
        {
            return NotFound();
        }

        return View(unit);
    }

    // POST: Unit/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id, Unit unit)
    {
        //var unit = await _unitPersiter.GetByIdAsync(id);
        //if (unit != null)
        //{
        unit.MarkAsDeleted();
        await _unitHttpService.DeleteAsync("Unit", unit);
        //}

        return RedirectToAction(nameof(Index));
    }

    private async Task<bool> UnitExists(int id)
    {
        return ((await _unitHttpService.GetByIdAsync("Unit", id)) != null);
    }
}
