using Microsoft.EntityFrameworkCore;
using PruebaDesemp.Models;

namespace PruebaDesemp.Data
{
    public class OfferContext : DbContext{

        //Contructor
        public OfferContext(DbContextOptions<OfferContext> options): base(options){}

        //Registro de modelos a utilizar
        public DbSet<Job> Jobs {get; set;}
        public DbSet<Employ> Employees {get; set;}
    }
}