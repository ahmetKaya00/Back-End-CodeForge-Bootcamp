using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BasicApp.Models;

namespace BasicApp.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
    
}
