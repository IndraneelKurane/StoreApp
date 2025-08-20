using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreApp.Models;
using StoreApp.HttpHandler;


namespace StoreApp.MVCUI.Controllers;

public class BillController : Controller
{
    private readonly BillHttpService _billHttpService;
    private readonly PartyHttpService _partyHttpService;
    private readonly ItemHttpService _itemHttpService;

    public BillController(BillHttpService billHttpService, PartyHttpService partyHttpService, ItemHttpService itemHttpService)
    {
        _billHttpService = billHttpService;
        _partyHttpService = partyHttpService;
        _itemHttpService = itemHttpService;
    }

    // GET: Bill
    public async Task<IActionResult> Index()
    {
        return View(await _billHttpService.GetAllAsync("Bill"));
    }

    // GET: Bill/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var bill = await _billHttpService.GetByIdAsync("Bill", id.Value);
        if (bill == null)
        {
            return NotFound();
        }

        // Get party name
        var parties = await _partyHttpService.GetAllAsync("Party");
        var party = parties.FirstOrDefault(p => p.Id == bill.PartyId);
        ViewBag.PartyName = party?.Name ?? "Unknown";

        // Get item names for bill items
        var items = await _itemHttpService.GetAllAsync("Item");
        var itemNames = new List<string>();
        if (bill.BillItems != null)
        {
            foreach (var billItem in bill.BillItems)
            {
                var item = items.FirstOrDefault(i => i.Id == billItem.ItemId);
                itemNames.Add(item?.Name ?? "Unknown");
            }
        }
        ViewBag.ItemNames = itemNames;

        return View(bill);
    }

    // GET: Bill/Create
    public async Task<IActionResult> Create()
    {
        ViewData["PartyId"] = new SelectList(await _partyHttpService.GetAllAsync("Party"), "Id", "Name");
        ViewData["ItemId"] = new SelectList(await _itemHttpService.GetAllAsync("Item"), "Id", "Name");
        return View();
        // Add this using directive at the top of the file
    }

    // POST: Bill/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Bill bill)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _billHttpService.CreateAsync("Bill", bill);
                return RedirectToAction(nameof(Index));
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError("", $"Create failed: {ex.Message} {ex.InnerException?.Message}");
            }
        }
        ViewData["PartyId"] = new SelectList(await _partyHttpService.GetAllAsync("Party"), "Id", "Name", bill.PartyId);
        ViewData["ItemId"] = new SelectList(await _itemHttpService.GetAllAsync("Item"), "Id", "Name");
        return View(bill);
    }

    // GET: Bill/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var bill = await _billHttpService.GetByIdAsync("Bill", id.Value);
        if (bill == null)
        {
            return NotFound();
        }
        ViewData["PartyId"] = new SelectList(await _partyHttpService.GetAllAsync("Party"), "Id", "Name", bill.PartyId);
        ViewData["ItemId"] = new SelectList(await _itemHttpService.GetAllAsync("Item"), "Id", "Name");
        return View(bill);
    }

    // POST: Bill/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Bill bill)
    {
        if (id != bill.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _billHttpService.UpdateAsync("Bill", bill);
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError("", $"Update failed: {ex.Message} {ex.InnerException?.Message}");
                ViewData["PartyId"] = new SelectList(await _partyHttpService.GetAllAsync("Party"), "Id", "Name", bill.PartyId);
                ViewData["ItemId"] = new SelectList(await _itemHttpService.GetAllAsync("Item"), "Id", "Name");
                return View(bill);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await BillExists(bill.Id))
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
        ViewData["PartyId"] = new SelectList(await _partyHttpService.GetAllAsync("Party"), "Id", "Name", bill.PartyId);
        ViewData["ItemId"] = new SelectList(await _itemHttpService.GetAllAsync("Item"), "Id", "Name");
        return View(bill);
    }

    // GET: Bill/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var bill = await _billHttpService.GetByIdAsync("Bill", id.Value);
        if (bill == null)
        {
            return NotFound();
        }

        // Get party name
        var parties = await _partyHttpService.GetAllAsync("Party");
        var party = parties.FirstOrDefault(p => p.Id == bill.PartyId);
        ViewBag.PartyName = party?.Name ?? "Unknown";

        // Get item names for bill items
        var items = await _itemHttpService.GetAllAsync("Item");
        var itemNames = new List<string>();
        if (bill.BillItems != null)
        {
            foreach (var billItem in bill.BillItems)
            {
                var item = items.FirstOrDefault(i => i.Id == billItem.ItemId);
                itemNames.Add(item?.Name ?? "Unknown");
            }
        }
        ViewBag.ItemNames = itemNames;

        return View(bill);
    }

    // POST: Bill/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id, Bill bill)
    {

        bill.MarkAsDeleted();
        await _billHttpService.DeleteAsync("Bill", bill);
        return RedirectToAction(nameof(Index));
    }

    private async Task<bool> BillExists(int id)
    {
        return ((await _billHttpService.GetByIdAsync("Bill", id)) != null);
    }
}

