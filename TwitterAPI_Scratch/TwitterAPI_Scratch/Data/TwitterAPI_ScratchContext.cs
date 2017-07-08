using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TwitterAPI_Scratch.Models
{
    public class TwitterAPI_ScratchContext : DbContext
    {
        public TwitterAPI_ScratchContext (DbContextOptions<TwitterAPI_ScratchContext> options)
            : base(options)
        {
        }

        public DbSet<TwitterAPI_Scratch.Models.TwitterAPIAuth> TwitterAPIAuth { get; set; }
    }
}
