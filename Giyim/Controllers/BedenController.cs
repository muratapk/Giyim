
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Giyim.Models;
using Giyim.Data;

public class BedenController : Controller
{
    private readonly AppDbContext _context;

    public BedenController(AppDbContext context)
    {
        _context = context;
    }

    // GET: BEDENS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Bedenler.ToListAsync());
    }

    // GET: BEDENS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var beden = await _context.Bedenler
            .FirstOrDefaultAsync(m => m.Id == id);
        if (beden == null)
        {
            return NotFound();
        }

        return View(beden);
    }

    // GET: BEDENS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: BEDENS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,BedenAdi,Varyantlar")] Beden beden)
    {
        if (ModelState.IsValid)
        {
            _context.Add(beden);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(beden);
    }

    // GET: BEDENS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var beden = await _context.Bedenler.FindAsync(id);
        if (beden == null)
        {
            return NotFound();
        }
        return View(beden);
    }

    // POST: BEDENS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,BedenAdi,Varyantlar")] Beden beden)
    {
        if (id != beden.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(beden);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BedenExists(beden.Id))
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
        return View(beden);
    }

    // GET: BEDENS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var beden = await _context.Bedenler
            .FirstOrDefaultAsync(m => m.Id == id);
        if (beden == null)
        {
            return NotFound();
        }

        return View(beden);
    }

    // POST: BEDENS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var beden = await _context.Bedenler.FindAsync(id);
        if (beden != null)
        {
            _context.Bedenler.Remove(beden);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BedenExists(int? id)
    {
        return _context.Bedenler.Any(e => e.Id == id);
    }
}
