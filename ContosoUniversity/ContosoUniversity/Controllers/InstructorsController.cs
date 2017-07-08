using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Models.ViewModels;

namespace ContosoUniversity.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstructorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Instructors
        public async Task<IActionResult> Index(int? id, int? courseId)
        {

            var viewModel = new InstructorIndex();
            viewModel.Instructors = await _context.Instructors
                       .Include(i => i.OfficeAssignment)
                       .Include(i => i.CourseAssignments)
                       //.ThenInclude(i => i.Course)
                       //    .ThenInclude(i => i.Enrollments)
                       //    .ThenInclude(i => i.Student)
                       .Include(i => i.CourseAssignments)
                        .ThenInclude(i => i.Course)
                            .ThenInclude(i => i.Department)
                       //.AsNoTracking()
                       .OrderBy(i => i.LastName)
                       .ToListAsync();

            if (id != null)
            {
                ViewData["InstructorID"] = id.Value;
                Instructor instructor = viewModel.Instructors.Where
                    (i => i.ID == id.Value).Single();
                viewModel.Courses = instructor.CourseAssignments.Select(s => s.Course);
            }

            if (courseId != null)
            {
                ViewData["CourseID"] = courseId.Value;
                //viewModel.Enrollments = viewModel.Courses.Where  // based on the courseID being passed into the Index() method returns a list of IEnumerable<Enrollment>
                //      (x => x.CourseID == courseId).Single().Enrollments;  // return a single course with Enrollments

                var selectedCourse = viewModel
                    .Courses
                    .Where(x => x.CourseID == courseId)
                    .Single();
                await _context.Entry(selectedCourse).Collection(x => x.Enrollments).LoadAsync();
                foreach (Enrollment enrollment in selectedCourse.Enrollments)
                {
                    await _context.Entry(enrollment).Reference(s => s.Student).LoadAsync();
                }
                viewModel.Enrollments = selectedCourse.Enrollments;
            }

            return View(viewModel);
        }

        // GET: Instructors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructors
                .SingleOrDefaultAsync(m => m.ID == id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        // GET: Instructors/Create
        public IActionResult Create()
        {
            var instructor = new Instructor();
            instructor.CourseAssignments = new List<CourseAssignment>();
            PopulateAssignedCourseData(instructor);

            return View();
        }

        // POST: Instructors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,LastName,FirstMidName,HireDate,OfficeAssignment")] Instructor instructor, string[] selectedCourses)
        {

            if (ModelState.IsValid)
            {
                if (selectedCourses != null)
                {
                    instructor.CourseAssignments = new List<CourseAssignment>();
                    foreach (var course in selectedCourses)
                    {
                        var courseToAdd = new CourseAssignment {

                            InstructorID  = instructor.ID,
                            CourseID = int.Parse(course)

                        };
                        instructor.CourseAssignments.Add(courseToAdd);
                    }
                }

                _context.Add(instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            PopulateAssignedCourseData(instructor);
            return View(instructor);
        }

        // GET: Instructors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructors
                            .Include(i => i.OfficeAssignment)
                                    .Include(i => i.CourseAssignments)
                                    .ThenInclude(i => i.Course)
                                    .SingleOrDefaultAsync(m => m.ID == id);

            if (instructor == null)
            {
                return NotFound();
            }

            PopulateAssignedCourseData(instructor);
            return View(instructor);
        }

        // POST: Instructors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, string[] selectedCourses, [Bind("ID,LastName,FirstMidName,HireDate,OfficeAssignment")] Instructor instructor)
        {
            if (id != instructor.ID)
            {
                return NotFound();
            }

            var instructorToUpdate = _context.Instructors
                                            .Where(i => i.ID == instructor.ID)
                                        .Include(i => i.CourseAssignments)
                                            .ThenInclude(a => a.Course)
                                            .AsNoTracking()
                                        .Single();

            if (ModelState.IsValid)
            {
                instructor.CourseAssignments = _context.CourseAssignments
                                           .Where(ca => ca.InstructorID == instructor.ID)
                                           .Include(c => c.Course).ToList();
                UpdateInstructorCourses(selectedCourses, instructor);

                try
                {
                    if (_context.OfficeAssignments
                        .Where(ca => ca.InstructorID == instructor.ID)
                        .Count() > 0)
                    {


                        if (!String.IsNullOrEmpty(instructor.OfficeAssignment.Location))
                        {
                            instructor.OfficeAssignment.InstructorID = instructor.ID;
                        }
                        else
                        {
                            instructor.OfficeAssignment = null;
                        }
                    }
                    else
                    {

                        var newOffice = new OfficeAssignment()
                        {
                            InstructorID = instructor.ID, 
                            Location = instructor.OfficeAssignment.Location
                        };
                      
                        _context.Add(newOffice);

                    }
                                   
                    _context.Update(instructor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstructorExists(instructor.ID))
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

            UpdateInstructorCourses(selectedCourses, instructorToUpdate);
            PopulateAssignedCourseData(instructor);

            return View(instructor);
        }

        // GET: Instructors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructors
                .SingleOrDefaultAsync(m => m.ID == id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        // POST: Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instructor = await _context
                                        .Instructors
                                        .Include(i => i.OfficeAssignment)
                                        .Include(i => i.CourseAssignments)
                                        .SingleOrDefaultAsync(m => m.ID == id);

            var department = await _context.Departments
                                    .Where(d => d.InstructorID == id)
                                    .ToListAsync();
            department.ForEach(d => d.InstructorID = null);

            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool InstructorExists(int id)
        {
            return _context.Instructors.Any(e => e.ID == id);
        }

        private void PopulateAssignedCourseData(Instructor instructor)
        {
            var allCourses = _context.Courses;
            var instructorCourses = new HashSet<int>(instructor.CourseAssignments.Select(c => c.CourseID));
            var viewModel = new List<InstructorAssignedCourse>();
            foreach (var course in allCourses)
            {
                viewModel.Add(new InstructorAssignedCourse
                {
                    CourseID = course.CourseID,
                    Title = course.Title,
                    Assigned = instructorCourses.Contains(course.CourseID)
                });
            }
            ViewData["Courses"] = viewModel;
        }

        private void UpdateInstructorCourses(string[] selectedCourses, Instructor instructor)
        {
            if (selectedCourses == null)
            {
                instructor.CourseAssignments = new List<CourseAssignment>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var instructorCourses = new HashSet<int>(instructor.CourseAssignments.Select(c => c.CourseID));
              
            foreach (var course in _context.Courses)
            {
                if (selectedCoursesHS.Contains(course.CourseID.ToString()))
                {
                    if (!instructorCourses.Contains(course.CourseID))
                    {
                        var courseToAdd = new CourseAssignment
                        {
                            InstructorID = instructor.ID,
                            CourseID = course.CourseID
                        };

                        _context.Add(courseToAdd);
                        //instructor.CourseAssignments.Add(new CourseAssignment { InstructorID = instructor.ID, CourseID = course.CourseID });
                    }
                }
                else
                {
                    if (instructorCourses.Contains(course.CourseID))
                    {
                        CourseAssignment courseToRemove = instructor.CourseAssignments.SingleOrDefault(i => i.CourseID == course.CourseID);
                        _context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
