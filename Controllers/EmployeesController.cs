
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

        public async Task<IActionResult> Insert(Employ employ, IFormFile profile, IFormFile cv){

            var routeProfile = Path.Combine(_hostEnvironment.WebRootPath, "images", profile.FileName);
            var routeCv = Path.Combine(_hostEnvironment.WebRootPath, "documents", cv.FileName);
             //guardar la imagen de perfil 
            using(var stream = new FileStream(routeProfile,FileMode.Create)){
                await profile.CopyToAsync(stream);
            }

            //guardar el documento
            using(var stream = new FileStream(routeCv,FileMode.Create)){
                await profile.CopyToAsync(stream);
            }

            employ.ProfilePicture = "/images/"+ profile.FileName;
            employ.Cv = "/documents/"+ cv.FileName;

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