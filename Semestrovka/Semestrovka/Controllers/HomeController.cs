using Microsoft.AspNetCore.Mvc;
using Semestrovka.Data;
using Semestrovka.Models;
using Semestrovka.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Semestrovka.Controllers
{
    public class HomeController : Controller
    {
        private static d6h4jeg5tcb9d8Context _context;

        public HomeController(d6h4jeg5tcb9d8Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            try
            {
                var novelties = _context.Product.ToList().TakeLast(7);
                ViewBag.Novelties = novelties;
                var orders = _context.Orders;
                var topSellersDic = new Dictionary<int, int>();
                foreach (var order in orders)
                {
                    foreach (var product in order.Productinorder)
                    {
                        if (!topSellersDic.ContainsKey(product.Id))
                        {
                            topSellersDic.Add(product.Id, 1);
                        }
                        else
                        {
                            topSellersDic[product.Id] = +1;
                        }
                    }
                }
                var topSellersId = topSellersDic.OrderByDescending(item => item.Value).Select(product => product.Key).Take(5);
                var topSellers = new List<Product>();
                foreach (var productId in topSellersId)
                {
                    topSellers.Add(_context.Product.Find(productId));
                }
                ViewBag.TopSellers = topSellers;
                var topNew = _context.Product.ToList().TakeLast(7).OrderByDescending(product => product.ProductRating).ToList();
                ViewBag.TopNew = topNew;
                var images = _context.Images.ToList();
                return View();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
