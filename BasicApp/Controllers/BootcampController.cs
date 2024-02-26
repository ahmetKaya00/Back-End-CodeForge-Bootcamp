using BasicApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BasicApp.Controllers
{
    public class BootcampController:Controller
    {
        public IActionResult Index(){
            var bootcamp = new Bootcamp();
            bootcamp.Id = 1;
            bootcamp.Title = "Backend Bootcamp";
            bootcamp.Description = "Asp.Net Core ile geliştiriyoruz. Eğitime az kaldı.";
            bootcamp.Instructor = "Ahmet Kaya";
            bootcamp.Image = "2.png";
            return View(bootcamp);
        }    

        public IActionResult List(){
            var bootcams = new List<Bootcamp>(){
                new() {Id = 1, Title = "Backend Bootcamp",Description="Güzel eğitim.", Instructor = "Ahmet Kaya", Image = "1.png"},
                new() {Id = 2, Title = "Froundend Bootcamp",Description="Güzel eğitim.", Instructor = "Barış Uygun", Image = "2.png"},
                new() {Id = 3, Title = "Unity Bootcamp",Description="Güzel eğitim.", Instructor = "Özge Dirik", Image = "3.png"},
            };
            return View(bootcams);
        }
    }
}