using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TwitterAPI_Scratch.Models;

namespace TwitterAPI_Scratch.Controllers
{
    public class TwitterAPIAuthsController : Controller
    {
        private readonly TwitterAPI_ScratchContext _context;

        public TwitterAPIAuthsController(TwitterAPI_ScratchContext context)
        {
            _context = context;    
        }

        // GET: TwitterAPIAuths
        public async Task<IActionResult> Index()
        {
            return View(await _context.TwitterAPIAuth.ToListAsync());
        }

        // GET: TwitterAPIAuths/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var twitterAPIAuth = await _context.TwitterAPIAuth
                .SingleOrDefaultAsync(m => m.ID == id);
            if (twitterAPIAuth == null)
            {
                return NotFound();
            }

            return View(twitterAPIAuth);
        }

        // GET: TwitterAPIAuths/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TwitterAPIAuths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ConsumerKey,ConsumerSecret,AccessToken,AccessTokenSecret,BaseURL,Owner,OwnerID")] TwitterAPIAuth twitterAPIAuth)
        {
            if (ModelState.IsValid)
            {
                _context.Add(twitterAPIAuth);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(twitterAPIAuth);
        }

        // GET: TwitterAPIAuths/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var twitterAPIAuth = await _context.TwitterAPIAuth.SingleOrDefaultAsync(m => m.ID == id);
            if (twitterAPIAuth == null)
            {
                return NotFound();
            }
            return View(twitterAPIAuth);
        }

        // POST: TwitterAPIAuths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ConsumerKey,ConsumerSecret,AccessToken,AccessTokenSecret,BaseURL,Owner,OwnerID")] TwitterAPIAuth twitterAPIAuth)
        {
            if (id != twitterAPIAuth.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(twitterAPIAuth);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TwitterAPIAuthExists(twitterAPIAuth.ID))
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
            return View(twitterAPIAuth);
        }

        // GET: TwitterAPIAuths/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var twitterAPIAuth = await _context.TwitterAPIAuth
                .SingleOrDefaultAsync(m => m.ID == id);
            if (twitterAPIAuth == null)
            {
                return NotFound();
            }

            return View(twitterAPIAuth);
        }

        // POST: TwitterAPIAuths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var twitterAPIAuth = await _context.TwitterAPIAuth.SingleOrDefaultAsync(m => m.ID == id);
            _context.TwitterAPIAuth.Remove(twitterAPIAuth);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool TwitterAPIAuthExists(int id)
        {
            return _context.TwitterAPIAuth.Any(e => e.ID == id);
        }
    }
}
