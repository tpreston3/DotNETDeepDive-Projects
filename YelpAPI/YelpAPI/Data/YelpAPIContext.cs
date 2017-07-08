using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using YelpAPI.Models;

namespace YelpAPI.Models
{
    public class YelpAPIContext : DbContext
    {
        public YelpAPIContext (DbContextOptions<YelpAPIContext> options)
            : base(options)
        {
        }

        public DbSet<YelpAPI.Models.YelpAuthToken> YelpAuthToken { get; set; }

        public DbSet<YelpAPI.Models.YelpSearch> YelpSearch { get; set; }

        public DbSet<YelpAPI.Models.YelpSearchResult> YelpSearchResult { get; set; }
    }
}
