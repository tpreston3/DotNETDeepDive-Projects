﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using System.Data.Common;

namespace ContosoUniversity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {
            List<EnrollmentDateGroup> groups = new List<EnrollmentDateGroup>();


            try
            {
                using (var conn = _context.Database.GetDbConnection())
                {
                    await conn.OpenAsync();
                    using (var command = conn.CreateCommand())
                    {
                        string query = "SELECT EnrollmentDate, COUNT(*) AS StudentCount"
                            + "FROM Person"
                            + "WHERE Discriminator ='Student' "
                            + "GROUP BY EnrollmentDate";
                        command.CommandText = query;
                        using (DbDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                            {
                                while (await reader.ReadAsync())
                                {
                                    var row = new EnrollmentDateGroup
                                    {
                                        EnrollmentDate = reader.GetDateTime(0),
                                        StudentCount = reader.GetInt32(1)
                                    };
                                    groups.Add(row);
                                }
                            }
                        }
                       
                    }
                }
            }
            finally
            {

            }
       
    return View(groups);
}


    #region
    //    IQueryable<EnrollmentDateGroup> data =
    //            from student in _context.Students
    //            group student by student.EnrollmentDate
    //            into dateGroup select new EnrollmentDateGroup()
    //            {
    //                EnrollmentDate = dateGroup.Key, 
    //                StudentCount = dateGroup.Count()

    //            };
    #endregion





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
