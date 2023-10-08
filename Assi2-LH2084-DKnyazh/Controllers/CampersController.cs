    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assi2_LH2084_DKnyazh.Data;
using COMP2084_Assignment2_DmitryKnyazhevskiy.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Assi2_LH2084_DKnyazh.Controllers
{
    public class CampersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CampersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Campers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Campers.Include(c => c.CampSession).Include(c => c.Status);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Campers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Campers == null)
            {
                return NotFound();
            }

            var camper = await _context.Campers
                .Include(c => c.CampSession)
                .Include(c => c.Status)
                .FirstOrDefaultAsync(m => m.camperId == id);
            if (camper == null)
            {
                return NotFound();
            }

            return View(camper);
        }

        // GET: Campers/Create
        public IActionResult Create()
        {
            ViewData["campSessionId"] = new SelectList(_context.CampSessions, "campSessionId", "StartDate");
            ViewData["statusId"] = new SelectList(_context.Status, "statusId", "statusName");
            return View();
        }

        // POST: Campers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("camperId,FirstName,LastName,age,campSessionId,statusId")] Camper camper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(camper);
                await _context.SaveChangesAsync();
                var result = _context.CampSessions.SingleOrDefault(a => a.campSessionId == camper.campSessionId);
                if (result != null)
                {
                    result.numberCampers = result.numberCampers + 1;
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["campSessionId"] = new SelectList(_context.CampSessions, "campSessionId", "campSessionId", camper.campSessionId);
            ViewData["statusId"] = new SelectList(_context.Status, "statusId", "statusName", camper.statusId);
            
            return View(camper);
        }

        // GET: Campers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Campers == null)
            {
                return NotFound();
            }

            var camper = await _context.Campers.FindAsync(id);
            if (camper == null)
            {
                return NotFound();
            }
            ViewData["campSessionId"] = new SelectList(_context.CampSessions, "campSessionId", "campSessionId", camper.campSessionId);
            ViewData["statusId"] = new SelectList(_context.Status, "statusId", "statusName", camper.statusId);
            return View(camper);
        }

        // POST: Campers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("camperId,FirstName,LastName,age,campSessionId,statusId")] Camper camper)
        {
            if (id != camper.camperId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(camper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CamperExists(camper.camperId))
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
            ViewData["campSessionId"] = new SelectList(_context.CampSessions, "campSessionId", "campSessionId", camper.campSessionId);
            ViewData["statusId"] = new SelectList(_context.Status, "statusId", "statusName", camper.statusId);
            return View(camper);
        }

        // GET: Campers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Campers == null)
            {
                return NotFound();
            }

            var camper = await _context.Campers
                .Include(c => c.CampSession)
                .Include(c => c.Status)
                .FirstOrDefaultAsync(m => m.camperId == id);
            if (camper == null)
            {
                return NotFound();
            }

            return View(camper);
        }

        // POST: Campers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Campers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Campers'  is null.");
            }
            var camper = await _context.Campers.FindAsync(id);
            if (camper != null)
            {
                _context.Campers.Remove(camper);
            }
            
            await _context.SaveChangesAsync();
            var result = _context.CampSessions.SingleOrDefault(a => a.campSessionId == camper.campSessionId);
            if (result != null)
            {
                result.numberCampers = result.numberCampers - 1;
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CamperExists(int id)
        {
          return (_context.Campers?.Any(e => e.camperId == id)).GetValueOrDefault();
        }
    }
}
