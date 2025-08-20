using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreApp.Dal.Context;
using StoreApp.Dal.Entities;
using StoreApp.Models;
using StoreApp.HttpHandler;

namespace StoreApp.MVCUI.Controllers;

public class DeliveryScheduleController : Controller
{
    private readonly DeliveryScheduleHttpService _deliveryScheduleHttpService;

    public DeliveryScheduleController(DeliveryScheduleHttpService billScheduleHttpService)
    {
        _deliveryScheduleHttpService = billScheduleHttpService;
    }

    // GET: BillSchedule
    public async Task<IActionResult> Index()
    {
        return View(await _deliveryScheduleHttpService.GetAllAsync("BillSchedule"));
    }

    // GET: BillSchedule/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var billSchedule = await _deliveryScheduleHttpService.GetByIdAsync("BillSchedule", id.Value);
        if (billSchedule == null)
        {
            return NotFound();
        }

        return View(billSchedule);
    }

    // GET: BillSchedule/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: BillSchedule/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(DeliverySchedule billSchedule)
    {
        if (ModelState.IsValid)
        {
            await _deliveryScheduleHttpService.CreateAsync("BillSchedule", billSchedule);
            return RedirectToAction(nameof(Index));
        }
        return View(billSchedule);
    }

    // GET: BillSchedule/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var billSchedule = await _deliveryScheduleHttpService.GetByIdAsync("BillSchedule",id.Value);
        if (billSchedule == null)
        {
            return NotFound();
        }
        return View(billSchedule);
    }

    // POST: BillSchedule/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, DeliverySchedule billSchedule)
    {
        if (id != billSchedule.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _deliveryScheduleHttpService.UpdateAsync("BillSchedule", billSchedule);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await BillScheduleExists(billSchedule.Id))
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
        return View(billSchedule);
    }

    // GET: BillSchedule/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var billSchedule = await _deliveryScheduleHttpService.GetByIdAsync("BillSchedule", id.Value);
        if (billSchedule == null)
        {
            return NotFound();
        }

        return View(billSchedule);
    }

    // POST: BillSchedule/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id, DeliverySchedule billSchedule)
    {
        billSchedule.MarkAsDeleted();
        await _deliveryScheduleHttpService.DeleteAsync("BillSchedule", billSchedule);
        return RedirectToAction(nameof(Index));
    }

    private async Task<bool> BillScheduleExists(int id)
    {
        return ((await _deliveryScheduleHttpService.GetByIdAsync("BillSchedule", id)) != null);
    }
}

