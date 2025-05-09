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
            return View(ToPartViewModels( part));
        }

        /*_________________________________________________________________________________________________*/
        /*_________________________________________Helper Methods__________________________________________*/
        /*_________________________________________________________________________________________________*/


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

    }
}
