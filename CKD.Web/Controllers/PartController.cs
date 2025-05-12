using CKD.DataAccess.Data;
using CKD.DataAccess.Models;
using CKD.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CKD.Web.Controllers
{
    public class PartController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Part> part = _context.Parts.ToList();
            return View(ToPartViewModels(part));
        }

        /*_________________________________________________________________________________________________*/
        /*_________________________________________Helper Methods__________________________________________*/
        /*________________________________________for mapping data_________________________________________*/


        public static IEnumerable<PartViewModel> ToPartViewModels(IEnumerable<Part> inputParts)
        {
            var outputParts = new List<PartViewModel>();

            foreach (var inputProduct in inputParts)
            {
                var outputPart = new PartViewModel
                {
                    Id = inputProduct.TechNo,
                    Version = inputProduct.Version,
                    FarsiName = inputProduct.FarsiName,
                    EnglishName = inputProduct.EnglishName,
                    IsSet = inputProduct.IsSet,
                };
                outputParts.Add(outputPart);
            }
            return outputParts;
        }
        public static Part ToPartDbModel(PartViewModel partVm)
        {
            return new Part
            {
                TechNo = partVm.Id,
                Version = partVm.Version,
                FarsiName = partVm.FarsiName,
                EnglishName = partVm.EnglishName,
                IsSet = partVm.IsSet,
            };
        }

        /*_________________________________________Create__________________________________________________*/

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PartViewModel partVm)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "There was a problem!";
                return View();
            }

                _context.Parts.Add(ToPartDbModel(partVm));
                await _context.SaveChangesAsync();
                TempData["Message"] = "New part created successfully.";
                TempData["success"] = "New part created successfully.";
                return RedirectToAction(nameof(Index));
        }
    }
}
