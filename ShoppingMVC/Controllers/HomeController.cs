using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShoppingMVC.Models;

namespace ShoppingMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ShoppingDbContext _context;

    private readonly IUnitOfWork unitOfWork;

    public HomeController(ILogger<HomeController> logger, ShoppingDbContext context, IUnitOfWork work)
    {
        _logger = logger;
        _context = context;
        unitOfWork = work;
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
        var allProducts = unitOfWork.productRepository.GetAllAsync().Result;
        
        return View(allProducts.Where(x=>x.IsActive==true && x.IsDeleted==false).ToList());
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

