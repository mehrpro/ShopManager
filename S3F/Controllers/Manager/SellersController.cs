using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SPS.Entities;
using SPS.Models.Context;
using SPS.ViewModels.Shop;

namespace SPS.Controllers.Manager
{
    public class SellersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SellersController(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Sellers
        public async Task<IActionResult> Index()
        {
           // var appDbContext = _context.Sellers.Include(s => s.AddressBook);
            return View(await _context.Sellers.ToListAsync());
        }

        // GET: Sellers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var seller = await _context.Sellers.Include(s => s.AddressBook).FirstOrDefaultAsync(m => m.SellerId == id);
            if (seller == null)
            {
                return NotFound();
            }

            var sellerView = _mapper.Map<SellerViewModel>(seller);

            return View(sellerView);
        }

        // GET: Sellers/Create
        public IActionResult Create()
        {
            ViewData["AddressBookId"] = new SelectList(_context.AddressBooks, "AddressBookId", "AddressBookId");
            return View();
        }

        // POST: Sellers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SellerId,SellerName,Company,Register,Enabled,AddressBookId")] Seller seller)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seller);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressBookId"] = new SelectList(_context.AddressBooks, "AddressBookId", "AddressBookId", seller.AddressBookId);
            return View(seller);
        }

        // GET: Sellers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seller = await _context.Sellers.FindAsync(id);
            if (seller == null)
            {
                return NotFound();
            }
            ViewData["AddressBookId"] = new SelectList(_context.AddressBooks, "AddressBookId", "AddressBookId", seller.AddressBookId);
            return View(seller);
        }

        // POST: Sellers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SellerId,SellerName,Company,Register,Enabled,AddressBookId")] Seller seller)
        {
            if (id != seller.SellerId)
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
                    if (!SellerExists(seller.SellerId))
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
            ViewData["AddressBookId"] = new SelectList(_context.AddressBooks, "AddressBookId", "AddressBookId", seller.AddressBookId);
            return View(seller);
        }

        // GET: Sellers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seller = await _context.Sellers
                .Include(s => s.AddressBook)
                .FirstOrDefaultAsync(m => m.SellerId == id);
            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }

        // POST: Sellers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seller = await _context.Sellers.FindAsync(id);
            _context.Sellers.Remove(seller);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellerExists(int id)
        {
            return _context.Sellers.Any(e => e.SellerId == id);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsNameInUse(string sellerName)
        {
            var find = await _context.Sellers.AnyAsync(x => x.SellerName == sellerName);
            if (find == false) return Json(true);
            return Json("این نام قبلا ثبت شده است");
        }
      

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsCompanyInUse(string companyName)
        {
            var find = await _context.Sellers.AnyAsync(x => x.Company == companyName);
            if (find == false) return Json(true);
            return Json("این شرکت یا فروشگاه قبلا ثبت شده است");
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsMobileInUse(string mobileNumber)
        {
            var find = await _context.AddressBooks.AnyAsync(x => x.MobileNumber1 == mobileNumber);
            if (find == false) return Json(true);
            return Json("تلفن همراه قبلا ثبت شده است");
        }
    }
}
