using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Npgsql;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OtherController : Controller
    {
        public static ItemContext Db;
        
        public OtherController(ItemContext db)
        {
            Db = db;
            
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult Shop()
        {
            var allItems = Db.Items.ToList();
            return View(allItems);
        }
        public IActionResult SingleProduct()
        {
            return View();
        }
    }
}