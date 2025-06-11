using CKD.DataAccess.Data;
using CKD.DataAccess.Models;
using CKD.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CKD.Web.Controllers
{
    public class EngineTypeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EngineTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<EngineType> engineTypes = _context.EngineTypes;
            return View(engineTypes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EngineTypeViewModel engineTypeVm)
        {
            if (!ModelState.IsValid)
            {
                TempData["message"] = "There was a problem! Please check the entered values.";
                TempData["error"] = "There was a problem! Please check the entered values.";
                return View(engineTypeVm);
            }
            if (IsExists())
            {
                TempData["message"] = "This Engine Type already exists in the database.";
                TempData["error"] = "This Engine Type exists in the database.";
                return View(engineTypeVm);
            }

            EngineType engineType = new()
            {
                Name = engineTypeVm.Name,
            };

            try
            {
                // Add a new item to the database
                _context.EngineTypes.Add(engineType);
                // Save changes
                await _context.SaveChangesAsync();
                TempData["message"] = "New Engine Type created successfully.";
                TempData["success"] = "New Engine Type created successfully.";
                // Redirect to Index on success
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                // Log the error (optional)
                Console.WriteLine($"Error: {ex.Message}");

                // Add a user-friendly error message
                ModelState.AddModelError(string.Empty, "Unable to save changes. Please try again later.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine($"Unexpected Error: {ex.Message}");
                ModelState.AddModelError("", "An unexpected error occurred. Please contact support.");
            }

            // Return the view with the model to show validation errors
            return View(engineTypeVm);
        }

        private bool IsExists()
        {
            return false;
        }
    }
}
