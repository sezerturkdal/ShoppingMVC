using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ShoppingMVC.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShoppingMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        private readonly ShoppingDbContext _context;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(ILogger<ProductController> logger, ShoppingDbContext context, IUnitOfWork work, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _context = context;
            _unitOfWork = work;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var allProducts = _unitOfWork.productRepository.GetAllAsync().Result;

            return View(allProducts.Where(x => x.IsDeleted == false).ToList());
        }

        public IActionResult CreateEditProduct(int? id)
        {
            if (id != null)
            {
                var product = _unitOfWork.productRepository.GetAsync(id).Result;
                return View(product);
            }

            return View();
        }

        public IActionResult DeleteProduct(int id)
        {
            var product = _unitOfWork.productRepository.GetAsync(id).Result;
            _unitOfWork.productRepository.DeleteEntity(product);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult CreateEditProductForm(Product product, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads/");
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }
                var fileExtension = Path.GetExtension(image.FileName);
                var fileName =  Guid.NewGuid().ToString() + fileExtension;
                var filePath = Path.Combine(uploadFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
                product.PhotoURL = "/uploads/" + fileName;
            }
            
            if (product.Id == 0)
            {
                _unitOfWork.productRepository.AddEntity(product);
            }
            else
            {
                _unitOfWork.productRepository.UpdateEntity(product);
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult ChangeStatus(int id)
        {
            _unitOfWork.productRepository.ChangeEntityStatus(id);
            
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

