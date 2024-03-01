using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FormApp.Controllers;

public class HomeController : Controller
{


    public HomeController()
    {

    }

    public IActionResult Index(string searchString, string category)
    {
        var product = Repository.Products;

        if(!String.IsNullOrEmpty(searchString)){

            ViewBag.SearchString = searchString;
            product = product.Where(p=>p.BookName.ToLower().Contains(searchString)).ToList();
        }

        if(!String.IsNullOrEmpty(category) && category != "0"){
            product = product.Where(p=>p.CategoryId == int.Parse(category)).ToList();
        }

        var model = new PrdouctViewModel{
            Products = product,
            Categories = Repository.Categories,
            SelectedCategory = category
        };
        
        return View(model);
    }
    public IActionResult Admin()
    {
        return View(Repository.Products);
    }

    [HttpGet]
    public IActionResult Create(){
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId","Name");
        return View();
    }


    [HttpPost]
    public IActionResult Create(Product model){
        return View();
    }

}
