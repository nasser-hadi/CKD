using CKD.DataAccess.Data;
using CKD.DataAccess.Models;
using CKD.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CKD.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _context.Products.ToList();

            return View(ToProductViewModels(products));
        }

        /*_________________________________________Create__________________________________________________*/

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel objProduct)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "There was a problem!";
                return View();
            }

            _context.Products.Add(ToProductDbModel(objProduct));
            await _context.SaveChangesAsync();

            TempData["Message"] = "New product created successfully.";
            return RedirectToAction(nameof(Index));
        }

        /*___________________________________________Edit__________________________________________________*/

        [HttpGet]
        public IActionResult Edit(string Id)
        {
            Product? product = _context.Products.FirstOrDefault(u => u.ProductCode == Id);
            if (product == null)
            {
                return View();
            }

            return View(ToProductViewModel(product));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductViewModel productVm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _context.Products.Update(ToProductDbModel(productVm));
            await _context.SaveChangesAsync();
            TempData["Message"] = "Exist product updated successfully.";
            
            return RedirectToAction(nameof(Index));
        }


        /*_________________________________________________________________________________________________*/
        /*_________________________________________Helper Methods__________________________________________*/
        /*_________________________________________________________________________________________________*/

        public static IEnumerable<ProductViewModel> ToProductViewModels(IEnumerable<Product> inputProducts)
        {
            var outputProducts = new List<ProductViewModel>();

            foreach (var inputProduct in inputProducts)
            {
                var outputProduct = new ProductViewModel
                {
                    Id = inputProduct.ProductCode,
                    Name = inputProduct.ProductName,
                    Version = inputProduct.ProductVersion,
                    Notes = inputProduct.Notes2,
                    EngineType = inputProduct.EngineTypeDesc
                };
                outputProducts.Add(outputProduct);
            }
            return outputProducts;
        }
        public static ProductViewModel ToProductViewModel(Product inputProduct)
        {
            return new ProductViewModel
            {
                Id = inputProduct.ProductCode,
                Name = inputProduct.ProductName,
                Version = inputProduct.ProductVersion,
                Notes = inputProduct.Notes2,
                EngineType = inputProduct.EngineTypeDesc
            };
        }
        public static Product ToProductDbModel(ProductViewModel productVm)
        {
            return new Product
            {
                ProductCode = productVm.Id,
                ProductVersion = productVm.Version,
                ProductName = productVm.Name,
                Notes2 = productVm.Notes,
                EngineTypeDesc = productVm.EngineType,
                CreateByUserEID = 1284,
                CreateDate = DateTime.Now,
            };
        }
    }
}