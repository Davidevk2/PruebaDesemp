
using Microsoft.AspNetCore.Mvc;
using PruebaDesemp.Data;


namespace PruebaDesemp.Controllers
{
    
    public class EmployeesController : Controller
    {
        public readonly OfferContext _context;

        public EmployeesController(OfferContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        
    }
}