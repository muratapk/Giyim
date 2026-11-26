
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Giyim.Models;
using Giyim.Data;

public class UrunResmiController : Controller
{
    private readonly AppDbContext _context;

    public UrunResmiController(AppDbContext context)
    {
        _context = context;
    }

    // GET: URUNRESMIS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.UrunResmi.ToListAsync());
    }

    // GET: URUNRESMIS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var urunresmi = await _context.UrunResmi
            .FirstOrDefaultAsync(m => m.Id == id);
        if (urunresmi == null)
        {
            return NotFound();
        }

        return View(urunresmi);
    }

    // GET: URUNRESMIS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: URUNRESMIS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,ResimYolu,AnaResimMi,UrunId,Urun")] UrunResmi urunresmi,IFormFile PicturePath)
    {
        //dosya yok ise veya dosya boyutu 0 ise
        if (PicturePath != null && PicturePath.Length > 0)
        {
            //dosya boş değilse, dosyayı kaydetmek için gerekli işlemleri yap boyutu
            var fileName = Path.GetFileName(PicturePath.FileName);
            //dosya adını al
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", fileName);
            //dosya yolunu oluştur 
            //Directory.GetCurrentDirectory() ile projenin kök dizinini alıyoruz
            //ve "wwwroot/uploads" klasörüne dosya adını ekliyoruz.
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await PicturePath.CopyToAsync(stream);
            }
            //stream ile dosyayı oluştur ve PicturePath dosyasını stream'e kopyala
            //dosya yolunu veritabanına kaydet
            urunresmi.ResimYolu = "/uploads/" + fileName;
            //urunresmi nesnesinin ResimYolu özelliğine dosya yolunu kaydet
        }

        if (ModelState.IsValid)
        {
            _context.Add(urunresmi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(urunresmi);
    }

    // GET: URUNRESMIS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var urunresmi = await _context.UrunResmi.FindAsync(id);
        if (urunresmi == null)
        {
            return NotFound();
        }
        return View(urunresmi);
    }

    // POST: URUNRESMIS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,ResimYolu,AnaResimMi,UrunId,Urun")] UrunResmi urunresmi)
    {
        if (id != urunresmi.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(urunresmi);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UrunResmiExists(urunresmi.Id))
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
        return View(urunresmi);
    }

    // GET: URUNRESMIS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var urunresmi = await _context.UrunResmi
            .FirstOrDefaultAsync(m => m.Id == id);
        if (urunresmi == null)
        {
            return NotFound();
        }

        return View(urunresmi);
    }

    // POST: URUNRESMIS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var urunresmi = await _context.UrunResmi.FindAsync(id);
        if (urunresmi != null)
        {
            _context.UrunResmi.Remove(urunresmi);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool UrunResmiExists(int? id)
    {
        return _context.UrunResmi.Any(e => e.Id == id);
    }
}
