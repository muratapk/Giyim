
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Giyim.Models;
using Giyim.Data;

public class SiparisController : Controller
{
    private readonly AppDbContext _context;

    public SiparisController(AppDbContext context)
    {
        _context = context;
    }

    // GET: SIPARISS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Siparisler.ToListAsync());
    }

    // GET: SIPARISS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var siparis = await _context.Siparisler
            .FirstOrDefaultAsync(m => m.Id == id);
        if (siparis == null)
        {
            return NotFound();
        }

        return View(siparis);
    }

    // GET: SIPARISS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: SIPARISS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,SiparisNo,SiparisTarihi,ToplamTutar,SiparisDurumu,KullaniciId,AdresId,Adres,TeslimatAdresi,SiparisDetaylari")] Siparis siparis)
    {
        if (ModelState.IsValid)
        {
            _context.Add(siparis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(siparis);
    }

    // GET: SIPARISS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var siparis = await _context.Siparisler.FindAsync(id);
        if (siparis == null)
        {
            return NotFound();
        }
        return View(siparis);
    }

    // POST: SIPARISS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,SiparisNo,SiparisTarihi,ToplamTutar,SiparisDurumu,KullaniciId,AdresId,Adres,TeslimatAdresi,SiparisDetaylari")] Siparis siparis)
    {
        if (id != siparis.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(siparis);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiparisExists(siparis.Id))
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
        return View(siparis);
    }

    // GET: SIPARISS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var siparis = await _context.Siparisler
            .FirstOrDefaultAsync(m => m.Id == id);
        if (siparis == null)
        {
            return NotFound();
        }

        return View(siparis);
    }

    // POST: SIPARISS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var siparis = await _context.Siparisler.FindAsync(id);
        if (siparis != null)
        {
            _context.Siparisler.Remove(siparis);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool SiparisExists(int? id)
    {
        return _context.Siparisler.Any(e => e.Id == id);
    }
}
