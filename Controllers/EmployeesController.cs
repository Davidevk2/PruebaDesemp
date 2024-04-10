
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
        private readonly IWebHostEnvironment _hostEnvironment;
        //constructor que inicializa la db
        public EmployeesController(OfferContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index(string? search)
        {
            var employ = from employs in _context.Employees select employs;
            if(!string.IsNullOrEmpty(search)){
                employ = employ.Where(e => e.Names.Contains(search) || e.LastNames.Contains(search) || e.Email.Contains(search) || e.About.Contains(search));
            }

            return View(await employ.ToListAsync());
        }

        public IActionResult Create(){

            return View();
        }

        public async Task<IActionResult> Insert(Employ employ){

            _context.Employees.Add(employ);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");   

        }

        public async Task<IActionResult> Details(int? id){

            return View(await _context.Employees.FirstOrDefaultAsync(e => e.Id == id));
        }

        public async Task<IActionResult> Delete(int? id){
            
            var employ = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employ);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
    }
}