using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimApp2.Data;
using TimApp2.Models;

namespace TimApp2.Controllers
{
    public class PartnersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PartnersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Partners
        /*        public async Task<IActionResult> Index()
                {
                    return View(await _context.Partners.ToListAsync());
                }*/


        public async Task<IActionResult> Index(string searchString)
        {
            if(_context.Partners == null)
            {
                return Problem("Entity set 'MVCPartnerContext.Partner' is null!");
            }

            var partners = from partner in _context.Partners
                           select partner;

            /*            if (!String.IsNullOrEmpty(searchString))
                        {
                            partners = partners.Where(p => p.Name.Contains(searchString));
                        }*/

            partners = partners.OrderByDescending(s => s.Location);


            return View(await partners.ToListAsync());
        }


      [HttpPost]
        public async Task<IActionResult> Index(string searchString, string sortBy)
        {
            if (_context.Partners == null)
            {
                return Problem("Entity set 'MVCPartnerContext.Partner' is null!");
            }

            var partners = from partner in _context.Partners
                           select partner;

            if (!String.IsNullOrEmpty(searchString))
            {
                partners = partners.Where(p => p.Name.Contains(searchString));
            }

            switch (sortBy)
            {
                case "Name":
                    partners = partners.OrderByDescending(s => s.Name);
                    break;
                case "Location":
                    partners = partners.OrderByDescending(s => s.Location);
                    break;
                case "Contact":
                    partners = partners.OrderByDescending(s => s.Contact);
                    break;
                case "Resource":
                    partners = partners.OrderByDescending(s => s.Resource);
                    break;
                case "Description":
                    partners = partners.OrderByDescending(s => s.Description);
                    break;
                default:
                    partners = partners.OrderByDescending(s => s.Name);
                    break;
            }
            return View(await partners.ToListAsync());
        }





        // GET: Partners/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partner == null)
            {
                return NotFound();
            }

            return View(partner);
        }

        // GET: Partners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Partners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Location,Contact,Resource,Description")] Partner partner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(partner);
        }

        // GET: Partners/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partners.FindAsync(id);
            if (partner == null)
            {
                return NotFound();
            }
            return View(partner);
        }

        // POST: Partners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Location,Contact,Resource,Description")] Partner partner)
        {
            if (id != partner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartnerExists(partner.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(partner);
        }

        // GET: Partners/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partner == null)
            {
                return NotFound();
            }

            return View(partner);
        }

        // POST: Partners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var partner = await _context.Partners.FindAsync(id);
            if (partner != null)
            {
                _context.Partners.Remove(partner);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnerExists(string id)
        {
            return _context.Partners.Any(e => e.Id == id);
        }
    }
}
