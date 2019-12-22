using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Semestrovka.Data;
using Semestrovka.Data.Logic;
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

        public IActionResult Login()
        {
            return PartialView();
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
            if (id == null) return NotFound();

            var users = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (users == null) return NotFound();

            return View(users);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View() ;
        }
        // GET: Users/Create
        [HttpPost]
        public IActionResult Create(Users user)
        {
            try
            {
                if (!HttpContext.Request.Cookies.ContainsKey("Token")) return BadRequest();

                var cookie = HttpContext.Request.Cookies["Token"];

                if (cookie == _context.Users.Find(user.Id).Token)
                {
                    user.Token = Hash.MakeHash(user.Login);
                    _context.Users.Add(user);
                    _context.SaveChanges();
                    return View();
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        // GET: Users/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Users user)
        {
            if (user == null) return NotFound();

            var users = await _context.Users.FindAsync(user.Id);
            if (users == null) return NotFound();
            _context.Users.Update(user);
            _context.SaveChanges();
            var a = HttpContext.Request.Cookies["Token"];
            return View(users);
        }
        [HttpGet]
        public IActionResult Auth()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Auth(string log, string pass)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(user => user.Login == log);

                if (user == null) return NotFound();

                if (user.Pass != pass) return BadRequest();

                HttpContext.Response.Cookies.Append("Token", user.Token);

                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var users = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (users == null) return NotFound();

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