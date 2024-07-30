using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShoppingMVC.Models;

namespace ShoppingMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Products()
    {
        return View();
    }

    public IActionResult CreateEditProduct()
    {
        return View();
    }

    public IActionResult CreateEditProductForm(Product product)
    {
        return RedirectToAction("Products");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

