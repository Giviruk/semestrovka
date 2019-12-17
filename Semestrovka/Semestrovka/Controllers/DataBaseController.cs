using System;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DataBaseController : Controller
    {
        // GET
        public static ItemContext Db;
        
        //если строка null, значит в форме name не указан
        public IActionResult SearchResults(string searchString)
        {
            var result = Db.Items.Where(item => item.Name.ToLower().Contains(searchString.ToLower()));

            return View(result.ToList());
        }
        
        public DataBaseController(ItemContext db)
        {
            Db = db;
        }
        public async Task<IActionResult> AdminPanel()
        {
            return View(await Db.Items.ToListAsync());//получаем объекты из бд
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Phone phone)
        {
            Db.Items.Add(phone); //sql выражение insert
            await Db.SaveChangesAsync(); //выполняет выражение
            return RedirectToAction("AdminPanel");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Phone phone = await Db.Items.FirstOrDefaultAsync(p => p.Id == id);
                if (phone != null)
                    return View(phone);
            }
            return NotFound();
        }
        //возвращает форму с сданными объекта, которые можно заредачить
        public async Task<IActionResult> Edit(int? id)
        {
            if(id!=null)
            {
                Phone phone = await Db.Items.FirstOrDefaultAsync(p=>p.Id==id);
                if (phone != null)
                    return View(phone);
            }
            return NotFound();
        }
        //Получает отредактированные данные в виде объекта 
        [HttpPost]
        public async Task<IActionResult> Edit(Phone phone)
        {
            Db.Items.Update(phone);//sql выражение insert
            await Db.SaveChangesAsync();//выполняет выражение
            return RedirectToAction("AdminPanel");
        }
        
        [HttpDelete]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Phone phone = new Phone
                    { Id = id.Value };
                Db.Entry(phone).State = EntityState.Deleted;
                await Db.SaveChangesAsync();
                return RedirectToAction("AdminPanel");
            }
            return NotFound();
        }
    }
}