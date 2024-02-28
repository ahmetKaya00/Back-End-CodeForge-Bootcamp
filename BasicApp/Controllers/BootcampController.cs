using BasicApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicApp.Controllers
{
    public class BootcampController:Controller
    {
        public IActionResult Index(){
            return View(Repository.Bootcamps);
        }    
        public IActionResult Details(int id){
            
            var bootcamp = Repository.GetById(id);
            return View(bootcamp);
        }  

        public IActionResult List(){
            return View(Repository.Bootcamps);
        }
    }
}