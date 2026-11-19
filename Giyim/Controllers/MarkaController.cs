
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Giyim.Models;
using Giyim.Data;

public class MarkaController : Controller
{
    private readonly AppDbContext _context;

    public MarkaController(AppDbContext context)
    {
        _context = context;
    }

    // GET: MARKAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Markalar.ToListAsync());
    }

    // GET: MARKAS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var marka = await _context.Markalar
            .FirstOrDefaultAsync(m => m.Id == id);
        if (marka == null)
        {
            return NotFound();
        }

        return View(marka);
    }

    // GET: MARKAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: MARKAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,MarkaAdi,Urunler")] Marka marka)
    {
        if (ModelState.IsValid)
        {
            _context.Add(marka);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(marka);
    }

    // GET: MARKAS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var marka = await _context.Markalar.FindAsync(id);
        if (marka == null)
        {
            return NotFound();
        }
        return View(marka);
    }

    // POST: MARKAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,MarkaAdi,Urunler")] Marka marka)
    {
        if (id != marka.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(marka);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarkaExists(marka.Id))
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
        return View(marka);
    }

    // GET: MARKAS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var marka = await _context.Markalar
            .FirstOrDefaultAsync(m => m.Id == id);
        if (marka == null)
        {
            return NotFound();
        }

        return View(marka);
    }

    // POST: MARKAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var marka = await _context.Markalar.FindAsync(id);
        if (marka != null)
        {
            _context.Markalar.Remove(marka);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MarkaExists(int? id)
    {
        return _context.Markalar.Any(e => e.Id == id);
    }
}
