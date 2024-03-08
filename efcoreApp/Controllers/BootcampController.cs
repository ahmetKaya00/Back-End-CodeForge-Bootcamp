using efcoreApp.Data;
using efcoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var kurslar = await _context.Bootcamps.Include(b=>b.Egitmen).ToListAsync();
            return View(kurslar);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Egitmenler = new SelectList(await _context.Egitmenler.ToListAsync(), "OgretmenId","AdSoyad");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BootcampViewModel model)
        {
            if(ModelState.IsValid){
                _context.Bootcamps.Add(new Bootcamp(){KursId = model.KursId, Baslik = model.Baslik, EgitmenId = model.EgitmenId});
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Egitmenler = new SelectList(await _context.Egitmenler.ToListAsync(), "OgretmenId","AdSoyad");

            return View(model);
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
                                     .Select(k=> new BootcampViewModel{
                                        KursId = k.KursId,
                                        Baslik = k.Baslik,
                                        EgitmenId = k.EgitmenId,
                                        Kayitlar = k.KursKayitlari                                  
                                     })
                                     .FirstOrDefaultAsync(k=>k.KursId == id);

            if(kurs == null) 
            {
                return NotFound();
            }
            ViewBag.Egitmenler = new SelectList(await _context.Egitmenler.ToListAsync(), "OgretmenId","AdSoyad");
            return View(kurs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BootcampViewModel model)
        {
            if(id != model.KursId)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(new Bootcamp(){KursId = model.KursId, Baslik = model.Baslik, EgitmenId = model.EgitmenId});
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