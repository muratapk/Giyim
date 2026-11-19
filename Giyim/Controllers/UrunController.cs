
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Giyim.Models;
using Giyim.Data;

public class UrunController : Controller
{
    private readonly AppDbContext _context;

    public UrunController(AppDbContext context)
    {
        _context = context;
    }

    // GET: URUNS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Urunler.ToListAsync());
    }

    // GET: URUNS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var urun = await _context.Urunler
            .FirstOrDefaultAsync(m => m.Id == id);
        if (urun == null)
        {
            return NotFound();
        }

        return View(urun);
    }

    // GET: URUNS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: URUNS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,UrunAdi,Aciklama,Fiyat,IndirimliFiyat,AktifMi,EklenmeTarihi,KategoriId,Kategori,MarkaId,Marka,UrunResimleri,Varyantlar,Yorumlar")] Urun urun)
    {
        if (ModelState.IsValid)
        {
            _context.Add(urun);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(urun);
    }

    // GET: URUNS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var urun = await _context.Urunler.FindAsync(id);
        if (urun == null)
        {
            return NotFound();
        }
        return View(urun);
    }

    // POST: URUNS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,UrunAdi,Aciklama,Fiyat,IndirimliFiyat,AktifMi,EklenmeTarihi,KategoriId,Kategori,MarkaId,Marka,UrunResimleri,Varyantlar,Yorumlar")] Urun urun)
    {
        if (id != urun.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(urun);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UrunExists(urun.Id))
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
        return View(urun);
    }

    // GET: URUNS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var urun = await _context.Urunler
            .FirstOrDefaultAsync(m => m.Id == id);
        if (urun == null)
        {
            return NotFound();
        }

        return View(urun);
    }

    // POST: URUNS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var urun = await _context.Urunler.FindAsync(id);
        if (urun != null)
        {
            _context.Urunler.Remove(urun);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool UrunExists(int? id)
    {
        return _context.Urunler.Any(e => e.Id == id);
    }
}
