using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using YelpAPI.Models;

namespace YelpAPI.Controllers
{
    public class SearchController : Controller
 
    {
        private readonly YelpAPIContext _context;
        public Models.ConfigurationKeys AppKeys { get; }

        public SearchController(IOptions<Models.ConfigurationKeys> appKeys, YelpAPIContext context)
        {
            AppKeys = appKeys.Value;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var API = new YelpAPI.YelpHelpers();
            var authenticated = await API.Authenticate(AppKeys, _context); 

            if (authenticated)
            {


            }

            return View();
        }
        /// <summary>
        // GET (give me the View())
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Search()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search([Bind("Term, Location")] YelpSearch search)
        {
            var API = new YelpAPI.YelpHelpers();
            var authenticated = await API.Authenticate(AppKeys, _context);

            if (authenticated)
            {
                YelpSearchResult searchResult = 
                    await API.GetResults(_context, search);
                return View("YelpResult", searchResult);
            }

            return View();
        }

        public IActionResult YelpResult(YelpSearchResult searchResult)
        {
            return View();
        }

    }
}