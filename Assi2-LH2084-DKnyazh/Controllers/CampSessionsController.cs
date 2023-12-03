using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assi2_LH2084_DKnyazh.Data;
using COMP2084_Assignment2_DmitryKnyazhevskiy.Models;
using Microsoft.AspNetCore.Authorization;

namespace Assi2_LH2084_DKnyazh.Controllers
{
    [Authorize(Roles = "Administrator")]

    public class CampSessionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CampSessionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CampSessions
        public async Task<IActionResult> Index()
        {
              return _context.CampSessions != null ?
                          View("Index", await _context.CampSessions.OrderBy(c => c.campSessionId).ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.CampSessions'  is null.");
        }
        [AllowAnonymous]
        // GET: CampSessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CampSessions == null)
            {
                return NotFound();
            }

            var campSession = await _context.CampSessions
                .FirstOrDefaultAsync(m => m.campSessionId == id);
            if (campSession == null)
            {
                return NotFound();
            }

            return View(campSession);
        }

        // GET: CampSessions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CampSessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("campSessionId,StartDate,EndDate,maxCampers,numberCampers")] CampSession campSession)
        {
            if (ModelState.IsValid)
            {
                _context.Add(campSession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(campSession);
        }

        // GET: CampSessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CampSessions == null)
            {
                return NotFound();
            }

            var campSession = await _context.CampSessions.FindAsync(id);
            if (campSession == null)
            {
                return NotFound();
            }
            return View(campSession);
        }

        // POST: CampSessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("campSessionId,StartDate,EndDate,maxCampers,numberCampers")] CampSession campSession)
        {
            if (id != campSession.campSessionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campSession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampSessionExists(campSession.campSessionId))
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
            return View(campSession);
        }

        // GET: CampSessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CampSessions == null)
            {
                //return NotFound();
                return View("Error");
            }

            var campSession = await _context.CampSessions
                .FirstOrDefaultAsync(m => m.campSessionId == id);
            if (campSession == null)
            {
                //return NotFound();
                return View("Error");
            }
            return View("Delete",campSession);
        }

        // POST: CampSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CampSessions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CampSessions'  is null.");
            }
            var campSession = await _context.CampSessions.FindAsync(id);
            if (campSession != null)
            {
                _context.CampSessions.Remove(campSession);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction("Index",nameof(Index));
        }

        private bool CampSessionExists(int id)
        {
          return (_context.CampSessions?.Any(e => e.campSessionId == id)).GetValueOrDefault();
        }
    }
}
