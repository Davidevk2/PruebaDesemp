

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

        public async Task<IActionResult> Index(string? search)
        {
            var job = from  jobs in _context.Jobs select jobs;
            if(!string.IsNullOrEmpty(search)){
                job = job.Where(j => j.NameCompany.Contains(search) || j.OfferTitle.Contains(search)  || j.Description.Contains(search) || j.Salary.ToString().Contains(search));

            }
            return View(await job.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int id){
            return View(await _context.Jobs.FirstOrDefaultAsync(c => c.Id == id));
        }

        public IActionResult Create(){
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Insert(Job job, IFormFile file){

         

            var route = Path.Combine(_hostEnvironment.WebRootPath, "images", file.FileName);
            using(var stream = new FileStream(route,FileMode.Create)){
                await file.CopyToAsync(stream);
            }

            

            job.LogoCompany = "/images/"+file.FileName;
            _context.Jobs.Add(job);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

            
        }


        //View to edit 
        public async Task<IActionResult> Edit( int? id){
            return View( await _context.Jobs.FirstOrDefaultAsync(j => j.Id == id));
        }

        public async Task<IActionResult> Update(Job job, IFormFile file){

           
            job.LogoCompany = file.FileName;
            _context.Jobs.Update(job);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

  
        }

        public async Task<IActionResult> Confirmation(int? id){

            return View(await _context.Jobs.FirstOrDefaultAsync(e => e.Id == id));
        }

        public async Task<IActionResult> Delete(int? id){

            var job = await _context.Jobs.FindAsync(id);

            _context.Jobs.Remove(job);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }





      
    }
}