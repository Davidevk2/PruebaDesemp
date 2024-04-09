
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaDesemp.Data;
using PruebaDesemp.Models;


namespace PruebaDesemp.Controllers
{
    
    public class EmployeesController : Controller
    {
        //indeyeccion de dependencias para la db
        public readonly OfferContext _context;
        //constructor que inicializa la db
        public EmployeesController(OfferContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
        }

        public IActionResult Create(){

            return View();
        }

        public async Task<IActionResult> Insert(Employ employ){

            
            _context.Employees.Add(employ);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

            

        }

        
    }
}