using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BharatCrafted.Data;
using BharatCrafted.Models;
using Microsoft.AspNetCore.Authorization;

namespace BharatCrafted.Controllers
{
    public class SellersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SellersController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "MasterAdmin,Admin,Seller")]
        // GET: Sellers
        public async Task<IActionResult> Index()
        {
              return _context.sellers != null ? 
                          View(await _context.sellers.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.sellers'  is null.");
        }

        // GET: Sellers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.sellers == null)
            {
                return NotFound();
            }

            var seller = await _context.sellers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }
        [Authorize(Roles = "MasterAdmin,Admin")]
        // GET: Sellers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sellers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,PhoneNumber,Email")] Seller seller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seller);
        }
        [Authorize(Roles = "MasterAdmin,Admin,Seller")]
        // GET: Sellers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.sellers == null)
            {
                return NotFound();
            }

            var seller = await _context.sellers.FindAsync(id);
            if (seller == null)
            {
                return NotFound();
            }
            return View(seller);
        }

        // POST: Sellers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [Authorize(Roles = "MasterAdmin,Admin,Seller")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,PhoneNumber,Email")] Seller seller)
        {
            if (id != seller.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seller);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellerExists(seller.Id))
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
            return View(seller);
        }
        [Authorize(Roles = "MasterAdmin,Admin,Seller")]
        // GET: Sellers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.sellers == null)
            {
                return NotFound();
            }

            var seller = await _context.sellers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }
        [Authorize(Roles = "MasterAdmin,Admin,Seller")]
        // POST: Sellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.sellers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.sellers'  is null.");
            }
            var seller = await _context.sellers.FindAsync(id);
            if (seller != null)
            {
                _context.sellers.Remove(seller);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellerExists(int id)
        {
          return (_context.sellers?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        //Seller self code starts from here
        //only seller has access from beyond this point
        //warning
        //warning
        //warning
        //warning
        //warning
        //warning
        //warning
        //warning
        //warning
        //warning
        //warning
        //warning
        public async Task<IActionResult> SellerSelf()
        {
            return _context.sellers != null ?
                        View(await _context.sellers.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.sellers'  is null.");
        }
        public async Task<IActionResult> DetailSS(int? id)
        {
            if (id == null || _context.sellers == null)
            {
                return NotFound();
            }

            var seller = await _context.sellers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }
        //[Authorize(Roles = "Seller")]
        //// GET: Sellers/Delete/5
        //public async Task<IActionResult> DeleteSS(int? id)
        //{
        //    if (id == null || _context.sellers == null)
        //    {
        //        return NotFound();
        //    }

        //    var seller = await _context.sellers
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (seller == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(seller);
        //}
        //[Authorize(Roles = "Seller")]
        //// POST: Sellers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmedSS(int id)
        //{
        //    if (_context.sellers == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.sellers'  is null.");
        //    }
        //    var seller = await _context.sellers.FindAsync(id);
        //    if (seller != null)
        //    {
        //        _context.sellers.Remove(seller);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        [Authorize(Roles = "Seller")]
        // GET: Sellers/Edit/5
        public async Task<IActionResult> EditSS(int? id)
        {
            if (id == null || _context.sellers == null)
            {
                return NotFound();
            }

            var seller = await _context.sellers.FindAsync(id);
            if (seller == null)
            {
                return NotFound();
            }
            return View(seller);
        }
        [Authorize(Roles = "Seller")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSS(int id, [Bind("Id,FirstName,LastName,PhoneNumber,Email")] Seller seller)
        {
            if (id != seller.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seller);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellerExists(seller.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(SellerSelf));
            }
            return View(seller);
        }
    }
}
