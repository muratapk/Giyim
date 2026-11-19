
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Giyim.Models;
using Giyim.Data;

public class SepetController : Controller
{
    private readonly AppDbContext _context;

    public SepetController(AppDbContext context)
    {
        _context = context;
    }

    // GET: SEPETS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Sepets.ToListAsync());
    }

    // GET: SEPETS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var sepet = await _context.Sepets
            .FirstOrDefaultAsync(m => m.Id == id);
        if (sepet == null)
        {
            return NotFound();
        }

        return View(sepet);
    }

    // GET: SEPETS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: SEPETS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,KullaniciId,OlusturmaTarihi,SepetUrunleri")] Sepet sepet)
    {
        if (ModelState.IsValid)
        {
            _context.Add(sepet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(sepet);
    }

    // GET: SEPETS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var sepet = await _context.Sepets.FindAsync(id);
        if (sepet == null)
        {
            return NotFound();
        }
        return View(sepet);
    }

    // POST: SEPETS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,KullaniciId,OlusturmaTarihi,SepetUrunleri")] Sepet sepet)
    {
        if (id != sepet.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(sepet);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SepetExists(sepet.Id))
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
        return View(sepet);
    }

    // GET: SEPETS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var sepet = await _context.Sepets
            .FirstOrDefaultAsync(m => m.Id == id);
        if (sepet == null)
        {
            return NotFound();
        }

        return View(sepet);
    }

    // POST: SEPETS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var sepet = await _context.Sepets.FindAsync(id);
        if (sepet != null)
        {
            _context.Sepets.Remove(sepet);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool SepetExists(int? id)
    {
        return _context.Sepets.Any(e => e.Id == id);
    }
}
