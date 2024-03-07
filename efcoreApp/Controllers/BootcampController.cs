using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class BootcampController:Controller
    {
        private readonly DataContext _context;
        public BootcampController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var kurslar = await _context.Bootcamps.ToListAsync();
            return View(kurslar);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bootcamp model)
        {
            _context.Bootcamps.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var kurs = await _context.Bootcamps
                                     .Include(k=>k.KursKayitlari)
                                     .ThenInclude(k=>k.Ogrenci)
                                     .FirstOrDefaultAsync(k=>k.KursId == id);

            if(kurs == null) 
            {
                return NotFound();
            }

            return View(kurs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Bootcamp model)
        {
            if(id != model.KursId)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateException)
                {
                    if(!_context.Bootcamps.Any(o => o.KursId == model.KursId))
                    {
                        return NotFound();
                    } 
                    else 
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var kurs = await _context.Bootcamps.FindAsync(id);

            if(kurs == null)
            {
                return NotFound();
            }

            return View(kurs);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            var kurs = await _context.Bootcamps.FindAsync(id);
            if(kurs == null)
            {
                return NotFound();
            }
            _context.Bootcamps.Remove(kurs);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}