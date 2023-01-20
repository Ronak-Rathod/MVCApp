using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyMVCAPI.Models;

namespace MyMVCAPI.Controllers
{
    public class StuCousController : Controller
    {
        private readonly MyDbContext _context;

        public StuCousController(MyDbContext context)
        {
            _context = context;
        }

        // GET: StuCous
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.StuCous.Include(s => s.Course).Include(s => s.Student);
            return View(await myDbContext.ToListAsync());
        }

        // GET: StuCous/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StuCous == null)
            {
                return NotFound();
            }

            var stuCou = await _context.StuCous
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.SCId == id);
            if (stuCou == null)
            {
                return NotFound();
            }

            return View(stuCou);
        }

        // GET: StuCous/Create
        public IActionResult Create()
        {
            ViewData["CId"] = new SelectList(_context.Courses, "CId", "title");
            ViewData["SId"] = new SelectList(_context.Students, "SId", "email");
            return View();
        }

        // POST: StuCous/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SCId,SId,CId")] StuCou stuCou)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stuCou);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CId"] = new SelectList(_context.Courses, "CId", "CId", stuCou.CId);
            ViewData["SId"] = new SelectList(_context.Students, "SId", "SId", stuCou.SId);
            return View(stuCou);
        }

        // GET: StuCous/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StuCous == null)
            {
                return NotFound();
            }

            var stuCou = await _context.StuCous.FindAsync(id);
            if (stuCou == null)
            {
                return NotFound();
            }
            ViewData["CId"] = new SelectList(_context.Courses, "CId", "title", stuCou.CId);
            ViewData["SId"] = new SelectList(_context.Students, "SId", "email", stuCou.SId);
            return View(stuCou);
        }

        // POST: StuCous/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SCId,SId,CId")] StuCou stuCou)
        {
            if (id != stuCou.SCId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stuCou);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StuCouExists(stuCou.SCId))
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
            ViewData["CId"] = new SelectList(_context.Courses, "CId", "CId", stuCou.CId);
            ViewData["SId"] = new SelectList(_context.Students, "SId", "SId", stuCou.SId);
            return View(stuCou);
        }

        // GET: StuCous/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StuCous == null)
            {
                return NotFound();
            }

            var stuCou = await _context.StuCous
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.SCId == id);
            if (stuCou == null)
            {
                return NotFound();
            }

            return View(stuCou);
        }

        // POST: StuCous/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StuCous == null)
            {
                return Problem("Entity set 'MyDbContext.StuCous'  is null.");
            }
            var stuCou = await _context.StuCous.FindAsync(id);
            if (stuCou != null)
            {
                _context.StuCous.Remove(stuCou);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StuCouExists(int id)
        {
          return _context.StuCous.Any(e => e.SCId == id);
        }
    }
}
