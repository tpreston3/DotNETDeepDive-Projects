using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YelpAPI.Models;

namespace YelpAPI.Controllers
{
    public class YelpAuthTokensController : Controller
    {
        private readonly YelpAPIContext _context;

        public YelpAuthTokensController(YelpAPIContext context)
        {
            _context = context;    
        }

        // GET: YelpAuthTokens
        public async Task<IActionResult> Index()
        {
            return View(await _context.YelpAuthToken.ToListAsync());
        }

        // GET: YelpAuthTokens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yelpAuthToken = await _context.YelpAuthToken
                .SingleOrDefaultAsync(m => m.ID == id);
            if (yelpAuthToken == null)
            {
                return NotFound();
            }

            return View(yelpAuthToken);
        }

        // GET: YelpAuthTokens/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: YelpAuthTokens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,access_token,token_type,expire_date")] YelpAuthToken yelpAuthToken)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yelpAuthToken);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(yelpAuthToken);
        }

        // GET: YelpAuthTokens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yelpAuthToken = await _context.YelpAuthToken.SingleOrDefaultAsync(m => m.ID == id);
            if (yelpAuthToken == null)
            {
                return NotFound();
            }
            return View(yelpAuthToken);
        }

        // POST: YelpAuthTokens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,access_token,token_type,expire_date")] YelpAuthToken yelpAuthToken)
        {
            if (id != yelpAuthToken.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yelpAuthToken);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YelpAuthTokenExists(yelpAuthToken.ID))
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
            return View(yelpAuthToken);
        }

        // GET: YelpAuthTokens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yelpAuthToken = await _context.YelpAuthToken
                .SingleOrDefaultAsync(m => m.ID == id);
            if (yelpAuthToken == null)
            {
                return NotFound();
            }

            return View(yelpAuthToken);
        }

        // POST: YelpAuthTokens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yelpAuthToken = await _context.YelpAuthToken.SingleOrDefaultAsync(m => m.ID == id);
            _context.YelpAuthToken.Remove(yelpAuthToken);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool YelpAuthTokenExists(int id)
        {
            return _context.YelpAuthToken.Any(e => e.ID == id);
        }
    }
}
