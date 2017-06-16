using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models; 

namespace ContosoUniversity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext  _context;

        public HomeController (ApplicationDbContext context)
        {
            _context = context;

        }
        
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            //ViewData["Message"] = "Your application description page.";

            IQueryable<EnrollmentDateGroup> data =
                    from student in _context.Students
                    group student by student.EnrollmentDate
                    into dateGroup select new EnrollmentDateGroup()
                    {
                        EnrollmentDate = dateGroup.Key, 
                        StudentCount = dateGroup.Count()
                        
                    };

            //IQueryable<Student> newData =
            //        from s in _context.Students
            //        group s by s.LastName
            //        into enrollment select new Student()
            //        {
            //            LastName = enrollment.Key,
            //            Enrollments = enrollment
            //        };

            return View(await data.AsNoTracking().ToListAsync());
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
