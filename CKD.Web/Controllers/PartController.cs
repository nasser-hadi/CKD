using CKD.DataAccess.Data;
using CKD.DataAccess.Models;
using CKD.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                return View(partVm);
            }

            if (!IsExists(partVm.Id))
            {
                _context.Parts.Add(ToPartDbModel(partVm));
                await _context.SaveChangesAsync();
                TempData["Message"] = "New part created successfully.";

                return RedirectToAction(nameof(Index));
            }
            else
            {
                TempData["Message"] = "This Part is exist in database.";
                return View(partVm);
            }
        }

        /*___________________________________________Edit__________________________________________________*/

        [HttpGet]
        public IActionResult Edit(string id)
        {
            Part? part = _context.Parts.FirstOrDefault(u => u.TechNo == id);
            if (part == null)
            {
                return NotFound();
            }

            return View(ToPartViewModel(part));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string Id, PartViewModel part)
        {
            if (!ModelState.IsValid)
            {
                return View(part);
            }

            try
            {
                _context.Parts.Update(ToPartDbModel(part));
                await _context.SaveChangesAsync();
                TempData["Message"] = "Exist part updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!_context.Parts.Any(p => p.TechNo == Id))
                {
                    return NotFound();
                }
                throw;
            }
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

        public static PartViewModel ToPartViewModel(Part inputProduct)
        {
            return new PartViewModel
            {
                Id = inputProduct.TechNo,
                Version = inputProduct.Version,
                FarsiName = inputProduct.FarsiName,
                EnglishName = inputProduct.EnglishName,
                IsSet = inputProduct.IsSet,                
            };
        }

        /*_________________________________________________________________________________________________*/
        /*_________________________________________Helper Methods__________________________________________*/
        /*______________________________________________Other______________________________________________*/
        private bool IsExists(string value)
        {
            var exists = _context.Parts.Any(e => e.TechNo == value);
            return exists;
        }
    }
}
