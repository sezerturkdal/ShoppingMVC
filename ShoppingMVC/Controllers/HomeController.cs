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
        
        return View(allProducts.Where(x=>x.IsDeleted==false).ToList());
    }

    public IActionResult CreateEditProduct(int? id)
    {
        if (id != null)
        {
            var product = unitOfWork.productRepository.GetAsync(id).Result;
            return View(product);
        }

        return View();
    }

    public IActionResult DeleteProduct(int id)
    {
        var product = unitOfWork.productRepository.GetAsync(id).Result;
        unitOfWork.productRepository.DeleteEntity(product);

        _context.SaveChanges();

        return RedirectToAction("Products");
    }

    public IActionResult CreateEditProductForm(Product product)
    {
        if (product.Id == 0)
        {
            unitOfWork.productRepository.AddEntity(product);
        }
        else
        {
            unitOfWork.productRepository.UpdateEntity(product);
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

