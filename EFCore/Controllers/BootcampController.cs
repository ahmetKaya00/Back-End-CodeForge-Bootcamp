using EFCore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Controllers
{
    public class BootcampController:Controller{
        private readonly DataContext _context;

        public BootcampController(DataContext context){
            _context = context;
        }

        public async Task<IActionResult> Index(){
            var bootcamps = await _context.Bootcamps.ToListAsync();
            return View(bootcamps);
        }

        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Bootcamp model){
            _context.Bootcamps.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult>Edit(int? id){
            if(id == null){
                return NotFound();
            }
            var bootcamp = await _context.Bootcamps.FindAsync(id);
            if(bootcamp == null){
                return NotFound();
            }
            return View(bootcamp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult>Edit(int? id, Bootcamp model){

            if(id != model.KursId){
                return NotFound();
            }
            if(ModelState.IsValid){
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!_context.Bootcamps.Any(o=>o.KursId == model.KursId)){
                        return NotFound();
                    }
                    else{
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int? id){
            if(id == null){
                return NotFound();
            }

            var bootcamp = await _context.Bootcamps.FindAsync(id);
            if(bootcamp == null){
                return NotFound();
            }
            return View(bootcamp);
        }
        [HttpPost]

        public async Task<IActionResult> Delete([FromForm]int id){
            var bootcamp = await _context.Bootcamps.FindAsync(id);
            if(bootcamp == null){
                return NotFound();
            }

            _context.Bootcamps.Remove(bootcamp);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}