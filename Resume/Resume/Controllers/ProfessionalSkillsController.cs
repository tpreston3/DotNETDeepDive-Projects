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
    public class ProfessionalSkillsController : Controller
    {
        private readonly ResumeContext _context;

        public ProfessionalSkillsController(ResumeContext context)
        {
            _context = context;    
        }

        // GET: ProfessionalSkills
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProfessionalSkill.ToListAsync());
        }

        // GET: ProfessionalSkills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professionalSkill = await _context.ProfessionalSkill
                .SingleOrDefaultAsync(m => m.ID == id);
            if (professionalSkill == null)
            {
                return NotFound();
            }

            return View(professionalSkill);
        }

        // GET: ProfessionalSkills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProfessionalSkills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,SkillDescrption,Date,InstitutionName,State,City,ZipCode")] ProfessionalSkill professionalSkill)
        {
            if (ModelState.IsValid)
            {
                _context.Add(professionalSkill);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(professionalSkill);
        }

        // GET: ProfessionalSkills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professionalSkill = await _context.ProfessionalSkill.SingleOrDefaultAsync(m => m.ID == id);
            if (professionalSkill == null)
            {
                return NotFound();
            }
            return View(professionalSkill);
        }

        // POST: ProfessionalSkills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,SkillDescrption,Date,InstitutionName,State,City,ZipCode")] ProfessionalSkill professionalSkill)
        {
            if (id != professionalSkill.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(professionalSkill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessionalSkillExists(professionalSkill.ID))
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
            return View(professionalSkill);
        }

        // GET: ProfessionalSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var professionalSkill = await _context.ProfessionalSkill
                .SingleOrDefaultAsync(m => m.ID == id);
            if (professionalSkill == null)
            {
                return NotFound();
            }

            return View(professionalSkill);
        }

        // POST: ProfessionalSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var professionalSkill = await _context.ProfessionalSkill.SingleOrDefaultAsync(m => m.ID == id);
            _context.ProfessionalSkill.Remove(professionalSkill);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProfessionalSkillExists(int id)
        {
            return _context.ProfessionalSkill.Any(e => e.ID == id);
        }
    }
}
