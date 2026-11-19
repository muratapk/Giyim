
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Giyim.Models;
using Giyim.Data;

public class UrunYorumController : Controller
{
    private readonly AppDbContext _context;

    public UrunYorumController(AppDbContext context)
    {
        _context = context;
    }

    // GET: URUNYORUMS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.UrunYorumlar.ToListAsync());
    }

    // GET: URUNYORUMS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var urunyorum = await _context.UrunYorumlar
            .FirstOrDefaultAsync(m => m.Id == id);
        if (urunyorum == null)
        {
            return NotFound();
        }

        return View(urunyorum);
    }

    // GET: URUNYORUMS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: URUNYORUMS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Yorum,Puan,YorumTarihi,UrunId,Urun,KullaniciId")] UrunYorum urunyorum)
    {
        if (ModelState.IsValid)
        {
            _context.Add(urunyorum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(urunyorum);
    }

    // GET: URUNYORUMS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var urunyorum = await _context.UrunYorumlar.FindAsync(id);
        if (urunyorum == null)
        {
            return NotFound();
        }
        return View(urunyorum);
    }

    // POST: URUNYORUMS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Yorum,Puan,YorumTarihi,UrunId,Urun,KullaniciId")] UrunYorum urunyorum)
    {
        if (id != urunyorum.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(urunyorum);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UrunYorumExists(urunyorum.Id))
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
        return View(urunyorum);
    }

    // GET: URUNYORUMS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var urunyorum = await _context.UrunYorumlar
            .FirstOrDefaultAsync(m => m.Id == id);
        if (urunyorum == null)
        {
            return NotFound();
        }

        return View(urunyorum);
    }

    // POST: URUNYORUMS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var urunyorum = await _context.UrunYorumlar.FindAsync(id);
        if (urunyorum != null)
        {
            _context.UrunYorumlar.Remove(urunyorum);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool UrunYorumExists(int? id)
    {
        return _context.UrunYorumlar.Any(e => e.Id == id);
    }
}
