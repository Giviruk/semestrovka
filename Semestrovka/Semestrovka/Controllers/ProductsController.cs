﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Semestrovka.Data;
using Semestrovka.Models.DBModels;

namespace Semestrovka.Controllers
{
    public class ProductsController : Controller
    {
        private readonly d6h4jeg5tcb9d8Context _context;

        public ProductsController(d6h4jeg5tcb9d8Context context)
        {
            _context = context;
        }

        // GET: Products
        //public async Task<IActionResult> Index()
        //{
        //    var d6h4jeg5tcb9d8Context = _context.Product.Include(p => p.CategoryNavigation).Include(p => p.MainpictureurlNavigation);
        //    return View(await d6h4jeg5tcb9d8Context.ToListAsync());
        //}

        public async Task<IActionResult> Index(int id)
        {
            var d6h4jeg5tcb9d8Context = _context.Product.Where(x => x.Category == id).Include(p => p.CategoryNavigation).Include(p => p.MainpictureurlNavigation);
            return View(await d6h4jeg5tcb9d8Context.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.CategoryNavigation)
                .Include(p => p.MainpictureurlNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["Category"] = new SelectList(_context.Categories, "Id", "Id");
            ViewData["Mainpictureurl"] = new SelectList(_context.Images, "Id", "Id");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,Category,Producer,Mainpictureurl,Characteristics,ProductRating")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Category"] = new SelectList(_context.Categories, "Id", "Id", product.Category);
            ViewData["Mainpictureurl"] = new SelectList(_context.Images, "Id", "Id", product.Mainpictureurl);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["Category"] = new SelectList(_context.Categories, "Id", "Id", product.Category);
            ViewData["Mainpictureurl"] = new SelectList(_context.Images, "Id", "Id", product.Mainpictureurl);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Category,Producer,Mainpictureurl,Characteristics,ProductRating")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["Category"] = new SelectList(_context.Categories, "Id", "Id", product.Category);
            ViewData["Mainpictureurl"] = new SelectList(_context.Images, "Id", "Id", product.Mainpictureurl);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.CategoryNavigation)
                .Include(p => p.MainpictureurlNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}