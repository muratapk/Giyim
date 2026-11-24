using Giyim.Data;
using Giyim.Models;
using Microsoft.AspNetCore.Mvc;

namespace Giyim.Controllers
{
    public class RenklerimController : Controller
    {
        private readonly AppDbContext _context;

        public RenklerimController(AppDbContext context)
        {
            _context = context;
        }

        //oluşturulacak database context nesnesi ile controller nesnesi oluşturuluyor
        public IActionResult Index()
        {
            var renkler = _context.Renkler.ToList();
            //veritabanındaki Renkler tablosundaki tüm verileri listeleyen bir action method.
            //Bu method, veritabanındaki Renkler tablosundaki tüm verileri alır ve Index view'ına gönderir.
            return View(renkler);
        }
        //Get :
        [HttpGet]
        public IActionResult Create() 
        { 
            return View(); 
        }
        [HttpPost]
        public IActionResult Create(Renk renk)
        {
            if (ModelState.IsValid)
            {
                _context.Renkler.Add(renk);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(renk);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var renk = _context.Renkler.Find(id);
            if (renk == null)
            {
                return NotFound();
            }
            return View(renk);
        }
        [HttpPost]
        public IActionResult Edit(int id, Renk renk)
        {
            if (id != renk.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(renk);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(renk);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var renk = _context.Renkler.Find(id);
            if (renk == null)
            {
                return NotFound();
            }
            _context.Renkler.Remove(renk);
            _context.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}
