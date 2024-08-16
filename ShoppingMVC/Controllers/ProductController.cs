using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        private readonly ShoppingDbContext _context;

        private readonly IUnitOfWork unitOfWork;

        public ProductController(ILogger<ProductController> logger, ShoppingDbContext context, IUnitOfWork work)
        {
            _logger = logger;
            _context = context;
            unitOfWork = work;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var allProducts = unitOfWork.productRepository.GetAllAsync().Result;

            return View(allProducts.Where(x => x.IsDeleted == false).ToList());
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

            return RedirectToAction("Index");
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

            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatus(int id)
        {
            unitOfWork.productRepository.ChangeEntityStatus(id);
            
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

