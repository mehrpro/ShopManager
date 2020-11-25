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

namespace SPS.Controllers
{
    public class UnitsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UnitsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Units
        public async Task<IActionResult> Index()
        {
           
            var unitIdListFromCommodityPrice = await _context.CommodityPrices.Select(x => x.UnitId).ToListAsync();//لیست تمام واحدهای استفاده شده در جدول قیمت گذاری
            var unitsList = await _context.Units.AsNoTracking().ToListAsync();
            var unitIdList = unitsList.Select(x => x.UnitId); 
            //var qry = unitIdListFromCommodityPrice.Where(row => !unitIdList.Contains(row)).ToList();
            var list = new List<UnitViewModel>();
            foreach (var unit in unitsList)
            {
                var item = _mapper.Map<UnitViewModel>(unit);
                item.IsDelete = unitIdListFromCommodityPrice.Any(row => unitIdList.Contains(row));
                list.Add(item);
            }
            return View(list);
        }



        // GET: Units/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Units/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UnitViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newUnit = _mapper.Map<Unit>(model);
                _context.Add(newUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Units/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _context.Units.FindAsync(id);
            if (unit == null)
            {
                return NotFound();
            }
            return View(unit);
        }

        // POST: Units/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Unit unit)
        {
            if (id != unit.UnitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnitExists(unit.UnitId))
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
            return View(unit);
        }

        // GET: Units/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unit = await _context.Units
                .FirstOrDefaultAsync(m => m.UnitId == id);
            if (unit == null)
            {
                return NotFound();
            }

            return View(unit);
        }

        // POST: Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unit = await _context.Units.FindAsync(id);
            _context.Units.Remove(unit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnitExists(int id)
        {
            return _context.Units.Any(e => e.UnitId == id);
        }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsNameInUse(string unitName)
        {
            var find = await _context.Units.AnyAsync(x => x.UnitName == unitName);
            if (find == false) return Json(true);
            return Json("این واحد قبلا ثبت شده است");
        }
    }
}
