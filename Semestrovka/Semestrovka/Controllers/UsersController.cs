using System;
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
    public class UsersController : Controller
    {
        private readonly d6h4jeg5tcb9d8Context _context;

        public UsersController(d6h4jeg5tcb9d8Context context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // GET: Users/Create
        public IActionResult Create(Users user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return View();
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(Users user)
        {
            if (user == null)
            {
                return NotFound();
            }

            var users = await _context.Users.FindAsync(user.Id);
            if (users == null)
            {
                return NotFound();
            }
            _context.Users.Update(user);
            _context.SaveChanges();
            return View(users);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Remove(users);
            _context.SaveChanges();

            return View(users);
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
