#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeafletMapTest.Data;
using LeafletMapTest.Models;

namespace LeafletMapTest.Controllers
{
    public class MapItemsController : Controller
    {
        private readonly LeafletMapTestContext _context;

        public MapItemsController(LeafletMapTestContext context)
        {
            _context = context;
        }

        // GET: MapItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.MapItem.ToListAsync());
        }

        // GET: MapItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mapItem = await _context.MapItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mapItem == null)
            {
                return NotFound();
            }

            return View(mapItem);
        }

        // GET: MapItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MapItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Latitude,Longitude,Name,StreetName,StreetNumber,PostalCode,City,Country")] MapItem mapItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mapItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mapItem);
        }

        // GET: MapItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mapItem = await _context.MapItem.FindAsync(id);
            if (mapItem == null)
            {
                return NotFound();
            }
            return View(mapItem);
        }

        // POST: MapItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Latitude,Longitude,Name,StreetName,StreetNumber,PostalCode,City,Country")] MapItem mapItem)
        {
            if (id != mapItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mapItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MapItemExists(mapItem.Id))
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
            return View(mapItem);
        }

        // GET: MapItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mapItem = await _context.MapItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mapItem == null)
            {
                return NotFound();
            }

            return View(mapItem);
        }

        // POST: MapItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mapItem = await _context.MapItem.FindAsync(id);
            _context.MapItem.Remove(mapItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MapItemExists(int id)
        {
            return _context.MapItem.Any(e => e.Id == id);
        }
    }
}
