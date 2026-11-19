
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Giyim.Models;
using Giyim.Data;

public class UrunVaryantiController : Controller
{
    private readonly AppDbContext _context;

    public UrunVaryantiController(AppDbContext context)
    {
        _context = context;
    }

    // GET: URUNVARYANTIS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.UrunVaryantleri.ToListAsync());
    }

    // GET: URUNVARYANTIS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var urunvaryanti = await _context.UrunVaryantleri
            .FirstOrDefaultAsync(m => m.Id == id);
        if (urunvaryanti == null)
        {
            return NotFound();
        }

        return View(urunvaryanti);
    }

    // GET: URUNVARYANTIS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: URUNVARYANTIS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,StokKodu,StokMiktari,UrunId,Urun,BedenId,Beden,RenkId,Renk")] UrunVaryanti urunvaryanti)
    {
        if (ModelState.IsValid)
        {
            _context.Add(urunvaryanti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(urunvaryanti);
    }

    // GET: URUNVARYANTIS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var urunvaryanti = await _context.UrunVaryantleri.FindAsync(id);
        if (urunvaryanti == null)
        {
            return NotFound();
        }
        return View(urunvaryanti);
    }

    // POST: URUNVARYANTIS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,StokKodu,StokMiktari,UrunId,Urun,BedenId,Beden,RenkId,Renk")] UrunVaryanti urunvaryanti)
    {
        if (id != urunvaryanti.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(urunvaryanti);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UrunVaryantiExists(urunvaryanti.Id))
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
        return View(urunvaryanti);
    }

    // GET: URUNVARYANTIS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var urunvaryanti = await _context.UrunVaryantleri
            .FirstOrDefaultAsync(m => m.Id == id);
        if (urunvaryanti == null)
        {
            return NotFound();
        }

        return View(urunvaryanti);
    }

    // POST: URUNVARYANTIS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var urunvaryanti = await _context.UrunVaryantleri.FindAsync(id);
        if (urunvaryanti != null)
        {
            _context.UrunVaryantleri.Remove(urunvaryanti);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool UrunVaryantiExists(int? id)
    {
        return _context.UrunVaryantleri.Any(e => e.Id == id);
    }
}
