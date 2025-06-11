using CKD.DataAccess.Data;
using CKD.DataAccess.Models;
using CKD.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CKD.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProductController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
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
        public async Task<IActionResult> Create(ProductViewModel productVm)
        {
            if (!ModelState.IsValid)
            {
                TempData["message"] = "There was a problem!";
                TempData["error"] = "There was a problem!";
                return View();
            }

            string webRootPath = _hostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            string fileName_new = Guid.NewGuid().ToString();
            var uploads = Path.Combine(webRootPath, @"images\products");
            var extension = Path.GetExtension(files[0].FileName);
            using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }

            productVm.NewImage = @"\images\products\" + fileName_new + extension;
            productVm.OldImage = productVm.NewImage;

            _context.Products.Add(ToProductDbModel(productVm));
            await _context.SaveChangesAsync();
            TempData["message"] = "New product created successfully.";
            TempData["success"] = "New product created successfully.";
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

            string webRootPath = _hostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;


            var oldImage = productVm.OldImage;
            if (files.Count > 0)
            {
                string fileName_new = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\products");
                var extension = Path.GetExtension(files[0].FileName);

                //Delete the old Image
                var oldImagePath = Path.Combine(webRootPath, oldImage.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }

                //New upload Image
                using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                productVm.NewImage = @"\images\products\" + fileName_new + extension;
            }
            else
            {
                productVm.NewImage = oldImage;
            }
            _context.Products.Update(ToProductDbModel(productVm));
            await _context.SaveChangesAsync();
            TempData["message"] = "Exist product updated successfully.";
            TempData["success"] = "Exist product updated successfully.";
            return RedirectToAction(nameof(Index));
        }

        /*_________________________________________________________________________________________________*/
        /*_________________________________________Helper Methods__________________________________________*/
        /*________________________________________for mapping data_________________________________________*/

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
                    Notes = inputProduct.Notes,
                    //EngineType = inputProduct.EngineTypeDesc,
                    Usage = inputProduct.Usage,
                    OldImage = inputProduct.Image,
                    NewImage = inputProduct.Image,
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
                Notes = inputProduct.Notes,
                //EngineType = inputProduct.EngineTypeDesc,
                Usage = inputProduct.Usage,
                OldImage = inputProduct.Image,
                NewImage = inputProduct.Image,
            };
        }
        public static Product ToProductDbModel(ProductViewModel productVm)
        {
            return new Product
            {
                ProductCode = productVm.Id,
                ProductVersion = productVm.Version,
                ProductName = productVm.Name,
                Notes = productVm.Notes,
                //EngineTypeDesc = productVm.EngineType,
                Usage = productVm.Usage,
                Image = productVm.NewImage,
                CreateByUserEID = 1284,
                CreateDate = DateTime.Now,
            };
        }
    }
}
