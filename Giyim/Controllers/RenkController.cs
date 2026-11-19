
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Giyim.Models;
using Giyim.Data;

public class RenkController : Controller
{
    private readonly AppDbContext _context;

    public RenkController(AppDbContext context)
    {
        _context = context;
    }

    // GET: RENKS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Renkler.ToListAsync());
    }

    // GET: RENKS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var renk = await _context.Renkler
            .FirstOrDefaultAsync(m => m.Id == id);
        if (renk == null)
        {
            return NotFound();
        }

        return View(renk);
    }

    // GET: RENKS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: RENKS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,RenkAdi,RenkKodu,Varyantlar")] Renk renk)
    {
        if (ModelState.IsValid)
        {
            _context.Add(renk);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(renk);
    }

    // GET: RENKS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var renk = await _context.Renkler.FindAsync(id);
        if (renk == null)
        {
            return NotFound();
        }
        return View(renk);
    }

    // POST: RENKS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,RenkAdi,RenkKodu,Varyantlar")] Renk renk)
    {
        if (id != renk.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(renk);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RenkExists(renk.Id))
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
        return View(renk);
    }

    // GET: RENKS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var renk = await _context.Renkler
            .FirstOrDefaultAsync(m => m.Id == id);
        if (renk == null)
        {
            return NotFound();
        }

        return View(renk);
    }

    // POST: RENKS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var renk = await _context.Renkler.FindAsync(id);
        if (renk != null)
        {
            _context.Renkler.Remove(renk);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool RenkExists(int? id)
    {
        return _context.Renkler.Any(e => e.Id == id);
    }
}
