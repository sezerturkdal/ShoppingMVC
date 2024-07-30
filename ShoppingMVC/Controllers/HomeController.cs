using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShoppingMVC.Models;

namespace ShoppingMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ShoppingDbContext _context;

    public HomeController(ILogger<HomeController> logger, ShoppingDbContext context)
    {
        _logger = logger;
        _context = context;
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
        var allProducts = _context.Products.ToList();
        return View(allProducts);
    }

    public IActionResult CreateEditProduct(int? id)
    {
        if (id != null)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            return View(product);
        }

        return View();
    }

    public IActionResult DeleteProduct(int id)
    {
        var product = _context.Products.FirstOrDefault(x => x.Id == id);
        _context.Products.Remove(product);
        _context.SaveChanges();

        return RedirectToAction("Products");
    }

    public IActionResult CreateEditProductForm(Product product)
    {
        if (product.Id == 0)
        {
            _context.Products.Add(product);
        }
        else
        {
            _context.Products.Update(product);
        }
        
        _context.SaveChanges();

        return RedirectToAction("Products");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

