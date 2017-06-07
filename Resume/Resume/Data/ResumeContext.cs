

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resume.Controllers;
using Resume.Models;

namespace Resume.Models
    {
        public class ResumeContext : DbContext
        {
            public ResumeContext(DbContextOptions<ResumeContext> options)
                : base(options)
            {
            }

            public DbSet<Resume.Models.Contact> Contact { get; set; }

            public DbSet<Resume.Models.Job> Job { get; set; }

            public DbSet<Resume.Models.Accomplishment> Accomplishment { get; set; }

            public DbSet<Resume.Models.Education> Education { get; set; }

            public DbSet<Resume.Models.Reference> Reference { get; set; }

            public DbSet<Resume.Models.ProfessionalSkill> ProfessionalSkill { get; set; }
        }
    }



