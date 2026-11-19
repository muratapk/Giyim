
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Giyim.Models;
using Giyim.Data;

public class SiparisDetayController : Controller
{
    private readonly AppDbContext _context;

    public SiparisDetayController(AppDbContext context)
    {
        _context = context;
    }

    // GET: SIPARISDETAYS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.SiparisDetaylari.ToListAsync());
    }

    // GET: SIPARISDETAYS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var siparisdetay = await _context.SiparisDetaylari
            .FirstOrDefaultAsync(m => m.Id == id);
        if (siparisdetay == null)
        {
            return NotFound();
        }

        return View(siparisdetay);
    }

    // GET: SIPARISDETAYS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: SIPARISDETAYS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,SiparisId,Siparis,UrunVaryantiId,UrunVaryanti,Adet,BirimFiyat")] SiparisDetay siparisdetay)
    {
        if (ModelState.IsValid)
        {
            _context.Add(siparisdetay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(siparisdetay);
    }

    // GET: SIPARISDETAYS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var siparisdetay = await _context.SiparisDetaylari.FindAsync(id);
        if (siparisdetay == null)
        {
            return NotFound();
        }
        return View(siparisdetay);
    }

    // POST: SIPARISDETAYS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,SiparisId,Siparis,UrunVaryantiId,UrunVaryanti,Adet,BirimFiyat")] SiparisDetay siparisdetay)
    {
        if (id != siparisdetay.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(siparisdetay);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiparisDetayExists(siparisdetay.Id))
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
        return View(siparisdetay);
    }

    // GET: SIPARISDETAYS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var siparisdetay = await _context.SiparisDetaylari
            .FirstOrDefaultAsync(m => m.Id == id);
        if (siparisdetay == null)
        {
            return NotFound();
        }

        return View(siparisdetay);
    }

    // POST: SIPARISDETAYS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var siparisdetay = await _context.SiparisDetaylari.FindAsync(id);
        if (siparisdetay != null)
        {
            _context.SiparisDetaylari.Remove(siparisdetay);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool SiparisDetayExists(int? id)
    {
        return _context.SiparisDetaylari.Any(e => e.Id == id);
    }
}
