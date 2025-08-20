

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Models;
using StoreApp.HttpHandler;

namespace StoreApp.MVCUI.Controllers;

public class PartyController : Controller
{
    private readonly PartyHttpService _partyHttpService;

    public PartyController(PartyHttpService partyHttpService)
    {
        _partyHttpService = partyHttpService;
    }

    // GET: Party
    public async Task<IActionResult> Index()
    {
        //return View(await _partyHttpService.GetAllAsync("Party"));
        var partys = await _partyHttpService.GetAllAsync("Party");
        return View(partys);
    }

    // GET: Party/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var party = await _partyHttpService.GetByIdAsync("Party", id.Value);

        if (party == null)
        {
            return NotFound();
        }

        return View(party);
    }

    // GET: Party/Create
    public IActionResult Create()
    {
       return View();
    }

    // POST: Party/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Party party)
    {
        if (ModelState.IsValid)
        {
            await _partyHttpService.CreateAsync("Party", party);
            return RedirectToAction(nameof(Index));
        }
        return View(party);
    }

    // GET: Party/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var party = await _partyHttpService.GetByIdAsync("Party", id.Value);
        if (party == null)
        {
            return NotFound();
        }
        return View(party);
    }

    // POST: Party/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Party party)
    {
        if (id != party.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _partyHttpService.UpdateAsync("Party", party);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PartyExists(party.Id))
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
        return View(party);
    }

    // GET: Party/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var party = await _partyHttpService.GetByIdAsync("Party", id.Value);
        if (party == null)
        {
            return NotFound();
        }

        return View(party);
    }

    // POST: Party/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id, Party party)
    {

        party.MarkAsDeleted();
        await _partyHttpService.DeleteAsync("Party",party);
        return RedirectToAction(nameof(Index));
    }
    private async Task<bool> PartyExists(int id)
    {
        return ((await _partyHttpService.GetByIdAsync("Party", id)) != null);
    }
}
