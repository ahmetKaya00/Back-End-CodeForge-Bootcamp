using efcoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace efcoreApp.Controllers
{
    public class BootcampKayitController:Controller
    {
        private readonly DataContext _context;
        public BootcampKayitController(DataContext context)
        {   
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var kursKayitlari = await _context
                                .Kayitlar
                                .Include(x=>x.Ogrenci)
                                .Include(x=>x.Kurs)
                                .ToListAsync();
            return View(kursKayitlari);
        } 

        public async Task<IActionResult> Create()
        {
            ViewBag.Ogrenciler = new SelectList(await _context.Ogrenciler.ToListAsync(), "OgrenciId","AdSoyad");
            ViewBag.Kurslar = new SelectList(await _context.Bootcamps.ToListAsync(), "KursId","Baslik");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]        
        public async Task<IActionResult> Create(BootcampKayit model)
        {
            model.KayitTarihi = DateTime.Now;
            _context.Kayitlar.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


    }
}