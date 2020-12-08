using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Expeditions.Models;

namespace Expeditions.Controllers
{
    public class TrekkingAgencyController : Controller
    {
        private readonly ExpeditionDbContext _context;

        public TrekkingAgencyController(ExpeditionDbContext context)
        {
            _context = context;
        }

        // GET: TrekkingAgency
        public async Task<IActionResult> Index()
        {
            return View(await _context.TrekkingAgencies.ToListAsync());
        }

        // GET: TrekkingAgency/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trekkingAgency = await _context.TrekkingAgencies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trekkingAgency == null)
            {
                return NotFound();
            }

            return View(trekkingAgency);
        }

        // GET: TrekkingAgency/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TrekkingAgency/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] TrekkingAgency trekkingAgency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trekkingAgency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trekkingAgency);
        }

        // GET: TrekkingAgency/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trekkingAgency = await _context.TrekkingAgencies.FindAsync(id);
            if (trekkingAgency == null)
            {
                return NotFound();
            }
            return View(trekkingAgency);
        }

        // POST: TrekkingAgency/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] TrekkingAgency trekkingAgency)
        {
            if (id != trekkingAgency.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trekkingAgency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrekkingAgencyExists(trekkingAgency.Id))
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
            return View(trekkingAgency);
        }

        // GET: TrekkingAgency/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trekkingAgency = await _context.TrekkingAgencies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trekkingAgency == null)
            {
                return NotFound();
            }

            return View(trekkingAgency);
        }

        // POST: TrekkingAgency/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trekkingAgency = await _context.TrekkingAgencies.FindAsync(id);
            _context.TrekkingAgencies.Remove(trekkingAgency);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrekkingAgencyExists(int id)
        {
            return _context.TrekkingAgencies.Any(e => e.Id == id);
        }
    }
}
