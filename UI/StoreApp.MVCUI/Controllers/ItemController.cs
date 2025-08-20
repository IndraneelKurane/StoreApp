
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Models;
using StoreApp.HttpHandler;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StoreApp.MVCUI.Controllers;

public class ItemController : Controller
{
    private readonly ItemHttpService _itemHttpService;
    private readonly UnitHttpService _unitHttpService;
    private readonly LocationHttpService _locationHttpService;

    public ItemController(ItemHttpService itemHttpService, UnitHttpService unitHttpService, LocationHttpService locationHttpService)
    {
        _itemHttpService = itemHttpService;
        _unitHttpService = unitHttpService;
        _locationHttpService = locationHttpService;
    }

    // GET: Item
    public async Task<IActionResult> Index()
    {
        //var LocationRowHttpServicet = _itemHttpService.Items.Include(i => i.Unit);
        var items = await _itemHttpService.GetAllAsync("Item");
        return View(items);
    }

    // GET: Item/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var item = await _itemHttpService.GetByIdAsync("Item",id.Value);
        if (item == null)
        {
            return NotFound();
        }

        return View(item);
    }

    // GET: Item/Create
    public async Task<IActionResult> Create()
    {
        ViewData["UnitId"] = new SelectList(await _unitHttpService.GetAllAsync("Unit"), "Id", "Name");
        ViewData["LocationId"] = new SelectList(await _locationHttpService.GetAllAsync("Location"), "Id", "Name");
        return View();
        // Add this using directive at the top of the file
    }

    // POST: Item/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Item item)
    {
        if (ModelState.IsValid)
        {
            await _itemHttpService.CreateAsync("Item", item);
            return RedirectToAction(nameof(Index));
        }
        ViewData["UnitId"] = new SelectList(await _unitHttpService.GetAllAsync("Unit"), "Id", "Name", item.UnitId);
        ViewData["LocationId"] = new SelectList(await _locationHttpService.GetAllAsync("Location"), "Id", "Name");
        return View(item);
    }

    // GET: Item/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var item = await _itemHttpService.GetByIdAsync("Item", id.Value);
        if (item == null)
        {
            return NotFound();
        }
        ViewData["UnitId"] = new SelectList(await _unitHttpService.GetAllAsync("Unit"), "Id", "Name", item.UnitId);
        ViewData["LocationId"] = new SelectList(await _locationHttpService.GetAllAsync("Location"), "Id", "Name", item.LocationId);
        return View(item);
    }

    // POST: Item/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Item item)
    {
        if (id != item.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _itemHttpService.UpdateAsync("Item", item);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ItemExists(item.Id))
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
        ViewData["UnitId"] = new SelectList(await _unitHttpService.GetAllAsync("Unit"), "Id", "Name", item.UnitId);
        ViewData["LocationId"] = new SelectList(await _locationHttpService.GetAllAsync("Location"), "Id", "Name", item.LocationId);
        return View(item);
    }

    // GET: Item/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var item = await _itemHttpService.GetByIdAsync("Item", id.Value);
        if (item == null)
        {
            return NotFound();
        }

        return View(item);
    }

    // POST: Item/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id, Item item)
    {
        //var item = await _itemHttpService.GetByIdAsync(id);
        //if (item != null)
        //{
        item.MarkAsDeleted();
        await _itemHttpService.DeleteAsync("Item",item);
        //}

        return RedirectToAction(nameof(Index));
    }

    private async Task<bool> ItemExists(int id)
    {
        return ((await _itemHttpService.GetByIdAsync("Item", id)) != null);
    }
}
