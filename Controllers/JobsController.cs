

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaDesemp.Data;
using PruebaDesemp.Models;

namespace PruebaDesemp.Controllers
{
    public class JobsController : Controller
    {
        //Inyeccion de dependencias para la conexion con la db
        public  readonly OfferContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        //Constructor que inicializa la conexion
        public JobsController(OfferContext context, IWebHostEnvironment hostEnvironment )
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Jobs.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int id){
            return View(await _context.Jobs.FirstOrDefaultAsync(c => c.Id == id));
        }

        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertJob(Job job, IFormFile file){

            if(ModelState.IsValid){

                var route = Path.Combine(_hostEnvironment.WebRootPath, "files", file.FileName);
                using(var stream = new FileStream(route,FileMode.Create)){
                    await file.CopyToAsync(stream);
                }

                job.LogoCompany = "/files/"+file.FileName;
                _context.Jobs.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");

            }else{
                return View(job);
            }
        }





      
    }
}