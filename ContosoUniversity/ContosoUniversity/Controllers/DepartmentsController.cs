using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ContosoUniversity.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IAuthorizationService _authorizationServces;
        private readonly IAuthorizationService _userManager; 

        public DepartmentsController(ApplicationDbContext context, IAuthorizationService authorizationServces, IAuthorizationService userManager)
        {
            _authorizationServces = authorizationServces;
            _userManager = userManager; 
            _context = context;    
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Departments.Include(d => d.Administrator);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string query = "SELECT * FROM Department WHERE DepartmentID = {0}";
            var department = await _context.Departments
                .FromSql(query, id)
                .Include(d => d.Administrator)
                .AsNoTracking()
                .SingleOrDefaultAsync(/*m => m.DepartmentID == id*/);

            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName");
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentID,Name,Budget,StartDate,InstructorID,RowVersion")] Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Add(department);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName", department.InstructorID);
            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .Include(i => i.Administrator)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.DepartmentID == id);

            
            if (department == null)
            {
                return NotFound();
            }

            var isAuthorized = await _authorizationServces.AuthorizeAsync(User, department, Authorization.DepartmentOperations.Update);

            if (!isAuthorized)
            {
                return new ChallengeResult();
            }

            ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName", department.InstructorID);           
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, 
                byte[] rowVersion)
               // [Bind("DepartmentID,Name,Budget,StartDate,InstructorID,RowVersion")] Department department)
        {
            if (id == null)
            {
                return NotFound();
            }
            var departmentToUpdate = await _context.Departments
                                            .Include(i => i.Administrator)
                                            .SingleOrDefaultAsync(d => d.DepartmentID == id);
            if (departmentToUpdate == null)
            {
                Department deletedDepartment = new Department();
                await TryUpdateModelAsync(deletedDepartment);
                ModelState.AddModelError(string.Empty, "Unable to save changes. The department was deleted by another user.");
                ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName", deletedDepartment.InstructorID);

               return View(deletedDepartment);
            }

            _context.Entry(departmentToUpdate).Property("RowVersion").OriginalValue = rowVersion;

            if (await TryUpdateModelAsync<Department>(departmentToUpdate, "",
                d => d.Name, d => d.StartDate, d => d.Budget, d => d.InstructorID));
            try
            {
                var isAuthorized = await _authorizationServces.AuthorizeAsync(User, departmentToUpdate, Authorization.DepartmentOperations.Update);

                if (!isAuthorized)
                {
                    return new ChallengeResult(); 
                }


                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var exceptedEntry = ex.Entries.Single();
                var clientValues = (Department)exceptedEntry.Entity;
                var databaseEntry = exceptedEntry.GetDatabaseValues(); 
                if (databaseEntry == null)
                {
                    ModelState.AddModelError(string.Empty, "Unable to save changes. The Department was deleted by another user");
                }
                else
                {
                    var databaseValues = (Department)databaseEntry.ToObject(); 

                    if (databaseValues.Name != clientValues.Name)
                    {
                        ModelState.AddModelError("Name", $"Current Value:{databaseValues.Name}");
                    }
                    if (databaseValues.Budget != clientValues.Budget)
                    {
                        ModelState.AddModelError("Budget", $"Current Value: {databaseValues.Budget}");
                    }
                    if (databaseValues.StartDate != clientValues.StartDate)
                    {
                        ModelState.AddModelError("StartDate", $"Current Value: {databaseValues.StartDate}");
                    }
                    if (databaseValues.InstructorID != clientValues.InstructorID)
                    {
                        Instructor databaseInstructor =
                                await _context.Instructors.SingleOrDefaultAsync(i => i.ID == databaseValues.InstructorID);
                        ModelState.AddModelError(".InstructorID", $"Current Value: {databaseInstructor?.FullName}");
                    }
                    ModelState.AddModelError(string.Empty, "So like the thing you wanted to Edit changed and you should try again");
                    departmentToUpdate.RowVersion = (byte[])databaseValues.RowVersion;
                    ModelState.Remove("RowVersion");
                   }
                }
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName", departmentToUpdate.InstructorID);

            return View(departmentToUpdate);
            }



        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? concurrencyError)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments
                .Include(d => d.Administrator)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.DepartmentID == id);

            if (department == null)
            {
                if (concurrencyError.GetValueOrDefault())
                {
                    return RedirectToAction("Index");
                }
                return NotFound();
            }

            if (concurrencyError.GetValueOrDefault())
            {
                ViewData["ConcurrencyErrorMessage"] = "The record you attempted to delete "
                    + "was modified by another user after you got the original values. "
                    + "The delete operation was canceled and the current values in the "
                    + "database have been displayed. If you still want to delete this "
                    + "record, click the Delete button again. Otherwise "
                    + "click the Back to List hyperlink.";
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Department department)
        {
            try
            {
                if (await _context.Departments.AnyAsync(m => m.DepartmentID == department.DepartmentID))
                {
                    _context.Departments.Remove(department);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("Delete", new { concurrencyError = true, id = department.DepartmentID });
            }
          
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(e => e.DepartmentID == id);
        }

    }
}
