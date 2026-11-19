
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Giyim.Models;
using Giyim.Data;

public class SepetUrunController : Controller
{
    private readonly AppDbContext _context;

    public SepetUrunController(AppDbContext context)
    {
        _context = context;
    }

    // GET: SEPETURUNS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.SepetUrunler.ToListAsync());
    }

    // GET: SEPETURUNS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var sepeturun = await _context.SepetUrunler
            .FirstOrDefaultAsync(m => m.Id == id);
        if (sepeturun == null)
        {
            return NotFound();
        }

        return View(sepeturun);
    }

    // GET: SEPETURUNS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: SEPETURUNS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,SepetId,Sepet,UrunVaryantiId,UrunVaryanti,Adet")] SepetUrun sepeturun)
    {
        if (ModelState.IsValid)
        {
            _context.Add(sepeturun);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(sepeturun);
    }

    // GET: SEPETURUNS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var sepeturun = await _context.SepetUrunler.FindAsync(id);
        if (sepeturun == null)
        {
            return NotFound();
        }
        return View(sepeturun);
    }

    // POST: SEPETURUNS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,SepetId,Sepet,UrunVaryantiId,UrunVaryanti,Adet")] SepetUrun sepeturun)
    {
        if (id != sepeturun.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(sepeturun);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SepetUrunExists(sepeturun.Id))
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
        return View(sepeturun);
    }

    // GET: SEPETURUNS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var sepeturun = await _context.SepetUrunler
            .FirstOrDefaultAsync(m => m.Id == id);
        if (sepeturun == null)
        {
            return NotFound();
        }

        return View(sepeturun);
    }

    // POST: SEPETURUNS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var sepeturun = await _context.SepetUrunler.FindAsync(id);
        if (sepeturun != null)
        {
            _context.SepetUrunler.Remove(sepeturun);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool SepetUrunExists(int? id)
    {
        return _context.SepetUrunler.Any(e => e.Id == id);
    }
}
