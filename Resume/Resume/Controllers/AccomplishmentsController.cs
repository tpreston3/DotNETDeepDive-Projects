using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Resume.Models;

namespace Resume.Controllers
{
    public class AccomplishmentsController : Controller
    {
        private readonly ResumeContext _context;

        public AccomplishmentsController(ResumeContext context)
        {
            _context = context;    
        }

        // GET: Accomplishments
        public async Task<IActionResult> Index()
        {

            return View(await _context.Accomplishment.ToListAsync());
        }

        // GET: Accomplishments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accomplishment = await _context.Accomplishment
                .Include(j => j.Jobs)
              .SingleOrDefaultAsync(m => m.ID == id);

            if (accomplishment == null)
            {
                return NotFound();
            }

            return View(accomplishment);
        }

        // GET: Accomplishments/Create
        public IActionResult Create(int?  id, Job jobs)
        {
            var job = _context.Job
                .Where(j => j.ID == id)
                .Single();
            ViewData["Employer Name"] = job.EmployerName;

            return View();
        }

        // POST: Accomplishments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("Description")] Accomplishment Accomplishment)
        {
            var job = _context.Job
                .Where(j => j.ID == id)
                .Single();

            Accomplishment.Jobs = job;
            
            if (ModelState.IsValid)
            {
                _context.Add(Accomplishment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(Accomplishment);
        }

        // GET: Accomplishments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accomplishment = await _context.Accomplishment
                                .SingleOrDefaultAsync(m => m.ID == id);
            if (accomplishment == null)
            {
                return NotFound();
            }
            return View(accomplishment);
        }

        // POST: Accomplishments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,accomplishment")] Accomplishment Accomplishment)
        {
            if (id != Accomplishment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Accomplishment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccomplishmentExists(Accomplishment.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(Accomplishment);
        }

        // GET: Accomplishments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accomplishment = await _context.Accomplishment
                .SingleOrDefaultAsync(m => m.ID == id);
            if (accomplishment == null)
            {
                return NotFound();
            }

            return View(accomplishment);
        }

        // POST: Accomplishments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accomplishment = await _context.Accomplishment.SingleOrDefaultAsync(m => m.ID == id);
            _context.Accomplishment.Remove(accomplishment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AccomplishmentExists(int id)
        {
            return _context.Accomplishment.Any(e => e.ID == id);
        }
    }
}
